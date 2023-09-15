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
        public DiscoveryTopics GetMostCommonTopics()
        {
            var a = _trendingPostInstance.GetTrendingPosts();
            var b = _popularPostInstance.GetPopularPosts();
            a.Concat(b);

            var blogPosts = ""; // get popular posts
            var topics = ""; // get topics from content analysis serivce
            var distinctTopics = ""; // get distinct topics take 10

            var discoveryTopics = new DiscoveryTopics();
        }
    }
}
