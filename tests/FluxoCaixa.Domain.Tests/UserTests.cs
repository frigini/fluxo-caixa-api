using FluxoCaixa.Domain.Entities;
using FluentAssertions;

namespace FluxoCaixa.Domain.Tests;

public class UserTests
{
    [Fact]
    public void Constructor_ValidParameters_ShouldCreatePayment()
    {
        // Arrange
        string username = "admin";
        string password = "admin";

        // Act
        var user = new User(username, password);

        // Assert
        user.Username.Should().Be(username);
        user.Password.Should().Be(password);
    }
}
