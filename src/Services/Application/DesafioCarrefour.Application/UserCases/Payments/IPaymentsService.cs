using DesafioCarrefour.Application.Objects.Requests;
using DesafioCarrefour.Application.Objects.Responses;

namespace DesafioCarrefour.Application.UserCases.Payments;

public interface IPaymentsService
{
    Task<PaymentResponse> RegisterPayment(PaymentRequest payment);
    Task<PaymentResponse> GetPayment(string id);
    Task<List<PaymentResponse>> GetAll();
    Task<List<PaymentResponse>> GetPaymentsByDate(DateTime referenceDate);
}
