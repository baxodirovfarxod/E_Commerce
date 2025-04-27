using E_Commerce.Dal.Enums;

namespace E_Commerce.Dal.Entities;

public class Payment
{
    public long PaymentId { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public PaymentStatus PaymentStatus { get; set; }
    public decimal PaidAmount { get; set; }
    public DateTime PaidAt { get; set; }
    public long OrderId { get; set; }
    public Order Order { get; set; }
}

