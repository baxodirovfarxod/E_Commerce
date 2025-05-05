using E_Commerce.Bll.Dtos.ProductDTOs;

namespace E_Commerce.Bll.Dtos.CartProductDTOs;

public class CartProductGetDto 
{
    public int Quantity { get; set; }
    public long ProductId { get; set; }
    public ProductGetDto? Product { get; set; } 
}
