using FileBaseContext.Abstractions.Models.FileSet;
using Shared.Models.Entities;

namespace Shared.DataAccess.Contexts;

public interface IDataContext
{

    ValueTask SaveChangesAsync();
}