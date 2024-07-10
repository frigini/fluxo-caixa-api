using System.Net;
using FluxoCaixa.Application.UserCases.Balance;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FluxoCaixa.WebApi.Controllers;

public class BalancesController(IBalanceService balanceService) : ApiController
{
    //[Authorize]
    [HttpGet("listar-saldo-consolidado/{referenceDate}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<ActionResult> GetPaymentsBalanceByDate([FromBody] DateTime referenceDate)
    {
        var response = await balanceService.CalculateConsolidatedBalance(referenceDate);

        return CustomResponse((int)HttpStatusCode.OK, true, response);
    }
}

