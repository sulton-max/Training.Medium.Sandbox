using System.Data;
using System.Reflection;
using FileContext.Abstractions.Models.Entity;
using FileContext.Abstractions.Models.FileSet;
using FileContext.Core.Models.FileSet;
using FileContext.Core.Services;
using Newtonsoft.Json;
using Shared.Extensions;
using Shared.Models.Common;
using Shared.Models.Entities;

namespace Shared.DataAccess.Contexts;

public class AppFileContext : IDataContext
{
    private readonly string _rootFolderPath;
    private readonly JsonSerializer _jsonSerializer = new JsonSerializer();
    private readonly IPluralizationProvider _pluralizationProvider = new HumanizerPluralizationProvider();
    private readonly List<IFileSet<IFileSetEntity<Guid>, Guid>> _fileSets;

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


    public AppFileContext(string rootFolderPath)
    {
        _rootFolderPath = rootFolderPath;

        // TODO : Fix to get strict typed filesets
        _fileSets = GetType()
            .GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .Where(fileSet => typeof(IFileSet<,>).IsAssignableFrom(fileSet.PropertyType))
            .Select(fileSet => fileSet.GetValue(this) ?? throw new EvaluateException("File set is not initialized"))
            .OfType<IFileSet<IFileSetEntity<Guid>, Guid>>()
            .ToList();
    }

    public virtual IFileSet<TEntity, TKey> Set<TEntity, TKey>() where TEntity : class, IFileSetEntity<TKey> where TKey : struct
    {
        return new FileSet<TEntity, TKey>(_rootFolderPath, _jsonSerializer, _pluralizationProvider);
    }

    public virtual async ValueTask FetchAsync()
    {
        // var fetchTasks = _fileSets.Select(fileSet => fileSet.FetchAsync());
        // await Task.WhenAll(fetchTasks.Select(fetchTask => fetchTask.AsTask()));

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
        // Call any save changes interceptors
        await OnSaveChanges(_fileSets);

        // Call save changes on each file set
        // var saveChangesTasks = _fileSets.Select(fileSet => fileSet.SaveChangesAsync());
        // await Task.WhenAll(saveChangesTasks.Select(saveChangesTask => saveChangesTask.AsTask()));

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

    public virtual ValueTask OnSaveChanges(List<IFileSet<IFileSetEntity<Guid>, Guid>> fileSets)
    {
        fileSets.ForEach(fileSet =>
        {
            if (fileSet is not IAuditableEntity auditableEntity) return;
            auditableEntity.CreatedDate = auditableEntity.CreatedDate == default ? DateTimeOffset.Now : auditableEntity.CreatedDate;
            auditableEntity.ModifiedDate = auditableEntity.ModifiedDate == new DateTimeOffset() ? DateTimeOffset.Now : auditableEntity.ModifiedDate;
        });

        return new ValueTask(Task.CompletedTask);
    }

    public ValueTask DisposeAsync()
    {
        return new ValueTask(Task.CompletedTask);
    }
}