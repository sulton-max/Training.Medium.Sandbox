using Bogus;

namespace FeedSection;

public class Post
{
    public long Id { get; set; }
    public long AuthorId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }

    public override string ToString()
    {
        return $"{Id} {AuthorId} {Title} {Description}\n";
    }
}