namespace FeedSection.Commons;

public abstract class Auditables
{
    public long Id { get; set; }
    public DateTime CreatedDateTime { get; set; }
    public DateTime UpdatedDateTime { get; set; }
}