namespace E_Commerce.Bll.Dtos.CartProductDTOs;

public class CartProductCreateDto
{
    public int Quantity { get; set; }
    public long CartId { get; set; }
    public long ProductId { get; set; }
}
