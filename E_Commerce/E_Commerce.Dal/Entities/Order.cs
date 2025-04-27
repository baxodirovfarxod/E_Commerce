using E_Commerce.Dal.Enums;

namespace E_Commerce.Dal.Entities;
public class Order
{
    public long OrderId { get; set; }
    public long CustomerId { get; set; }
    public DateTime CreatedAt { get; set; }
    public decimal TotalAmount { get; set; }
    public decimal Discount { get; set; }
    public byte DiscountPercentage { get; set; }
    public decimal ServicePrice { get; set; }
    public Customer Customer { get; set; }
    public OrderStatus Status { get; set; }
    public List<OrderProduct> OrderProducts { get; set; }
    public List<Payment> Payments { get; set; }
}

