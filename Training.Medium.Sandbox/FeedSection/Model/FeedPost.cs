namespace FeedSection.Model;

public class FeedPost
{
    public Author? Author { get; set; }
    public Post? Post { get; set; }
    public PostDetails? PostDetails { get; set; }

    public override string ToString()
    {
        return $"{Author} {PostDetails} {Post}";
    }
}