using E_Commerce.Bll.Dtos.ProductDTOs;

namespace E_Commerce.Bll.Dtos.CartProductDTOs;

public class CartProductGetDto : CartProductCreateDto
{
    public long CartProductId { get; set; }
    public ProductGetDto? Product { get; set; } 
}
