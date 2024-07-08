using System.Net;
using DesafioCarrefour.Application.Contracts;
using DesafioCarrefour.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DesafioCarrefour.WebApi.Controllers;

public class PaymentsController : ApiController
{
    private readonly IPaymentsRepository _paymentsRepository;

    public PaymentsController(IPaymentsRepository paymentsRepository)
    {
        _paymentsRepository = paymentsRepository;
    }

    [HttpGet("[action]", Name = "listar-saldo-consolidado")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<ActionResult> GetPaymentsByDate([FromBody] DateTime referenceDate)
    {
        var response = await _paymentsRepository.GetAllByDate(referenceDate);

        if (response is null || response.Count == 0)
            return CustomResponse((int)HttpStatusCode.NotFound, false);

        return CustomResponse((int)HttpStatusCode.OK, true, response);
    }

    [HttpPost("cadastrar-pagamento")]
    [ProducesResponseType((int)HttpStatusCode.Created)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<ActionResult> RegisterPayment([FromBody] Payment payment)
    {
        var response = await _paymentsRepository.Create(payment);

        if (response is null)
            return CustomResponse((int)HttpStatusCode.BadRequest, false);

        return CustomResponse((int)HttpStatusCode.Created, true, response);
    }
}

