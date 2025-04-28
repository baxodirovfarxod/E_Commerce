using E_Commerce.Bll.Dtos.CartProductDTOs;

namespace E_Commerce.Bll.Dtos.CartDTOs;

public class CartGetDto : CartCreateDto
{
    public long CartId { get; set; }
    public List<CartProductGetDto>? CartProducts { get; set; }
}
