using System.ComponentModel.DataAnnotations;

namespace DesafioCarrefour.Application.Objects.Requests;

public class AuthenticateRequest
{
    [Required]
    public string Username { get; set; }

    [Required]
    public string Password { get; set; }
}
