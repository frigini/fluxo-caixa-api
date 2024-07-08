using FluxoCaixa.Application.Objects.Requests;
using FluxoCaixa.Application.Objects.Responses;

namespace FluxoCaixa.Application.UserCases.Payments;

public interface IPaymentsService
{
    Task<PaymentResponse> RegisterPayment(PaymentRequest payment);
    Task<PaymentResponse> GetPayment(string id);
    Task<List<PaymentResponse>> GetAll();
    Task<List<PaymentResponse>> GetPaymentsByDate(DateTime referenceDate);
}
