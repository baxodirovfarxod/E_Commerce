using E_Commerce.Dal.Enums;

namespace E_Commerce.Bll.Dtos.PaymentDTOs;

public class PaymentCreateDto
{
    public PaymentMethod PaymentMethod { get; set; }
    public PaymentStatus PaymentStatus { get; set; }
}
