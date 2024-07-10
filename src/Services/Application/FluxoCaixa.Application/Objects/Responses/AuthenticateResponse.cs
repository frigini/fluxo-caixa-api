namespace FluxoCaixa.Application.Objects.Responses;

public class AuthenticateResponse
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string Token { get; set; }
}
