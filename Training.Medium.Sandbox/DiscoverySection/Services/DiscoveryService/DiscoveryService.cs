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
        public DiscoveryTopics GetMostCommonTopics()
        {
            var b = _popularPostInstance.GetPopularPostsAsync();
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
