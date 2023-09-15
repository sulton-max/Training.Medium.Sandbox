using Shared.Models.Common;

namespace Shared.Models.Entities
{
    public class PostDetails : SoftDeletedEntity
    {
        public Guid PostId { get; set; }

        public string Category { get; set; }
    }
}
