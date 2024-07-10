namespace FluxoCaixa.Application.Objects.Responses
{
    public class PaymentResponse(string description, string paymentType, decimal paymentValue, DateTime paymentDate)
    {
        public string Description { get; set; } = description;
        public string PaymentType { get; set; } = paymentType;
        public decimal PaymentValue { get; set; } = paymentValue;
        public DateTime PaymentDate { get; set; } = paymentDate;
    }
}
