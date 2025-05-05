namespace E_Commerce.Dal.Entities;

public class OrderProduct
{
    public long OrderId { get; set; }
    public long ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal PriceAtPurchase { get; set; }
    public Order Order { get; set; }
    public Product Product { get; set; }
}

