using DesafioCarrefour.Application.Contracts;
using DesafioCarrefour.Application.Factories;
using DesafioCarrefour.Application.Objects;

namespace DesafioCarrefour.Application.UserCases.Balance;

public class BalanceService : IBalanceService
{
    private readonly IPaymentsRepository _paymentsRepository;

    public BalanceService(IPaymentsRepository paymentsRepository)
    {
        _paymentsRepository = paymentsRepository;
    }

    protected BalanceService() { }

    public async Task<BalanceResponse> CalculateConsolidatedBalance(DateTime referenceDate)
    {
        var paymentsToConsolidate = await _paymentsRepository.GetAllByDate(referenceDate);

        if (paymentsToConsolidate is null || paymentsToConsolidate.Count == 0)
            return new BalanceResponse { Balance = 0.0d }; ;

        var consolidatedBalance = paymentsToConsolidate.Sum(p => p.PaymentValue);

        return new BalanceResponse { Balance = consolidatedBalance };
    }
}
