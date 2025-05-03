using E_Commerce.Bll.Dtos.CardDTOs;
using E_Commerce.Bll.Services.CardService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Server.Controller
{
    [Route("api/card")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly ICardService CardService;

        public CardController(ICardService cardService)
        {
            CardService = cardService;
        }

        [HttpPost("create")]
        public Task<long> CreateCardAsync(CardCreateDto cardCreateDto)
        {
            return CardService.CreateCardAsync(cardCreateDto);
        }

        [HttpGet("getCardsByCustomerId")]
        public Task<List<CardGetDto>> GetCardsByCustomerIdAsync(long customerId)
        {
            return CardService.GetCardsByCustomerIdAsync(customerId);
        }

        [HttpPut("selectCardForPaymentAsync")]
        public async Task SelectCardForPaymentAsync(long cardId, long customerId)
        {
            await CardService.SelectCardForPaymentAsync(cardId, customerId);
        }

        [HttpDelete("deleteCardAsync")]
        public async Task DeleteCardAsync(long cardId, long customerId)
        {
            await CardService.DeleteCardAsync(cardId, customerId);
        }
    }
}
