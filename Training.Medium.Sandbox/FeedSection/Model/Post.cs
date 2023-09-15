using Bogus;

namespace FeedSection;

public class Post
{
    public List<Post> _posts; 
    public long Id { get; set; }
    public long AuthorId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }

    public Post()
    {
        
    }
    public Post(int countOfFakeData)
    {
        int lastId = 1;
        var random = new Random();

        Faker<Post> _fakePosts = new Faker<Post>()
                        .RuleFor(post => post.Id, post => lastId++)
                        .RuleFor(post => post.AuthorId, AuthorId => random.Next(1, 50))
                        .RuleFor(post => post.Title, Title => Title.Lorem.Letter(5))
                        .RuleFor(post => post.Description, Description => Description.Lorem.Letter(15));

        _posts = _fakePosts.Generate(countOfFakeData);
    }

    public override string ToString()
    {
        return $"{Id} {AuthorId} {Title} {Description}\n";
    }
}