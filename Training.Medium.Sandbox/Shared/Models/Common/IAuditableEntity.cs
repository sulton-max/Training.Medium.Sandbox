namespace Shared.Models.Common;

public interface IAuditableEntity : IEntity
{
    DateTimeOffset CreatedDate { get; set; }
    DateTimeOffset ModifiedDate { get; set; }
}