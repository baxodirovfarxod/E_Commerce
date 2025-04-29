using E_Commerce.Dal.Entities;

namespace E_Commerce.Repository.Repositories.Payments;

public interface IPaymentRepository
{
    Task<long> InsertPaymentAsync(Payment payment);
    Task UpdatePaymentAsync(Payment payment);
}
