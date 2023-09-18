using DiscoverySection.Models;
using DiscoverySection.Services.PopuplarPostService;

namespace DiscoverySection.Services.DiscoveryService
{
    public class DiscoveryService : IDiscoveryService
    {
        private IPopularPostService _popularPostInstance;
        // post details must 

        public DiscoveryService(IPopularPostService popularPostService)
        {
            _popularPostInstance = popularPostService;
        }

        public DiscoveryTopics GetMostCommonTopics()
        {
            /*discoveryTopics.Topics.Add(
            var  popularTopics = await _popularPostInstance.GetPopularPostsAsync());
            var discoveryTopics = new DiscoveryTopics();
            discoveryTopics.Topics = new List<string>();
            
            */

            // var popularPosts = _popularPostInstance.GetPopularPostsAsync();
            //
            // var returnPosts =
            //     from postDetail in postDetailsQuery
            //     join post in posts on postDetail.PostId equals post.Id
            //     select postDetail.Category;
            //
            // returnPosts.Distinct();

            return new DiscoveryTopics();
        }
    }
}
