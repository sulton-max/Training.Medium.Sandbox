using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Models.Entities;

namespace DiscoverySection.Services.Trending_PostService
{
    public interface ITrendingPostService
    {
        public List<BlogPost> GetTrendingPosts();
    }
}
