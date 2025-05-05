using E_Commerce.Bll.Dtos.CartProductDTOs;
using E_Commerce.Bll.Dtos.OrderProductDTOs;

namespace E_Commerce.Bll.Dtos.ProductDTOs;

public class ProductGetDto : ProductCreateDto
{
    public long ProductId { get; set; }
}
