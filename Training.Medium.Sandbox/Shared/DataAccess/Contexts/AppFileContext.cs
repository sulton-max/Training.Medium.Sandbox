using FileContext.Abstractions.Models.FileSet;
using FileContext.Core.Models.FileSet;
using FileContext.Core.Services;
using Newtonsoft.Json;
using Shared.Models.Common;
using Shared.Models.Entities;

namespace Shared.DataAccess.Contexts;

public abstract class AppFileContext
{
    public readonly IFileSet<User, Guid> Users;
    public readonly IFileSet<BlogPost, Guid> Posts;
    public readonly IFileSet<PostView, Guid> PostViews;

    public AppFileContext(string folderPath)
    {
        var serializer = new JsonSerializer();
        var provider = new HumanizerPluralizationProvider();

        Users = new FileSet<User, Guid>(folderPath, serializer, provider);
        Posts = new FileSet<BlogPost, Guid>(folderPath, serializer, provider);
        PostViews = new FileSet<PostView, Guid>(folderPath, serializer, provider);
    }

    public virtual async ValueTask FetchAsync()
    {
        await Users.FetchAsync();
        await Posts.FetchAsync();
        await PostViews.FetchAsync();
    }

    public virtual async ValueTask SaveChangesAsync()
    {
        await Users.SaveChangesAsync();
        await Posts.SaveChangesAsync();
        await PostViews.SaveChangesAsync();
    }
}