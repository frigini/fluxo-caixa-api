using DesafioCarrefour.Application.Contracts;
using DesafioCarrefour.Application.Factories;
using DesafioCarrefour.Application.Objects;

namespace DesafioCarrefour.Application.UserCases.Payments;

public class PaymentsService : IPaymentsService
{
    private readonly IPaymentsRepository _paymentsRepository;

    public PaymentsService(IPaymentsRepository paymentsRepository)
    {
        _paymentsRepository = paymentsRepository;
    }

    protected PaymentsService() { }

    public async Task<PaymentResponse> RegisterPayment(PaymentDto paymentDto)
    {
        var payment = paymentDto.ToDomain();
        var paymentCreated = await _paymentsRepository.Create(payment);

        return new PaymentResponse(
            paymentCreated.Description,
            paymentCreated.PaymentType.ToString(),
            paymentCreated.PaymentValue,
            paymentCreated.PaymentDate
        );
    }

    public async Task<PaymentResponse> GetPayment(string id)
    {
        var payment = await _paymentsRepository.Get(id);

        return payment.ToResponse();
    }

    public async Task<List<PaymentResponse>> GetAll()
    {
        var payments = await _paymentsRepository.GetAll();

        return payments.ToResponse();
    }

    public async Task<List<PaymentResponse>> GetPaymentsByDate(DateTime referenceDate)
    {
        var payments = await _paymentsRepository.GetAllByDate(referenceDate);

        return payments.ToResponse();
    }
}
