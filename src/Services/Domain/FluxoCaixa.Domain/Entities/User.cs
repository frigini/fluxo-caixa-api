using System.Text.Json.Serialization;
using FluxoCaixa.Core.DomainObjects;

namespace FluxoCaixa.Domain.Entities;

public class User : Entity
{
    public string Username { get; set; }

    [JsonIgnore]
    public string Password { get; set; }
}
