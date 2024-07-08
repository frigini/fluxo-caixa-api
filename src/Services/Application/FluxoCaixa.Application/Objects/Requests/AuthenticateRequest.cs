using System.ComponentModel.DataAnnotations;

namespace FluxoCaixa.Application.Objects.Requests;

public class AuthenticateRequest
{
    [Required]
    public string Username { get; set; }

    [Required]
    public string Password { get; set; }
}
