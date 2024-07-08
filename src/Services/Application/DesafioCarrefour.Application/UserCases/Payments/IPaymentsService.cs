using DesafioCarrefour.Application.Objects;

namespace DesafioCarrefour.Application.UserCases.Payments;

public interface IPaymentsService
{
    Task<PaymentResponse> RegisterPayment(PaymentDto payment);
    Task<PaymentResponse> GetPayment(string id);
    Task<List<PaymentResponse>> GetAll();
    Task<List<PaymentResponse>> GetPaymentsByDate(DateTime referenceDate);
}
