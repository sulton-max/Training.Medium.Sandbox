using Shared.Models.Entities;

namespace DiscoverySection.Services
{
    public class PostStaticsService : IPostStatisticsService
    {
        public IQueryable<BlogPost> GetPopularPosts()
        {
            throw new NotImplementedException();
            //hozirgi popular bulayotgan bulayotgan postlar 
        }

        public IQueryable<BlogPost> GetTrendingPosts()
        {
            throw new NotImplementedException();
            // trendga chiqayotgan postlar
        }

        public IQueryable<BlogPost> GetViralPosts()
        {
            // qisqa vaqt ichida kutarilgan service
            throw new NotImplementedException();
        }

    }


}
