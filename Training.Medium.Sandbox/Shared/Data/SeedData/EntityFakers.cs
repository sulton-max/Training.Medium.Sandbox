using Bogus;
using Shared.DataAccess.Contexts;
using Shared.Models.Entities;

namespace Shared.Data.SeedData;

internal static class EntityFakers
{
    internal static Faker<User> GetUserFaker(IDataContext context)
    {
        return new Faker<User>().RuleFor(property => property.Id, Guid.NewGuid)
            .RuleFor(property => property.FirstName, source => source.Person.FirstName)
            .RuleFor(property => property.LastName, source => source.Person.LastName)
            .RuleFor(property => property.EmailAddress, source => source.Person.Email);
    }

    internal static Faker<BlogPost> GetBlogPostFaker(IDataContext context)
    {
        return new Faker<BlogPost>().RuleFor(keySelector => keySelector.Id, Guid.NewGuid)
            .RuleFor(keySelector => keySelector.Title, source => source.Lorem.Text())
            .RuleFor(keySelector => keySelector.Content, source => source.Lorem.Paragraph(5))
            .RuleFor(keySelector => keySelector.AuthorId, source => source.PickRandom(context.Users.Select(user => user.Id)));
    }

    internal static Faker<PostView> GetPostViewFaker(IDataContext context)
    {
        return new Faker<PostView>()
            .RuleFor(keySelector => keySelector.Id, Guid.NewGuid)
            .RuleFor(keySelector => keySelector.PostId, source => source.PickRandom(context.Posts.Select(post => post.Id)))
            .RuleFor(keySelector => keySelector.UserId, source => source.PickRandom(context.Users.Select(user => user.Id)));
    }
}