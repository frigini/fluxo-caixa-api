using DesafioCarrefour.Application.Contracts;
using DesafioCarrefour.Application.Factories;
using DesafioCarrefour.Application.Objects.Requests;
using DesafioCarrefour.Application.Objects.Responses;

namespace DesafioCarrefour.Application.UserCases.Payments;

public class PaymentsService(IPaymentsRepository paymentsRepository) : IPaymentsService
{
    public async Task<PaymentResponse> RegisterPayment(PaymentRequest paymentDto)
    {
        var payment = paymentDto.ToDomain();
        var paymentCreated = await paymentsRepository.Create(payment);

        return new PaymentResponse(
            paymentCreated.Description,
            paymentCreated.PaymentType.ToString(),
            paymentCreated.PaymentValue,
            paymentCreated.PaymentDate
        );
    }

    public async Task<PaymentResponse> GetPayment(string id)
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
