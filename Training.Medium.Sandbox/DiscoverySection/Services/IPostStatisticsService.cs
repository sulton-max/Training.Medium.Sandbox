using DiscoverySection.Models;

namespace DiscoverySection.Services;

public interface IPostStatisticsService
{
    /// <summary>
    /// Returns query of trending posts
    /// </summary>
    /// <returns>Queryable source of posts</returns>
    IQueryable<BlogPost> GetTrendingPosts();

    /// <summary>
    /// Returns query of viral posts
    /// </summary>
    /// <returns>Queryable source of posts</returns>
    IQueryable<BlogPost> GetViralPosts();

    /// <summary>
    /// Returns query of popular posts
    /// </summary>
    /// <returns>Queryable source of posts</returns>
    IQueryable<BlogPost> GetPopularPosts();
}