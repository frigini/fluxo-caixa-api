using System.Net;
using DesafioCarrefour.Application.UserCases.Balance;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DesafioCarrefour.WebApi.Controllers;

public class BalancesController(IBalanceService balanceService) : ApiController
{
    [Authorize]
    [HttpGet("[action]", Name = "listar-saldo-consolidado")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<ActionResult> GetPaymentsBalanceByDate([FromBody] DateTime referenceDate)
    {
        var response = await balanceService.CalculateConsolidatedBalance(referenceDate);

        return CustomResponse((int)HttpStatusCode.OK, true, response);
    }
}

