using System.Data;

namespace EntitiesSection.Models.Common;


public abstract class AuditableEntity : Entity, IAuditableEntity
{
    public DateTimeOffset CreatedDate { get; set; }
    public DateTimeOffset ModifiedDate { get; set; }
}