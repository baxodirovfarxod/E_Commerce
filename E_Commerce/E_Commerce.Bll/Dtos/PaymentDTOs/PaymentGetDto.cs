using E_Commerce.Bll.Dtos.OrderDTOs;

namespace E_Commerce.Bll.Dtos.PaymentDTOs;

public class PaymentGetDto : PaymentCreateDto
{
    public long PaymentId { get; set; }
    public long OrderId { get; set; }
    public decimal PaidAmount { get; set; }
    public DateTime PaidAt { get; set; }
    public OrderGetDto? Order { get; set; }
}
