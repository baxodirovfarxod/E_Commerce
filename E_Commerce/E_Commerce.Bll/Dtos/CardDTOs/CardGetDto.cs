namespace E_Commerce.Bll.Dtos.CardDTOs;

public class CardGetDto : CardCreateDto
{
    public long CardId { get; set; }
    public bool SelectedForPayment { get; set; }
}
