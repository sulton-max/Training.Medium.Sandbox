using Shared.Models.Common;

namespace FeedSection;

public class Author
{
    public Guid UserId { get; set; }
    public string Name { get; set; }
    public string About { get; set; }

    public Author()
    {
        
    }

    public Author(Guid userId, string name, string about)
    {
        UserId = userId;
        Name = name;
        About = about;
    }

    public override string ToString()
    {
        return $"{Name} {About}";
    }
}