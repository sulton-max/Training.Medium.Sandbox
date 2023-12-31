using Shared.Enums;
using Shared.Models.Common;

namespace Shared.Models.Entities
{
    public class PostShare : SoftDeletedEntity
    {
        public Guid UserId { get; set; }
        public Guid PostId { get; set; }
        public SocialMedia ShareTo { get; set; }

        public override string ToString()
        {
            return $"User:{UserId} \nPostID: {PostId} - {ShareTo}\n";
        }
    }

   
}
