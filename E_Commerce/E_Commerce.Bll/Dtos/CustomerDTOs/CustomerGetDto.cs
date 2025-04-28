using E_Commerce.Bll.Dtos.CardDTOs;
using E_Commerce.Bll.Dtos.CartDTOs;
using E_Commerce.Bll.Dtos.OrderDTOs;

namespace E_Commerce.Bll.Dtos.CustomerDTOs;

public class CustomerGetDto : CustomerCreateDto
{
    public long CustomerId { get; set; }
    public List<CartGetDto>? Carts { get; set; }
    public List<OrderGetDto>? Orders { get; set; }
    public List<CardGetDto>? Cards { get; set; }
}
