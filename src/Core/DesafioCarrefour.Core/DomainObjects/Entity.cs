using MongoDB.Bson.Serialization.Attributes;

namespace DesafioCarrefour.Core.DomainObjects;

public class Entity
{
    public Entity() 
    {
        Id = Guid.NewGuid().ToString();
        CreatedAt = DateTime.Now;
    }

    [BsonId]
    public string Id { get; }
    public DateTime CreatedAt { get; protected set; }
    public DateTime UpdatedAt { get; protected set; }
    public DateTime? DeletedAt { get; protected set; }
}