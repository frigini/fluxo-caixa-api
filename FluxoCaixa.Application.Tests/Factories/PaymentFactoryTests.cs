using FluxoCaixa.Application.Objects.Requests;
using FluxoCaixa.Application.Factories;
using FluentAssertions;
using FluxoCaixa.Domain.Entities.Enums;
using FluxoCaixa.Domain.Entities;

namespace FluxoCaixa.Application.Tests.Factories;

public class PaymentFactoryTests
{ 
    [Fact]
    public void ToDomain_ShouldConvertPaymentRequestToPayment()
    {
        // Arrange
        var paymentRequest = new PaymentRequest
        {
            Description = "Pagamento",
            PaymentDate = DateTime.Now,
            PaymentType = 1,
            PaymentValue = 150.00m
        };

        // Act
        var payment = paymentRequest.ToDomain();

        // Assert
        payment.Should().NotBeNull();
        payment.Description.Should().Be(paymentRequest.Description);
        payment.PaymentDate.Should().Be(paymentRequest.PaymentDate);
        payment.PaymentType.Should().Be(PaymentTypeEnum.Credito);
        payment.PaymentValue.Should().Be(paymentRequest.PaymentValue);
    }

    [Fact]
    public void ToResponse_ShouldConvertPaymentToPaymentResponse()
    {
        // Arrange
        var payment = new Payment
        (
            "Pagamento",
            DateTime.Now,
            1,
            150.00m
        );

        // Act
        var paymentResponse = payment.ToResponse();

        // Assert
        paymentResponse.Should().NotBeNull();
        paymentResponse.Description.Should().Be(payment.Description);
        paymentResponse.PaymentDate.Should().Be(payment.PaymentDate);
        paymentResponse.PaymentType.Should().Be(payment.PaymentType.ToString());
        paymentResponse.PaymentValue.Should().Be(payment.PaymentValue);
    }

    [Fact]
    public void ToResponse_ShouldConvertPaymentListToPaymentResponseList()
    {
        // Arrange
        var payments = new List<Payment>
            {
                new("primeiro pagamento1", DateTime.Now, 1, 100.00m),
                new("segundo pagamento", DateTime.Now, 0, 200.00m)
            };

        // Act
        var paymentResponses = payments.ToResponse();

        // Assert
        paymentResponses.Should().NotBeNull();
        paymentResponses.Should().HaveCount(2);

        paymentResponses.ElementAt(0).Description.Should().Be("primeiro pagamento1");
        paymentResponses.ElementAt(0).PaymentType.Should().Be(PaymentTypeEnum.Credito.ToString());
        paymentResponses.ElementAt(0).PaymentValue.Should().Be(100.00m);

        paymentResponses.ElementAt(1).Description.Should().Be("segundo pagamento");
        paymentResponses.ElementAt(1).PaymentType.Should().Be(PaymentTypeEnum.Debito.ToString());
        paymentResponses.ElementAt(1).PaymentValue.Should().Be(200.00m);
    }
}
