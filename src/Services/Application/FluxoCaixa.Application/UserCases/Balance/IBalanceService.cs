using FluxoCaixa.Application.Objects.Responses;

namespace FluxoCaixa.Application.UserCases.Balance;

public interface IBalanceService
{
    Task<BalanceResponse> CalculateConsolidatedBalance(DateTime referenceDate);
}
