namespace E_Commerce.Bll.Dtos.CartProductDTOs;

public class CartProductCreateDto
{
    public int Quantity { get; set; }
    public long CustomerId { get; set; }
    public long ProductId { get; set; }
}
