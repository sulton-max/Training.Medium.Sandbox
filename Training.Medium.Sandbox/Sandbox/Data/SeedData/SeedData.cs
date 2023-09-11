using Sandbox.Data.Context;
using Shared.DataAccess.Contexts;
using Shared.Models.Entities;

namespace Sandbox.Data.SeedData;

public static class SeedData
{
    public static async ValueTask InitializeAsync(this AppFileContext fileContext)
    {
        var test = new User();
        await fileContext.Users.AddAsync(test);
        await fileContext.SaveChangesAsync();
    }
}