using FileBaseContext.Abstractions.Models.Entity;
using FileBaseContext.Abstractions.Models.FileEntry;
using FileBaseContext.Abstractions.Models.FileSet;
using FileBaseContext.Context.Models.Configurations;
using FileBaseContext.Context.Models.FileContext;
using Shared.Models.Common;
using Shared.Models.Entities;

namespace Shared.DataAccess.Contexts;

public class AppFileContext : FileContext, IDataContext
{
    #region Accounts

    public IFileSet<User, Guid> Users => Set<User, Guid>(nameof(Users));

    public IFileSet<UserCredentials, Guid> UserCredentials => Set<UserCredentials, Guid>(nameof(UserCredentials));

    #endregion

    #region Contents

    public IFileSet<BlogPost, Guid> Posts => Set<BlogPost, Guid>(nameof(Posts));

    public IFileSet<PostDetails, Guid> PostDetails => Set<PostDetails, Guid>(nameof(PostDetails));

    public IFileSet<PostView, Guid> PostViews => Set<PostView, Guid>(nameof(PostViews));

    public IFileSet<PostFeedback, Guid> PostFeedbacks => Set<PostFeedback, Guid>(nameof(PostFeedbacks));

    public IFileSet<PostComment, Guid> PostComments => Set<PostComment, Guid>(nameof(PostComments));

    public IFileSet<PostShare, Guid> PostShares => Set<PostShare, Guid>(nameof(PostShares));

    #endregion

    #region Notifications

    public IFileSet<EmailTemplate, Guid> EmailTemplates => Set<EmailTemplate, Guid>(nameof(EmailTemplates));

    #endregion

    public AppFileContext(IFileContextOptions<AppFileContext> fileContextOptions) : base(fileContextOptions)
    {
        OnSaveChanges += AddPrimaryKeys;
        OnSaveChanges += AddAuditableDetails;
        OnSaveChanges += AddSoftDeletionDetails;
    }

    public ValueTask AddPrimaryKeys(IEnumerable<IFileSetBase> fileSets)
    {
        foreach (var fileSet in fileSets)
        foreach (var entry in fileSet.GetEntries())
        {
            if (entry is not IFileEntityEntry<IEntity> entityEntry) continue;

            if (entityEntry.State == FileEntityState.Added)
                entityEntry.Entity.Id = Guid.NewGuid();

            if (entry is not IFileEntityEntry<IFileSetEntity<Guid>> fileSetEntry) continue;
        }

        return new ValueTask(Task.CompletedTask);
    }

    public ValueTask AddAuditableDetails(IEnumerable<IFileSetBase> fileSets)
    {
        foreach (var fileSet in fileSets)
        foreach (var entry in fileSet.GetEntries())
        {
            if (entry is not IFileEntityEntry<IAuditableEntity> entityEntry) continue;

            if (entityEntry.State == FileEntityState.Added)
                entityEntry.Entity.CreatedDate = DateTimeOffset.Now;

            if (entityEntry.State == FileEntityState.Modified)
                entityEntry.Entity.ModifiedDate = DateTimeOffset.Now;

            if (entry is not IFileEntityEntry<IFileSetEntity<Guid>> fileSetEntry) continue;
        }

        return new ValueTask(Task.CompletedTask);
    }

    public ValueTask AddSoftDeletionDetails(IEnumerable<IFileSetBase> fileSets)
    {
        var hardDeletedEntities = new List<Type>()
        {
            typeof(PostView)
        };

        foreach (var fileSet in fileSets)
        foreach (var entry in fileSet.GetEntries())
        {
            // Skip entities that are not soft deletable
            if (entry is not IFileEntityEntry<ISoftDeletedEntity> { State: FileEntityState.Deleted } entityEntry) continue;

            // Skip hard deleted entities
            if (hardDeletedEntities.Contains(entityEntry.Entity.GetType())) continue;

            // Soft delete all entities except PostView
            entityEntry.Entity.IsDeleted = true;
            entityEntry.Entity.DeletedDate = DateTimeOffset.Now;
            entityEntry.State = FileEntityState.MarkedDeleted;
        }

        return new ValueTask(Task.CompletedTask);
    }

    public void Dispose()
    {
        // TODO release managed resources here
    }

    public ValueTask DisposeAsync()
    {
        return new ValueTask(Task.CompletedTask);
        // TODO release managed resources here
    }
}

public struct Test : IEntity
{
    public Guid Id { get; set; }
}