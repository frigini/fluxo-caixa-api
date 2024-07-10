using FluxoCaixa.Application.Contracts;
using FluxoCaixa.Application.Objects.Responses;
using FluxoCaixa.Domain.Entities;
using FluxoCaixa.Domain.Entities.Enums;

namespace FluxoCaixa.Application.UserCases.Balance;

public class BalanceService(IPaymentsRepository paymentsRepository) : IBalanceService
{
    public async Task<BalanceResponse> CalculateConsolidatedBalance(DateTime referenceDate)
    {
        var paymentsToConsolidate = await paymentsRepository.GetAllByDate(referenceDate);

        if (paymentsToConsolidate is null || !paymentsToConsolidate.Any())
            return new BalanceResponse(referenceDate, 0.0m, 0.0m, 0.0m);

        var debits = Calculate(paymentsToConsolidate, PaymentTypeEnum.Debito);
        var credits = Calculate(paymentsToConsolidate, PaymentTypeEnum.Credito);

        var consolidatedBalance = credits - debits;

        return new BalanceResponse(referenceDate, consolidatedBalance, -debits, credits);
    }

    private static decimal Calculate(IEnumerable<Payment> payments, PaymentTypeEnum type)
    {
        return payments
            .Where(p => p.PaymentType == type)
            .Select(p => p.PaymentValue)
            .DefaultIfEmpty(0.0m)
            .Sum();
    }
}