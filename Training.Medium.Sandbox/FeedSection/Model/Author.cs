using Bogus;
using FeedSection.Commons;

namespace FeedSection;

public class Author: Auditables
{
    public string FullName { get; set; }
    public string About { get; set; }
    
    public override string ToString()
    {
        return $"{Id} {FullName} {About}";
    }
}