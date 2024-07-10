using FluentAssertions;
using FluxoCaixa.Core.DomainObjects;
using FluxoCaixa.Domain.Entities;
using FluxoCaixa.Domain.Entities.Enums;

namespace FluxoCaixa.Domain.Tests;

public class PaymentTests
{
    [Fact]
    public void Constructor_ValidParameters_ShouldCreatePayment()
    {
        // Arrange
        string description = "Pagamento";
        DateTime paymentDate = DateTime.Now;
        int paymentType = 1;
        decimal paymentValue = 150.00m;

        // Act
        var payment = new Payment(description, paymentDate, paymentType, paymentValue);

        // Assert
        payment.Description.Should().Be(description);
        payment.PaymentDate.Should().Be(paymentDate);
        payment.PaymentType.Should().Be(PaymentTypeEnum.Credito);
        payment.PaymentValue.Should().Be(paymentValue);
    }

    [Fact]
    public void UpdateDescription_ValidDescription_ShouldUpdateDescription()
    {
        // Arrange
        string validDescription = "Pagamento valido";
        var payment = new Payment(validDescription,DateTime.Now,0,0.0m);

        // Act
        payment.UpdateDescription(validDescription);

        // Assert
        payment.Description.Should().Be(validDescription);
        payment.UpdatedAt.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(1));
    }

    [Fact]
    public void UpdateDescription_InvalidDescription_ShouldThrowDomainException()
    {
        // Arrange
        string invalidDescription = "Invalid@Description%^$";

        // Act
        Action act = () => new Payment(invalidDescription, DateTime.Now, 0, 0.0m);

        // Assert
        act.Should().Throw<DomainException>().WithMessage("Invalid description for payment.");
    }

    [Fact]
    public void UpdatePaymentDate_ValidDate_ShouldUpdatePaymentDate()
    {
        // Arrange
        DateTime validDate = DateTime.Now;
        var payment = new Payment("teste", validDate, 0, 0.0m);

        // Act
        payment.UpdatePaymentDate(validDate);

        // Assert
        payment.PaymentDate.Should().Be(validDate);
        payment.UpdatedAt.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(1));
    }

    [Fact]
    public void UpdatePaymentDate_FutureDate_ShouldThrowDomainException()
    {
        // Arrange
        DateTime futureDate = DateTime.Now.AddDays(1);

        // Act
        Action act = () => new Payment("teste", futureDate, 0, 0.0m);

        // Assert
        act.Should().Throw<DomainException>().WithMessage("Invalid payment date.");
    }

    [Fact]
    public void UpdatePaymentType_ValidType_ShouldUpdatePaymentType()
    {
        // Arrange
        int validType = 0; // Debito
        var payment = new Payment("teste", DateTime.Now, validType, 0.0m);

        // Act
        payment.UpdatePaymentType(validType);

        // Assert
        payment.PaymentType.Should().Be(PaymentTypeEnum.Debito);
        payment.UpdatedAt.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(1));
    }

    [Fact]
    public void UpdatePaymentType_InvalidType_ShouldThrowDomainException()
    {
        // Arrange
        int invalidType = 3;

        // Act
        Action act = () => new Payment("teste", DateTime.Now, invalidType, 0.0m);

        // Assert
        act.Should().Throw<DomainException>().WithMessage("Invalid payment type.");
    }

    [Fact]
    public void UpdatePaymentValue_ValidValue_ShouldUpdatePaymentValue()
    {
        // Arrange
        decimal validValue = 100.00m;
        var payment = new Payment("teste", DateTime.Now, 0, validValue);

        // Act
        payment.UpdatePaymentValue(validValue);

        // Assert
        payment.PaymentValue.Should().Be(validValue);
        payment.UpdatedAt.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(1));
    }

    [Fact]
    public void UpdatePaymentValue_NegativeValue_ShouldThrowDomainException()
    {
        // Arrange
        decimal invalidValue = -100.00m;

        // Act
        Action act = () => new Payment("teste", DateTime.Now, 0, invalidValue);

        // Assert
        act.Should().Throw<DomainException>().WithMessage("Invalid payment value, value must be greater than zero.");
    }
}


