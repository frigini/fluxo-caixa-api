using DesafioCarrefour.Application.Objects;

namespace DesafioCarrefour.Application.UserCases.Balance;

public interface IBalanceService
{
    Task<BalanceResponse> CalculateConsolidatedBalance(DateTime referenceDate);
}
