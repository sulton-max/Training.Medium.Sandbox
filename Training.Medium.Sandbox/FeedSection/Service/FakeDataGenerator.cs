using Bogus;
using FeedSection.Iinterface;
using FeedSection.Model;
using Random = System.Random;

namespace FeedSection.Service;

public class FakeDataGenerator : IFakeDataGenerator
{
    public IEnumerable<Author> GetAuthor(int countOfData)
    {
        int lastId = 1;
        
        Faker<Author> fakeAuthors = new Faker<Author>()
                        .RuleFor(author => author.Id, author => lastId++)
                        .RuleFor(author => author.FullName, FullName => FullName.Person.FullName)
                        .RuleFor(author => author.About, About => About.Lorem.Letter(10));
        
        return fakeAuthors.Generate(countOfData);
    }

    public IEnumerable<Post> GetPost(int countOfData)
    {
        int lastId = 1;
        var random = new Random();

        Faker<Post> fakePosts = new Faker<Post>()
                        .RuleFor(post => post.Id, post => lastId++)
                        .RuleFor(post => post.AuthorId, AuthorId => random.Next(1, 50))
                        .RuleFor(post => post.Title, Title => Title.Lorem.Letter(5))
                        .RuleFor(post => post.Description, Description => Description.Lorem.Letter(15));

        return fakePosts.Generate(countOfData);
    }

    public IEnumerable<PostDetails> GetPostDetails(int countOfData)
    {
        int lastId = 1;
        var random = new Random();

        Faker<PostDetails> fakePostDetails = new Faker<PostDetails>()
                        .RuleFor(postDetails => postDetails.Id, postDetails => lastId++)
                        .RuleFor(postDetails => postDetails.PostId, postDetails => random.Next(1, 50))
                        .RuleFor(postDetails => postDetails.IsMembershipPost, IsMembershipPost => IsMembershipPost.Random.Bool())
                        .RuleFor(postDetails => postDetails.Likes, Likes => random.Next(1, 500))
                        .RuleFor(postDetails => postDetails.Comment, Comment => random.Next(1, 100))
                        .RuleFor(postDetails => postDetails.ReadTime, ReadTime => random.Next(6, 17));
        
        return fakePostDetails.Generate(countOfData);
    }

    public IEnumerable<FeedPost> GetFeedPost(int countOfData)
    {
        var authors = GetAuthor(countOfData).ToList();
        var posts = GetPost(countOfData).ToList();
        var postDetails = GetPostDetails(countOfData).ToList();
        
        var feedPost = new Faker<FeedPost>()
                        .CustomInstantiator(feed => new FeedPost
                        {
                                Author = authors[feed.IndexFaker],
                                Post = posts[feed.IndexFaker],
                                PostDetails = postDetails[feed.IndexFaker]
                        });
        
        return feedPost.Generate(countOfData);
    }
}