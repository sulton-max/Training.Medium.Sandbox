using FileContext.Abstractions.Models.FileSet;
using FileContext.Core.Models.FileSet;
using FileContext.Core.Services;
using Newtonsoft.Json;
using Shared.Models.Common;
using Shared.Models.Entities;

namespace Shared.DataAccess.Contexts;

public class AppFileContext : IDataContext
{
    public IFileSet<User, Guid> Users { get; }
    public IFileSet<BlogPost, Guid> Posts { get; }
    public IFileSet<PostView, Guid> PostViews { get; }
    public IFileSet<UserCredentials, Guid> UserCredentials { get; }
    public readonly IFileSet<BlogPostShare, Guid> Sharings;

    public AppFileContext(string folderPath)
    {
        var serializer = new JsonSerializer();
        var provider = new HumanizerPluralizationProvider();

        Users = new FileSet<User, Guid>(folderPath, serializer, provider);
        Posts = new FileSet<BlogPost, Guid>(folderPath, serializer, provider);
        PostViews = new FileSet<PostView, Guid>(folderPath, serializer, provider);
        UserCredentials = new FileSet<UserCredentials, Guid>(folderPath, serializer, provider);
        Sharings = new FileSet<BlogPostShare, Guid>(folderPath, serializer, provider);
    }

    public virtual async ValueTask FetchAsync()
    {
        await Users.FetchAsync();
        await Posts.FetchAsync();
        await PostViews.FetchAsync();
        await UserCredentials.FetchAsync();
        await Sharings.FetchAsync();
    }

    public virtual async ValueTask SaveChangesAsync()
    {
        await Users.SaveChangesAsync();
        await Posts.SaveChangesAsync();
        await PostViews.SaveChangesAsync();
        await UserCredentials.SaveChangesAsync();
        await Sharings.SaveChangesAsync();
    }

    public ValueTask DisposeAsync()
    {
        return new ValueTask(Task.CompletedTask);
    }
}