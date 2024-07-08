﻿using DesafioCarrefour.Application.Contracts;
using DesafioCarrefour.Application.Objects.Responses;

namespace DesafioCarrefour.Application.UserCases.Balance;

public class BalanceService(IPaymentsRepository paymentsRepository) : IBalanceService
{
    public async Task<BalanceResponse> CalculateConsolidatedBalance(DateTime referenceDate)
    {
        var paymentsToConsolidate = await paymentsRepository.GetAllByDate(referenceDate);

        if (paymentsToConsolidate is null || paymentsToConsolidate.Count == 0)
            return new BalanceResponse { Balance = 0.0d }; ;

        var consolidatedBalance = paymentsToConsolidate.Sum(p => p.PaymentValue);

        return new BalanceResponse { Balance = consolidatedBalance };
    }
}
