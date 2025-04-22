namespace E_Commerce.Dal.Entities;

public class Cart
{
    public long CartId { get; set; }
    public long CustomerId { get; set; }
    public DateTime CreatedAt { get; set; }
    public Customer Customer { get; set; }
    public List<CartProduct> CartProducts { get; set; }
}
