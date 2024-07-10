namespace FluxoCaixa.Application.Objects.Responses;

public class UserResponse(Guid id, string username)
{
    public Guid Id { get; set; } = id;
    public string Username { get; set; } = username;
}
