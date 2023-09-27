using FileBaseContext.Abstractions.Models.Entity;
using FileBaseContext.Abstractions.Models.FileContext;
using FileBaseContext.Abstractions.Models.FileSet;
using FileBaseContext.Context.Models.Configurations;
using FileBaseContext.Context.Models.FileContext;
using Shared.Models.Common;
using Shared.Models.Entities;

namespace Shared.DataAccess.Contexts;

public class AppFileContext : FileContext, IDataContext
{
    public virtual ValueTask AddPrimaryKeys(IEnumerable<IFileSetBase> fileSets)
    {
        foreach (var fileSetBase in fileSets)
        {
            if (fileSetBase is not IFileSet<IFileSetEntity<Guid>, Guid> fileSet) continue;

            foreach (var entry in fileSet.Where(entry => entry.Id == default))
                entry.Id = Guid.NewGuid();
        }

        return new ValueTask(Task.CompletedTask);
    }

    public virtual ValueTask AddAuditableDetails(IEnumerable<IFileSetBase> fileSets)
    {
        foreach (var fileSetBase in fileSets)
        {
            if (fileSetBase is not IFileSet<IAuditableEntity, Guid> fileSet) continue;

            foreach (var entry in fileSet)
                // .Where(entry => entry.State == State.Updated))
            {
                entry.ModifiedDate = DateTimeOffset.Now;
            }

            // entry.Id = Guid.NewGuid();
        }

        return new ValueTask(Task.CompletedTask);
    }

    public ValueTask DisposeAsync()
    {
        return new ValueTask(Task.CompletedTask);
    }

    public AppFileContext(IFileContextOptions<IFileContext> fileContextOptions) : base(fileContextOptions)
    {
        OnSaveChanges += AddPrimaryKeys;
    }


}