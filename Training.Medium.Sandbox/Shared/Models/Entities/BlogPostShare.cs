using Shared.Models.Common;

namespace Shared.Models.Entities
{
    internal class BlogPostShare : SoftDeletedEntity
    {
        public Guid UserId { get; set; }
        public Guid BlogPostId { get; set; }
        public SocialMedia ShareTo { get; set; }

        public override string ToString()
        {
            return $"User:{UserId} \nPostID: {BlogPostId} - {ShareTo}\n";
        }
    }

   
}
