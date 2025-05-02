using E_Commerce.Bll.Dtos.CardDTOs;
namespace E_Commerce.Bll.Services.CardService
{
    public interface ICardService
    {
        Task<long> CreateCardAsync(CardCreateDto cardCreateDto);
        Task<List<CardGetDto>> GetCardsByCustomerIdAsync(long customerId);
        Task SelectCardForPaymentAsync(long cardId, long customerId);
        Task DeleteCardAsync(long cardId, long customerId);
    }
}
