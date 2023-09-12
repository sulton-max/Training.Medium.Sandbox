using FileContext.Abstractions.Models.FileSet;
using FileContext.Core.Models.FileSet;
using FileContext.Core.Services;
using Newtonsoft.Json;
using Shared.Models.Entities;

namespace Shared.DataAccess.Contexts;

public abstract class AppFileContext
{
    public readonly IFileSet<User, Guid> Users;

    public AppFileContext(string folderPath)
    {
        var serializer = new JsonSerializer();
        var provider = new HumanizerPluralizationProvider();

        Users = new FileSet<User, Guid>(folderPath, serializer, provider);
    }

    public async ValueTask SaveChangesAsync()
    {
        await Users.SaveChangesAsync();
    }
}