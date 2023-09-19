using DiscoverySection.Models;
using DiscoverySection.Services.PopuplarPostService;

namespace DiscoverySection.Services.DiscoveryService
{
    public class DiscoveryService : IDiscoveryService
    {
        private readonly IPopularPostService _popularPostInstance;

        public DiscoveryService(IPopularPostService popularPostService)
        {
            _popularPostInstance = popularPostService;
        }

        public ValueTask<DiscoveryTopics> GetMostCommonTopics()
        {
            var popularPosts = _popularPostInstance.GetPopularPosts();
            var category = popularPosts.Select(popularPost => popularPost.Details.Category).Distinct().ToList();
            var result = new DiscoveryTopics
            {
                Topics = category
            };

            return new ValueTask<DiscoveryTopics>(result);
        }
    }
}
