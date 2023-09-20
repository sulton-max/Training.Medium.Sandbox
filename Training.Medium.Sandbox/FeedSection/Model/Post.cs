using Bogus;
using FeedSection.Commons;

namespace FeedSection;

public class Post : Auditables
{
    public long AuthorId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }

    public override string ToString()
    {
        return $"PostID: {Id} AuthorID: {AuthorId} CreatedTime: {CreatedDateTime} Title: {Title} Description: {Description}\n";
    }
}