using DiscoverySection.Services.Models;
using DiscoverySection.Services.PopuplarPostService;
using DiscoverySection.Services.Trending_PostService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscoverySection.Services.DiscoveryService
{
    public class DiscoveryService : IDiscoveryService
    {
        private IPopularPostService _popularPostInstance;
        private ITrendingPostService _trendingPostInstance;
        public DiscoveryService()
        {
            _popularPostInstance = new PopularPostService();
            _trendingPostInstance = new TrendingPostService();
        }
        public List<DiscoveryTopics> GetMostCommonTopics()
        {
            var a = _trendingPostInstance.GetTrendingPosts();
            var b = _popularPostInstance.GetPopularPosts();
            a.Concat(b);
            throw new NotImplementedException();
        }
    }
}
