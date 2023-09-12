using FileContext.Abstractions.Models.Entity;

namespace DiscoverySection.Models;

public class BlogPost : IFileSetEntity<Guid>
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public string Category { get; set; }
    public DateTime CreatedAt { get; set; }
    public Guid AuthorId { get; set; }

    public BlogPost(Guid id, string title, string content, DateTime createdAt, Guid authorId)
    {
        Id = id;
        Title = title;
        Content = content;
        CreatedAt = createdAt;
        AuthorId = authorId;

        var list = new List<string>
        {
            "Technology",
            "Business",
            "Marketing",
            "Health",
            "Fitness",
            "Food",
            "Travel",
            "Fashion",
            "Beauty",
            "Lifestyle",
            "Entertainment",
            "Sports",
            "Education",
            "Finance",
            "Politics"
        };

        var random = new Random();
        Category = list[random.Next(0, 15)];
    }
}