namespace E_Commerce.Dal.Entities;

public class Payment
{
    public long PaymentId { get; set; }
    public long OrderId { get; set; }
    public string PaymentMethod { get; set; }
    public string PaymentStatus { get; set; }
    public decimal PaidAmount { get; set; }
    public DateTime PaidAt { get; set; }
    // public Order Order { get; set; }
}

