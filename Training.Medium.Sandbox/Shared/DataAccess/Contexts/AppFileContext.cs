using FileContext.Abstractions.Models.Entity;
using FileContext.Abstractions.Models.FileSet;
using FileContext.Core.Models.FileSet;
using FileContext.Core.Services;
using Newtonsoft.Json;
using Shared.Models.Entities;

namespace Shared.DataAccess.Contexts;

public class AppFileContext : IDataContext
{
    private readonly string _folderPath;
    private readonly JsonSerializer _jsonSerializer = new JsonSerializer();
    private readonly IPluralizationProvider _pluralizationProvider = new HumanizerPluralizationProvider();

    #region Accounts

    public IFileSet<User, Guid> Users => Set<User, Guid>();

    public IFileSet<UserCredentials, Guid> UserCredentials => Set<UserCredentials, Guid>();

    #endregion

    #region Contents

    public IFileSet<BlogPost, Guid> Posts => Set<BlogPost, Guid>();

    public IFileSet<PostDetails, Guid> PostDetails => Set<PostDetails, Guid>();

    public IFileSet<PostView, Guid> PostViews => Set<PostView, Guid>();

    public IFileSet<PostFeedback, Guid> PostFeedbacks => Set<PostFeedback, Guid>();

    public IFileSet<PostComment, Guid> PostComments => Set<PostComment, Guid>();

    public IFileSet<PostShare, Guid> PostShares => Set<PostShare, Guid>();

    #endregion

    #region Notifications

    public IFileSet<EmailTemplate, Guid> EmailTemplates => Set<EmailTemplate, Guid>();

    #endregion


    public AppFileContext(string folderPath)
    {
    }

    public virtual IFileSet<TEntity, TKey> Set<TEntity, TKey>() where TEntity : class, IFileSetEntity<TKey> where TKey : struct
    {
        return new FileSet<TEntity, TKey>(_folderPath, _jsonSerializer, _pluralizationProvider);
    }

    public virtual async ValueTask FetchAsync()
    {
        await Users.FetchAsync();
        await UserCredentials.FetchAsync();

        await Posts.FetchAsync();
        await PostDetails.FetchAsync();
        await PostViews.FetchAsync();
        await PostFeedbacks.FetchAsync();
        await PostComments.FetchAsync();
        await PostShares.FetchAsync();

        await EmailTemplates.FetchAsync();
    }

    public virtual async ValueTask SaveChangesAsync()
    {
        await Users.SaveChangesAsync();
        await UserCredentials.SaveChangesAsync();

        await Posts.SaveChangesAsync();
        await PostDetails.SaveChangesAsync();
        await PostViews.SaveChangesAsync();
        await PostFeedbacks.SaveChangesAsync();
        await PostComments.SaveChangesAsync();
        await PostShares.SaveChangesAsync();

        await EmailTemplates.SaveChangesAsync();
    }

    public virtual async ValueTask OnSaveChanges()
    {
    }

    public ValueTask DisposeAsync()
    {
        return new ValueTask(Task.CompletedTask);
    }
}