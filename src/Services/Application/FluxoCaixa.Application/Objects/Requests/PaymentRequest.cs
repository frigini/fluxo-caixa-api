using FluxoCaixa.Domain.Entities.Enums;

namespace FluxoCaixa.Application.Objects.Requests;

public class PaymentRequest
{

    public string Description { get; set; }
    public DateTime PaymentDate { get; set; }
    public int PaymentType { get; set; }
    public decimal PaymentValue { get; set; }
}
