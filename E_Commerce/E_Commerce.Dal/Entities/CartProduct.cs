namespace E_Commerce.Dal.Entities;

public class CartProduct
{
    public int Quantity { get; set; }
    public long CartId { get; set; }
    public Cart Cart { get; set; }
    public long ProductId { get; set; }
    public Product Product { get; set; }
}

