using FluentAssertions;
using FluxoCaixa.Application.Contracts;
using FluxoCaixa.Application.UserCases.Balance;
using Moq;

namespace FluxoCaixa.Application.Tests.UserCases.Balance;

public class BalanceServiceTests
{
    private readonly Mock<IPaymentsRepository> _paymentsRepositoryMock;
    private readonly BalanceService _balanceService;

    public BalanceServiceTests()
    {
        _paymentsRepositoryMock = new Mock<IPaymentsRepository>();
        _balanceService = new(_paymentsRepositoryMock.Object);
    }

    [Fact]
    public async Task CalculateConsolidatedBalance_WithPayments_ShouldReturnCorrectBalances()
    { 
        // Arrange
        var referenceDate = DateTime.Now.Date;

        _paymentsRepositoryMock
            .Setup(repo => repo.GetAllByDate(referenceDate))
            .ReturnsAsync(
                [
                    new("credito", referenceDate, 1, 1000.00m),
                    new("primeiro debito", referenceDate, 0, 200.00m),
                    new("segundo debito", referenceDate, 0, 120.00m),
                    new("terceiro debito", referenceDate, 0, 350.00m),
                ]);

        // Act
        var result = await _balanceService.CalculateConsolidatedBalance(referenceDate);

        // Assert
        result.Should().NotBeNull();
        result.Date.Should().Be(referenceDate);
        result.ConsolidateBalance.Should().Be(330.0m);
        result.NegativeBalance.Should().Be(-670.0m);
        result.TotalBalance.Should().Be(1000.0m);
    }

    [Fact]
    public async Task CalculateConsolidatedBalance_NoPayments_ShouldReturnZeroBalances()
    {
        // Arrange
        var referenceDate = DateTime.Now.Date;

        _paymentsRepositoryMock
            .Setup(repo => repo.GetAllByDate(referenceDate))
            .ReturnsAsync([]);

        // Act
        var result = await _balanceService.CalculateConsolidatedBalance(referenceDate);

        // Assert
        result.Should().NotBeNull();
        result.Date.Should().Be(referenceDate);
        result.ConsolidateBalance.Should().Be(0.0m);
        result.NegativeBalance.Should().Be(0.0m);
        result.TotalBalance.Should().Be(0.0m);
    }
}
