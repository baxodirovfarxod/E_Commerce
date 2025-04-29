using E_Commerce.Dal;
using E_Commerce.Dal.Entities;

namespace E_Commerce.Repository.Repositories.Payments;
using System.Threading.Tasks;


public class PaymentRepository : IPaymentRepository
{

    private readonly MainContext _context;

    public PaymentRepository(MainContext context)
    {
        _context = context;
    }

    public async Task<long> InsertPaymentAsync(Payment payment)
    {
        _context.Payments.Add(payment);
        await _context.SaveChangesAsync();
        return payment.PaymentId;
    }

    public async Task UpdatePaymentAsync(Payment payment)
    {
        _context.Payments.Update(payment);
        await _context.SaveChangesAsync();
    }
}
