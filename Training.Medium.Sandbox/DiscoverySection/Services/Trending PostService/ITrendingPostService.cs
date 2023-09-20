using Shared.Models.Entities;

namespace DiscoverySection.Services.Trending_PostService
{
    public interface ITrendingPostService
    {
        ValueTask<List<BlogPost>> GetTrendingPostsAsync();
    }
}
