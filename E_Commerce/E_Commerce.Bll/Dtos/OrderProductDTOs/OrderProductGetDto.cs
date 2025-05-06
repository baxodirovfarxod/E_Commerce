using E_Commerce.Bll.Dtos.OrderDTOs;
using E_Commerce.Bll.Dtos.ProductDTOs;

namespace E_Commerce.Bll.Dtos.OrderProductDTOs;

public class OrderProductGetDto
{
    public long OrderProductId { get; set; }
    public long OrderId { get; set; }
    public long ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal PriceAtPurchase { get; set; }
}
