using System.Text.Json.Serialization;
using DesafioCarrefour.Core.DomainObjects;

namespace DesafioCarrefour.Domain.Entities;

public class User : Entity
{
    public string Username { get; set; }

    [JsonIgnore]
    public string Password { get; set; }
}
