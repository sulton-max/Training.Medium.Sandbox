using Bogus;
using Shared.DataAccess.Contexts;
using Shared.Enums;
using Shared.Extensions;
using Shared.Models.Entities;

namespace Shared.Data.SeedData;

internal static class EntityFakers
{
    #region Accounts

    internal static Faker<User> GetUserFaker(IDataContext context)
    {
        return new Faker<User>()
            .RuleFor(keySelector => keySelector.Id, Guid.NewGuid)
            .RuleFor(keySelector => keySelector.FirstName, source => source.Person.FirstName)
            .RuleFor(keySelector => keySelector.LastName, source => source.Person.LastName)
            .RuleFor(keySelector => keySelector.EmailAddress, source => source.Person.Email);
    }

    internal static Faker<UserCredentials> GetUserCredentialsFaker(IDataContext context)
    {
        var usersId = new Stack<Guid>(context.Users.Select(user => user.Id));
        return new Faker<UserCredentials>()
            .RuleFor(keySelector => keySelector.Id, Guid.NewGuid)
            .RuleFor(keySelector => keySelector.UserId, () => usersId.Pop())
            .RuleFor(keySelector => keySelector.Password, source => source.Internet.Password(8, false, "", "1234567890"));
    }

    #endregion

    #region Posts

    internal static Faker<BlogPost> GetBlogPostFaker(IDataContext context)
    {
        var random = new Random();
        return new Faker<BlogPost>()
            .RuleFor(keySelector => keySelector.Id, Guid.NewGuid)
            .RuleFor(keySelector => keySelector.Title, source => source.Lorem.Text())
            .RuleFor(keySelector => keySelector.Content, source => source.Lorem.Paragraph(5))
            .RuleFor(keySelector => keySelector.AuthorId, source => source.PickRandom(context.Users.Select(user => user.Id)))
            .RuleFor(keySelector => keySelector.CreatedDate, DateTimeOffset.Now.AddMonths(-random.Next(1, 15)));
    }

    internal static Faker<PostDetails> GetPostDetailsFaker(IDataContext context)
    {
        // TODO : this fails if requested post details number is less than posts count
        var categories = new List<string>
        {
            "Angular",
            "CSS",
            "HTML",
            "Java",
            "JavaScript",
            "Nodejs",
            "Python",
            "React",
            "Ruby",
            "Typescript"
        };

        var postsId = new Stack<Guid>(context.Posts.Select(user => user.Id));
        return new Faker<PostDetails>()
            .RuleFor(keySelector => keySelector.Id, Guid.NewGuid)
            .RuleFor(keySelector => keySelector.PostId, () => postsId.Pop())
            .RuleFor(keySelector => keySelector.Category, source => source.PickRandom(categories));
    }

    internal static Faker<PostView> GetPostViewFaker(IDataContext context)
    {
        return new Faker<PostView>()
            .RuleFor(keySelector => keySelector.Id, Guid.NewGuid)
            .RuleFor(keySelector => keySelector.PostId, source => source.PickRandom(context.Posts.Select(post => post.Id)))
            .RuleFor(keySelector => keySelector.UserId, source => source.PickRandom(context.Users.Select(user => user.Id)));
    }

    internal static Faker<PostShare> GetPostShareFaker(IDataContext context)
    {
        return new Faker<PostShare>()
            .RuleFor(keySelector => keySelector.Id, Guid.NewGuid)
            .RuleFor(keySelector => keySelector.PostId, source => source.PickRandom(context.Posts.Select(post => post.Id)))
            .RuleFor(keySelector => keySelector.UserId, source => source.PickRandom(context.Users.Select(user => user.Id)))
            .RuleFor(keySelector => keySelector.ShareTo, source => source.PickRandom<SocialMedia>());
    }

    internal static Faker<PostComment> GetPostCommentFaker(IDataContext context)
    {
        var socialMedia = EnumExtensions.GetValuesAsString<SocialMedia>();
        return new Faker<PostComment>()
            .RuleFor(keySelector => keySelector.Id, Guid.NewGuid)
            .RuleFor(keySelector => keySelector.PostId, Guid.NewGuid)
            .RuleFor(keySelector => keySelector.CommenterId, Guid.NewGuid)
            .RuleFor(keySelector => keySelector.Message, source => source.Lorem.Paragraph(5));
    }

    internal static Faker<PostFeedback> GetPostFeedbackFaker(IDataContext context)
    {
        var random = new Random();
        return new Faker<PostFeedback>()
            .RuleFor(keySelector => keySelector.Id, Guid.NewGuid)
            .RuleFor(keySelector => keySelector.PostId, source => source.PickRandom(context.Posts.Select(post => post.Id)))
            .RuleFor(keySelector => keySelector.UserId, source => source.PickRandom(context.Users.Select(user => user.Id)))
            .RuleFor(keySelector => keySelector.ClapsLimit, random.Next(1, 50));
    }

    #endregion
}