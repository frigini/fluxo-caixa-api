using FluxoCaixa.Application.Objects.Requests;
using FluxoCaixa.Application.Objects.Responses;
using FluxoCaixa.Application.UserCases.Payments;
using FluxoCaixa.WebApi.Setup;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FluxoCaixa.WebApi.Controllers;

[Authorize]
public class PaymentsController(IPaymentsService paymentsService) : ApiController
{
    [HttpPost("lancar-pagamento")]
    [ProducesResponseType(typeof(PaymentResponse), (int)HttpStatusCode.Created)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<ActionResult> RegisterPayment([FromBody] PaymentRequest paymentRequest)
    {
        var response = await paymentsService.RegisterPayment(paymentRequest);

        if (response is null)
            return CustomResponse((int)HttpStatusCode.BadRequest, false);

        return CustomResponse((int)HttpStatusCode.Created, true, response);
    }

    [HttpGet("buscar-lancamento/{id}")]
    [ProducesResponseType(typeof(PaymentResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<ActionResult> GetPayment([FromBody] Guid id)
    {
        var response = await paymentsService.GetPayment(id);

        if (response is null)
            return CustomResponse((int)HttpStatusCode.NotFound, false);

        return CustomResponse((int)HttpStatusCode.OK, true, response);
    }

    [HttpGet("listar-lancamentos")]
    [ProducesResponseType(typeof(List<PaymentResponse>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<ActionResult> GetPayments()
    {
        var response = await paymentsService.GetAll();

        if (response is null || !response.Any())
            return CustomResponse((int)HttpStatusCode.NotFound, false);

        return CustomResponse((int)HttpStatusCode.OK, true, response);
    }

    [HttpGet("listar-lancamentos-por-data/{referenceDate}")]
    [ProducesResponseType(typeof(List<PaymentResponse>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<ActionResult> GetPaymentsByDate([FromBody] DateTime referenceDate)
    {
        var response = await paymentsService.GetPaymentsByDate(referenceDate);

        if (response is null || !response.Any())
            return CustomResponse((int)HttpStatusCode.BadRequest, false);

        return CustomResponse((int)HttpStatusCode.OK, true, response);
    }
}

