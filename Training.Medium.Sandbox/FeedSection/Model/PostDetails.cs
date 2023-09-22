using Bogus;
using FeedSection.Commons;

namespace FeedSection;

public class PostDetails: Auditables
{
    public long PostId { get; set; }
    public bool IsMembershipPost { get; set; }
    public int Likes { get; set; }
    public int Comment {get; set; }
    public int ReadTime { get; set; }
    
    public override string ToString()
    {
        return $"{Id} {PostId} {IsMembershipPost} {Likes} {Comment} {ReadTime}";
    }
}