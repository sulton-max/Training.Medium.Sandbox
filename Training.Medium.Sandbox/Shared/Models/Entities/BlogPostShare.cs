using Shared.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.Entities
{
    public class BlogPostShare : SoftDeletedEntity
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
