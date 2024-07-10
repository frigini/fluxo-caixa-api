using System.Net;
using FluxoCaixa.Application.UserCases.Balance;
using FluxoCaixa.WebApi.Setup;
using Microsoft.AspNetCore.Mvc;

namespace FluxoCaixa.WebApi.Controllers;

[Authorize]
public class BalancesController(IBalanceService balanceService) : ApiController
{
    [HttpGet("listar-saldo-consolidado/{referenceDate}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<ActionResult> GetPaymentsBalanceByDate([FromBody] DateTime referenceDate)
    {
        var response = await balanceService.CalculateConsolidatedBalance(referenceDate);

        return CustomResponse((int)HttpStatusCode.OK, true, response);
    }
}

