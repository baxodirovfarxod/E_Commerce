using E_Commerce.Dal.Enums;

namespace E_Commerce.Bll.Dtos.PaymentDTOs;

public class PaymentUpdateDto
{
    public long PaymentId { get; set; }
    public PaymentStatus PaymentStatus { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
}
