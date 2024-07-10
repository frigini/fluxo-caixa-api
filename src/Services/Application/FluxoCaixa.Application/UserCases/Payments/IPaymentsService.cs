using FluxoCaixa.Application.Objects.Requests;
using FluxoCaixa.Application.Objects.Responses;

namespace FluxoCaixa.Application.UserCases.Payments;

public interface IPaymentsService
{
    Task<PaymentResponse> RegisterPayment(PaymentRequest paymentRequest);
    Task<PaymentResponse> GetPayment(Guid id);
    Task<IEnumerable<PaymentResponse>> GetAll();
    Task<IEnumerable<PaymentResponse>> GetPaymentsByDate(DateTime referenceDate);
}
