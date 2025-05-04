using AutoMapper;
using E_Commerce.Bll.Dtos.CardDTOs;
using E_Commerce.Dal.Entities;
using E_Commerce.Repository.Repositories;
using FluentValidation;

namespace E_Commerce.Bll.Services.CardService
{
    public class CardService : ICardService
    {
        private readonly ICardRepository _cardRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<CardCreateDto> _cardCreateDtoValidator;

        public CardService(ICardRepository cardRepository, IMapper mapper, IValidator<CardUpdateDto> cardUpdateDtoValidator, IValidator<CardCreateDto> cardCreateDtovalidator)
        {
            _cardRepository = cardRepository;
            _mapper = mapper;
            _cardCreateDtoValidator = cardCreateDtovalidator;
        }
        
        public async Task<long> CreateCardAsync(CardCreateDto cardCreateDto)
        {
            ArgumentNullException.ThrowIfNull(cardCreateDto);

            var validationResult = await _cardCreateDtoValidator.ValidateAsync(cardCreateDto);
            if (!validationResult.IsValid)
            {
                var errors = string.Join("; ", validationResult.Errors.Select(e => e.ErrorMessage));
                throw new ValidationException($"Validation failed: {errors}");
            }

            var existingCards = await _cardRepository.SelectCardsByCustomerIdAsync(cardCreateDto.CustomerId);


            foreach (var card in existingCards)
            {
                if (card.Number == cardCreateDto.Number)
                {
                    throw new ValidationException("Card with this number already exists.");
                }
            }

            if (existingCards.Count >= 5)
            {
                throw new ValidationException("You can only save up to 5 cards.");
            }
            var selectedCards = existingCards.Where(c => c.SelectedForPayment).ToList();
            await _cardRepository.AssignCardsAsNotSelectedAsync(selectedCards);

            var cardEntity = _mapper.Map<Card>(cardCreateDto);
            cardEntity.SelectedForPayment = true;
            return await _cardRepository.InsertCardAsync(cardEntity);
        }

        public async Task DeleteCardAsync(long cardId, long customerId)
        {
            var cards = await _cardRepository.SelectCardsByCustomerIdAsync(customerId);
            var toDelete = cards.FirstOrDefault(c => c.CardId == cardId);

            if (toDelete is null)
            {
                throw new InvalidOperationException("card isn't found or doesn't belong to this customer");
            }

            await _cardRepository.DeleteCardAsync(cardId);

            if (toDelete.SelectedForPayment)
            {
                var anotherCard = cards.FirstOrDefault(c => c.CardId != cardId);
                if (anotherCard != null)
                {
                    await _cardRepository.AssignCardAsSelectedAsync(anotherCard.CardId);
                }
            }
        }

        public async Task<List<CardGetDto>> GetCardsByCustomerIdAsync(long customerId)
        {
            var allCards = await _cardRepository.SelectCardsByCustomerIdAsync(customerId);
            var cardGetDtos = allCards
            .Select(card => _mapper.Map<CardGetDto>(card))
            .ToList();

            return cardGetDtos;
        }

        public async Task SelectCardForPaymentAsync(long cardId, long customerId)
        {
            var allCards = await _cardRepository.SelectCardsByCustomerIdAsync(customerId);

            var existCard = allCards.FirstOrDefault(c => c.CardId == cardId);

            if (existCard == null)
            {
                throw new InvalidOperationException("card isn't found or doesn't belong to this customer");
            }

            foreach (var card in allCards)
            {
                await _cardRepository.AssignCardAsNotSelectedAsync(card.CardId);
            }
            await _cardRepository.AssignCardAsSelectedAsync(cardId);

        }

    }
}
