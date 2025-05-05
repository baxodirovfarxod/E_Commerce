using E_Commerce.Bll.Dtos.CustomerDTOs;
using E_Commerce.Bll.Dtos.OrderProductDTOs;
using E_Commerce.Bll.Dtos.PaymentDTOs;
using E_Commerce.Dal.Enums;

namespace E_Commerce.Bll.Dtos.OrderDTOs;

public class OrderGetDto
{
    public long OrderId { get; set; }
    public long CustomerId { get; set; }
    public DateTime CreatedAt { get; set; }
    public decimal TotalAmount { get; set; }
    public decimal Discount { get; set; }
    public byte DiscountPercentage { get; set; }
    public decimal ServicePrice { get; set; }
    public OrderStatus Status { get; set; }
    public List<OrderProductGetDto>? OrderProducts { get; set; }
    public List<PaymentGetDto>? Payments { get; set; }
}
