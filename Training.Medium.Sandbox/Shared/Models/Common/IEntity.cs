using FileContext.Abstractions.Models.Entity;

namespace Shared.Models.Common;

public interface IEntity : IFileSetEntity<Guid>
{
}