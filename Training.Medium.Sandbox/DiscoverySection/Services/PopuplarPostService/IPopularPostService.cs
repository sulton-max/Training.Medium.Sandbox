using DiscoverySection.Models;
using Shared.Models.Entities;

namespace DiscoverySection.Services.PopuplarPostService
{
    public interface IPopularPostService
    {
        // TODO : map this to other model in compositon service
        IQueryable<PostStatisticsModel> GetPostsQuery();

        IQueryable<PostStatisticsModel> GetPopularPosts();
    }
}
