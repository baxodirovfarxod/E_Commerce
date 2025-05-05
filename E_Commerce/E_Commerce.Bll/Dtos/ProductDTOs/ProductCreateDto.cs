namespace E_Commerce.Bll.Dtos.ProductDTOs;

public class ProductCreateDto
{
    public string? Name { get; set; }
    public decimal Price { get; set; }
    public string? Description { get; set; }
    public int StockQuantity { get; set; }
    public string? ImageLink { get; set; }
}
