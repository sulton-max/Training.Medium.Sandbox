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
        public BlogPostShare UserId { get; set; }
        public BlogPost BlogPostId { get; set; }
        public SocialMedia ShareTo { get; set; }
    }
}
