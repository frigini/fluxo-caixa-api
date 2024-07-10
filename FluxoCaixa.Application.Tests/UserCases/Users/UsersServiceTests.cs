using FluentAssertions;
using FluxoCaixa.Application.Contracts;
using FluxoCaixa.Application.Objects.Requests;
using FluxoCaixa.Application.Objects.Responses;
using FluxoCaixa.Application.UserCases.Users;
using FluxoCaixa.Domain.Entities;
using Moq;

namespace FluxoCaixa.Application.Tests.UserCases.Users;

public class UsersServiceTests
{
    private readonly Mock<IUsersRepository> _usersRepositoryMock;
    private readonly UsersService _usersService;

    public UsersServiceTests()
    {
        _usersRepositoryMock = new Mock<IUsersRepository>();
        _usersService = new(_usersRepositoryMock.Object);
    }

    [Fact]
    public async Task AddUser_ShouldReturnUserResponse()
    {
        // Arrange
        var request = new AuthenticateRequest { Username = "testuser", Password = "password" };
        var user = new User(request.Username, request.Password);

        _usersRepositoryMock
            .Setup(repo => repo.AddAndUpdateUser(It.IsAny<User>()))
            .ReturnsAsync(user);


        // Act
        var result = await _usersService.AddUser(request);

        // Assert
        result.Should().NotBeNull();
        result.Username.Should().Be(request.Username);
    }

    [Fact]
    public async Task AuthenticateUser_ShouldReturnAuthenticateResponse()
    {
        // Arrange
        var username = "testuser";
        var password = "password";
        var user = new User(username, password);
        
        _usersRepositoryMock
            .Setup(repo => repo.AuthenticateUser(username, password))
            .ReturnsAsync(user);

        // Act
        var result = await _usersService.AuthenticateUser(username, password);

        // Assert
        result.Should().NotBeNull();
        result.Username.Should().Be(username);
    }

    [Fact]
    public async Task GetAll_ShouldReturnAllUsers()
    {
        // Arrange
        var users = new List<User>
            {
                new("testuser1", "password1"),
                new("testuser2", "password2")
            };

        _usersRepositoryMock
            .Setup(repo => repo.GetAll())
            .ReturnsAsync(users);

        // Act
        var result = await _usersService.GetAll();

        // Assert
        result.Should().HaveCount(2);
        result.Should().BeEquivalentTo(users.Select(u => new AuthenticateResponse
        {
            Id = u.Id,
            Username = u.Username
        }));
    }
}
