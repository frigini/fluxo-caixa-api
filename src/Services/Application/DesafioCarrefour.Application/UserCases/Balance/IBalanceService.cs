using DesafioCarrefour.Application.Objects.Responses;

namespace DesafioCarrefour.Application.UserCases.Balance;

public interface IBalanceService
{
    Task<BalanceResponse> CalculateConsolidatedBalance(DateTime referenceDate);
}
