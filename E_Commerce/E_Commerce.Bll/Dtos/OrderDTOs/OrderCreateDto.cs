namespace E_Commerce.Bll.Dtos.OrderDTOs;

public class OrderCreateDto
{
    public long CustomerId { get; set; }
    public decimal Discount { get; set; }
    public byte DiscountPercentage { get; set; }
}

