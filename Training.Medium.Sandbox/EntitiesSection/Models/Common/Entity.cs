namespace EntitiesSection.Models.Common;
public abstract class Entity : IEntity
{
    public Guid Id { get; set; }
}