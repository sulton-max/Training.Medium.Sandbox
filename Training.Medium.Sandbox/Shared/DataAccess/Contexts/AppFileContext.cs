using FileBaseContext.Abstractions.Models.Entity;
using FileBaseContext.Abstractions.Models.FileSet;
using FileBaseContext.Context.Models.Configurations;
using FileBaseContext.Context.Models.FileContext;
using Shared.Models.Entities;

namespace Shared.DataAccess.Contexts;

public class AppFileContext : FileContext, IDataContext
{
    #region Accounts

    public IFileSet<User, Guid> Users => Set<User>(nameof(Users));

    public IFileSet<UserCredentials, Guid> UserCredentials => Set<UserCredentials>(nameof(UserCredentials));

    #endregion

    #region Contents

    public IFileSet<BlogPost, Guid> Posts => Set<BlogPost>(nameof(Posts));

    public IFileSet<PostDetails, Guid> PostDetails => Set<PostDetails>(nameof(PostDetails));

    public IFileSet<PostView, Guid> PostViews => Set<PostView>(nameof(PostViews));

    public IFileSet<PostFeedback, Guid> PostFeedbacks => Set<PostFeedback>(nameof(PostFeedbacks));

    public IFileSet<PostComment, Guid> PostComments => Set<PostComment>(nameof(PostComments));

    public IFileSet<PostShare, Guid> PostShares => Set<PostShare>(nameof(PostShares));

    #endregion

    #region Notifications

    public IFileSet<EmailTemplate, Guid> EmailTemplates => Set<EmailTemplate>(nameof(EmailTemplates));

    #endregion

    public AppFileContext(IFileContextOptions<AppFileContext> fileContextOptions) : base(fileContextOptions)
    {
        OnSaveChanges += AddPrimaryKeys;
    }

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
    
    public ValueTask DisposeAsync()
    {
        return new ValueTask(Task.CompletedTask);
    }
}