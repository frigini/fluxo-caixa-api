using System.Text.Json.Serialization;
using FluxoCaixa.Core.DomainObjects;

namespace FluxoCaixa.Domain.Entities;

public class User(string username, string password) : Entity
{
    public string Username { get; set; } = username;

    [JsonIgnore]
    public string Password { get; set; } = password;
}
