using System.Net;
using DesafioCarrefour.Application.Objects;
using DesafioCarrefour.Application.UserCases.Payments;
using Microsoft.AspNetCore.Mvc;

namespace DesafioCarrefour.WebApi.Controllers;

public class PaymentsController(IPaymentsService paymentsService) : ApiController
{
    [HttpPost("lancar-pagamento")]
    [ProducesResponseType(typeof(PaymentResponse), (int)HttpStatusCode.Created)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<ActionResult> RegisterPayment([FromBody] PaymentDto paymentDto)
    {
        var response = await paymentsService.RegisterPayment(paymentDto);

        if (response is null)
            return CustomResponse((int)HttpStatusCode.BadRequest, false);

        return CustomResponse((int)HttpStatusCode.Created, true, response);
    }

    [HttpGet("[action]/{id}", Name = "buscar-lancamento")]
    [ProducesResponseType(typeof(PaymentResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<ActionResult> GetPayment([FromBody] string id)
    {
        var response = await paymentsService.GetPayment(id);

        if (response is null)
            return CustomResponse((int)HttpStatusCode.NotFound, false);

        return CustomResponse((int)HttpStatusCode.OK, true, response);
    }

    [HttpGet("[action]", Name = "listar-lancamentos")]
    [ProducesResponseType(typeof(PaymentResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<ActionResult> GetPayments()
    {
        var response = await paymentsService.GetAll();

        if (response is null || response.Count == 0)
            return CustomResponse((int)HttpStatusCode.NotFound, false);

        return CustomResponse((int)HttpStatusCode.OK, true, response);
    }

    [HttpGet("[action]/{referenceDate}", Name = "listar-lancamentos-por-data")]
    [ProducesResponseType(typeof(PaymentResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<ActionResult> GetPaymentsByDate([FromBody] DateTime referenceDate)
    {
        var response = await paymentsService.GetPaymentsByDate(referenceDate);

        if (response is null || response.Count == 0)
            return CustomResponse((int)HttpStatusCode.BadRequest, false);

        return CustomResponse((int)HttpStatusCode.OK, true, response);
    }
}

