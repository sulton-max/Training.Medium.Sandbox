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
            .RuleFor(keySelector => keySelector.AuthorId,
                source => source.PickRandom(context.Users.Select(user => user.Id)));
    }

    internal static Faker<PostDetails> GetPostDetailsFaker(IDataContext context)
    {
        // TODO : this fails if requuested post details number is less than posts count
        var postDetails = context.Posts.Select(post => post.Id).ToList();
        var categories = new List<string>
        {
            "Business and Entrepreneurship",
            "Relationships and Dating",
            "Lifestyle and Personal Development",
            "Finance and Money",
            "Parenting and Family",
            "Food and Cooking",
            "Fashion and Style",
            "Technology and Gadgets",
            "Health and Wellness",
            "Travel and Adventure",
            "Self-Care and Mental Health",
            "History and Culture",
            "Hobbies and Crafts",
            "Sports and Fitness",
            "Science and Technology",
            "Travel and Food",
            "Environmental Sustainability",
            "Home Improvement and DIY",
            "Entertainment and Pop Culture",
            "Education and Learning"
        };

        return new Faker<PostDetails>()
            .RuleFor(keySelector => keySelector.Id, Guid.NewGuid)
            .RuleFor(keySelector => keySelector.PostId, () =>
            {
                var postId = postDetails.First();
                postDetails.Remove(postId);
                return postId;
            })
            .RuleFor(keySelector => keySelector.Category, source => source.PickRandom(categories));
    }

    internal static Faker<PostView> GetPostViewFaker(IDataContext context)
    {
        return new Faker<PostView>()
            .RuleFor(keySelector => keySelector.Id, Guid.NewGuid)
            .RuleFor(keySelector => keySelector.PostId,
                source => source.PickRandom(context.Posts.Select(post => post.Id)))
            .RuleFor(keySelector => keySelector.UserId,
                source => source.PickRandom(context.Users.Select(user => user.Id)));
    }
}