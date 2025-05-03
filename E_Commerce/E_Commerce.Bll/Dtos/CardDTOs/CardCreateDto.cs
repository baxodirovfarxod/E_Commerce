namespace E_Commerce.Bll.Dtos.CardDTOs;

public class CardCreateDto
{
    public long CustomerId { get; set; }
    public string Number { get; set; }
    public string? HolderName { get; set; }
    public int ExpirationMonth { get; set; }
    public int ExpirationYear { get; set; }
    public int? Cvv { get; set; }
}
