using FluxoCaixa.Application.Contracts;
using FluxoCaixa.Application.Factories;
using FluxoCaixa.Application.Objects.Requests;
using FluxoCaixa.Application.Objects.Responses;

namespace FluxoCaixa.Application.UserCases.Payments;

public class PaymentsService(IPaymentsRepository paymentsRepository) : IPaymentsService
{
    public async Task<PaymentResponse> RegisterPayment(PaymentRequest paymentRequest)
    {
        var payment = paymentRequest.ToDomain();
        var paymentCreated = await paymentsRepository.Create(payment);

        return new PaymentResponse(
            paymentCreated.Description,
            paymentCreated.PaymentType.ToString(),
            paymentCreated.PaymentValue,
            paymentCreated.PaymentDate
        );
    }

    public async Task<PaymentResponse> GetPayment(Guid id)
    {
        var payment = await paymentsRepository.Get(id);

        return payment.ToResponse();
    }

    public async Task<List<PaymentResponse>> GetAll()
    {
        var payments = await paymentsRepository.GetAll();

        return payments.ToResponse();
    }

    public async Task<List<PaymentResponse>> GetPaymentsByDate(DateTime referenceDate)
    {
        var payments = await paymentsRepository.GetAllByDate(referenceDate);

        return payments.ToResponse();
    }
}
