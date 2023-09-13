using FileContext.Abstractions.Models.FileSet;
using FileContext.Core.Models.FileSet;
using FileContext.Core.Services;
using Newtonsoft.Json;
using Shared.Models.Entities;

namespace Shared.DataAccess.Contexts;

public abstract class AppFileContext
{
    public readonly IFileSet<User, Guid> Users;
    public readonly IFileSet<BlogPost, Guid> Posts;

    public AppFileContext(string folderPath)
    {
        var serializer = new JsonSerializer();
        var provider = new HumanizerPluralizationProvider();

        Users = new FileSet<User, Guid>(folderPath, serializer, provider);
        Posts = new FileSet<BlogPost, Guid>(folderPath, serializer, provider);
    }

    public async ValueTask FetchAsync()
    {
        await Users.FetchAsync();
        await Posts.FetchAsync();
    }

    public async ValueTask SaveChangesAsync()
    {
        await Users.SaveChangesAsync();
        await Posts.SaveChangesAsync();
    }
}