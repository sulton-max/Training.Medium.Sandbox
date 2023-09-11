using Bogus;
using Sandbox.Data.Context;
using Shared.DataAccess.Contexts;
using Shared.Models.Entities;

namespace Sandbox.Data.SeedData;

public static class SeedData
{
    public static async ValueTask InitializeAsync(this AppFileContext fileContext)
    {
        if (!fileContext.Users.Any())
            await fileContext.Users.AddRangeAsync(GetUserFaker().Generate(10_000));

        await fileContext.SaveChangesAsync();
    }

    private static Faker<User> GetUserFaker()
    {
        return new Faker<User>().RuleFor(property => property.Id, Guid.NewGuid)
            .RuleFor(property => property.FirstName, source => source.Person.FirstName)
            .RuleFor(property => property.LastName, source => source.Person.LastName)
            .RuleFor(property => property.EmailAddress, source => source.Person.Email);
    }
}