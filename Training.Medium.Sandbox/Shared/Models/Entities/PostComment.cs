using Shared.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.Entities
{
    public class PostComment : SoftDeletedEntity
    {
      
        public Guid Id { get; set; }

        public User UserId { get; set; }

        public BlogPost PostId { get; set; }

        public int ClapsCount { get; set; }

        public PostComment() { }

        public PostComment(Guid id, User userId, BlogPost postId, int clapsCount)
        {
            Id = id;
            UserId = userId;
            PostId = postId;
            ClapsCount = clapsCount;
        }
    }
}
