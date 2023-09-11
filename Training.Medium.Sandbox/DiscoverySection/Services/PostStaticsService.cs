using DiscoverySection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscoverySection.Services
{
    public class PostStaticsService : IPostStatisticsService
    {
        public IQueryable<BlogPost> GetPopularPosts()
        {
            throw new NotImplementedException();
        }

        public IQueryable<BlogPost> GetTrendingPosts()
        {
            throw new NotImplementedException();
        }

        public IQueryable<BlogPost> GetViralPosts()
        {
            throw new NotImplementedException();
        }

    }
}
