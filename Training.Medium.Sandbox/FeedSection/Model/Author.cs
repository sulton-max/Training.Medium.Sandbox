using Bogus;

namespace FeedSection;

public class Author
{
    public long Id { get; set; }
    public string FullName { get; set; }
    public string About { get; set; }
    
    public override string ToString()
    {
        return $"{Id} {FullName} {About}";
    }
}