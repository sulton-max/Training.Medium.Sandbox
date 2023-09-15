using DiscoverySection.Models;
using DiscoverySection.Services.PopuplarPostService;

namespace DiscoverySection.Services.DiscoveryService
{
    public class DiscoveryService : IDiscoveryService
    {
        private IPopularPostService _popularPostInstance;

        public DiscoveryService(IPopularPostService popularPostService)
        {
            _popularPostInstance = popularPostService;
        }
        // public DiscoveryTopics GetMostCommonTopics()
        // {
        //     var a = _trendingPostInstance.GetTrendingPosts();
        //     var b = _popularPostInstance.GetPopularPosts();
        //     a.Concat(b);
        //
        //     var blogPosts = ""; // get popular posts
        //     var topics = ""; // get topics from content analysis serivce
        //     var distinctTopics = ""; // get distinct topics take 10
        //
        //     var discoveryTopics = new DiscoveryTopics();
        // }
        public List<DiscoveryTopics> GetMostCommonTopics()
        {
            var b = _popularPostInstance.GetPopularPosts();
            //Concat(b);

            //Concat(b);

            var blogPosts = ""; // get popular posts
            var topics = ""; // get topics from content analysis serivce
            var distinctTopics = ""; // get distinct topics take 10

            var discoveryTopics = new DiscoveryTopics();
            return discoveryTopics;
        }
    }
}
