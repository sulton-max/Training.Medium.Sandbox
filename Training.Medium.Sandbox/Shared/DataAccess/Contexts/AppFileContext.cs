using FileContext.Abstractions.Models.FileSet;
using FileContext.Core.Models.FileSet;
using FileContext.Core.Services;
using Newtonsoft.Json;
using Shared.Models.Common;
using Shared.Models.Entities;

namespace Shared.DataAccess.Contexts;

public class AppFileContext : IDataContext
{
    public IFileSet<PostComment, Guid> PostComments { get; }
    public IFileSet<User, Guid> Users { get; }
    public IFileSet<BlogPost, Guid> Posts { get; }
    public IFileSet<PostView, Guid> PostViews { get; }
    public IFileSet<UserCredentials, Guid> UserCredentials { get; }
    public IFileSet<EmailTemplate, Guid> EmailTemplates { get; }
    public IFileSet<BlogPostShare, Guid> PostShares { get; }
    public IFileSet<PostFeedback, Guid> PostFeedbacks { get; }

    public AppFileContext(string folderPath)
    {
        var serializer = new JsonSerializer();
        var provider = new HumanizerPluralizationProvider();

        PostComments = new FileSet<PostComment, Guid>(folderPath, serializer, provider);
        Users = new FileSet<User, Guid>(folderPath, serializer, provider);
        Posts = new FileSet<BlogPost, Guid>(folderPath, serializer, provider);
        PostViews = new FileSet<PostView, Guid>(folderPath, serializer, provider);
        UserCredentials = new FileSet<UserCredentials, Guid>(folderPath, serializer, provider);
        EmailTemplates = new FileSet<EmailTemplate, Guid>(folderPath, serializer, provider);
        PostShares = new FileSet<BlogPostShare, Guid>(folderPath, serializer, provider);
    }

    public virtual async ValueTask FetchAsync()
    {
        await PostComments.FetchAsync();
        await Users.FetchAsync();
        await Posts.FetchAsync();
        await PostViews.FetchAsync();
        await UserCredentials.FetchAsync();
        await PostShares.FetchAsync();
        await EmailTemplates.FetchAsync();
    }

    public virtual async ValueTask SaveChangesAsync()
    {
        await PostComments.SaveChangesAsync();
        await Users.SaveChangesAsync();
        await Posts.SaveChangesAsync();
        await PostViews.SaveChangesAsync();
        await UserCredentials.SaveChangesAsync();
        await PostShares.SaveChangesAsync();
        await EmailTemplates.SaveChangesAsync();
    }

    public ValueTask DisposeAsync()
    {
        return new ValueTask(Task.CompletedTask);
    }
}