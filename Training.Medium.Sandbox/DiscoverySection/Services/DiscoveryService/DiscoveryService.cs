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
            return new DiscoveryTopics();
        }
    }
}
