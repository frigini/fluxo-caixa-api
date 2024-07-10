using FluentAssertions;
using FluxoCaixa.Application.Contracts;
using FluxoCaixa.Application.Factories;
using FluxoCaixa.Application.Objects.Requests;
using FluxoCaixa.Application.Objects.Responses;
using FluxoCaixa.Application.UserCases.Payments;
using FluxoCaixa.Domain.Entities;
using FluxoCaixa.Domain.Entities.Enums;
using Moq;

namespace FluxoCaixa.Application.Tests.UserCases.Payments;

public class PaymentServiceTests
{
    private readonly Mock<IPaymentsRepository> _paymentsRepositoryMock;
    private readonly PaymentsService _paymentsService;

    public PaymentServiceTests()
    {
        _paymentsRepositoryMock = new Mock<IPaymentsRepository>();
        _paymentsService = new(_paymentsRepositoryMock.Object);
    }

    [Fact]
    public async Task RegisterPayment_ShouldReturnPaymentResponse()
    {
        // Arrange
        var paymentRequest = GetValidPaymentRequest();
        var payment = paymentRequest.ToDomain();

        _paymentsRepositoryMock
                    .Setup(repo => repo.Create(It.IsAny<Payment>()))
                    .ReturnsAsync(payment);

        // Act
        var result = await _paymentsService.RegisterPayment(paymentRequest);

        // Assert
        result.Should().NotBeNull();
        result.Description.Should().Be(paymentRequest.Description);
        result.PaymentDate.Should().Be(paymentRequest.PaymentDate);
        result.PaymentType.Should().Be(((PaymentTypeEnum)paymentRequest.PaymentType).ToString());
        result.PaymentValue.Should().Be(paymentRequest.PaymentValue);
    }

    [Fact]
    public async Task GetPayment_ShouldReturnPaymentResponse()
    {
        // Arrange
        var paymentId = Guid.NewGuid();
        var payment = new Payment("Pagamento", DateTime.Now, 1, 150.00m);

        _paymentsRepositoryMock
            .Setup(repo => repo.Get(paymentId))
            .ReturnsAsync(payment);

        // Act
        var result = await _paymentsService.GetPayment(paymentId);

        // Assert
        result.Should().NotBeNull();
        result.Description.Should().Be(payment.Description);
        result.PaymentDate.Should().Be(payment.PaymentDate);
        result.PaymentType.Should().Be(payment.PaymentType.ToString());
        result.PaymentValue.Should().Be(payment.PaymentValue);
    }

    [Fact]
    public async Task GetAll_ShouldReturnAllPayments()
    {
        // Arrange
        var payments = new List<Payment>
            {
                new("Pagamento1", DateTime.Now, 1, 100.00m),
                new("Pagamento2", DateTime.Now, 0, 200.00m)
            };

        _paymentsRepositoryMock
            .Setup(repo => repo.GetAll())
            .ReturnsAsync(payments);

        // Act
        var result = await _paymentsService.GetAll();

        // Assert
        result.Should().HaveCount(2);
        result.Should().BeEquivalentTo(payments.Select(p => new PaymentResponse(
            p.Description,
            p.PaymentType.ToString(),
            p.PaymentValue,
            p.PaymentDate
        )));
    }

    [Fact]
    public async Task GetPaymentsByDate_ShouldReturnPaymentsByDate()
    {
        // Arrange
        var referenceDate = DateTime.Now;
        var payments = new List<Payment>
            {
                new("Pagamento1", referenceDate, 1, 100.00m),
                new("Pagamento2", referenceDate, 0, 200.00m)
            };

        _paymentsRepositoryMock
            .Setup(repo => repo.GetAllByDate(referenceDate))
            .ReturnsAsync(payments);

        // Act
        var result = await _paymentsService.GetPaymentsByDate(referenceDate);

        // Assert
        result.Should().HaveCount(2);
        result.Should().BeEquivalentTo(payments.Select(p => new PaymentResponse(
            p.Description,
            p.PaymentType.ToString(),
            p.PaymentValue,
            p.PaymentDate
        )));
    }

    private static PaymentRequest GetValidPaymentRequest() => new()
    {
        Description = "Credito",
        PaymentDate = DateTime.Now,
        PaymentType = 1,
        PaymentValue = 150.00m
    };
}
