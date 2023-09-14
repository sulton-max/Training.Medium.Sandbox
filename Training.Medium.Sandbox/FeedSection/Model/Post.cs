namespace FeedSection;

public class Post
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }

    public Post()
    {
        
    }

    public Post(Guid id, string title, string description, string imageUrl)
    {
        Id = id;
        Title = title;
        Description = description;
        ImageUrl = imageUrl;
    }

    public override string ToString()
    {
        return $"{Id} {Title} {Description}";
    }
}