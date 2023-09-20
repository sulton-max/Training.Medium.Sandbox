using FeedSection.Model;

namespace FeedSection.Iinterface;

public interface IFeedService
{
    IEnumerable<FeedPost> GetLastAddedPosts(); 
    IEnumerable<FeedPost> GetMoreLikedPosts();
    IEnumerable<FeedPost> GetMoreCommentedPosts();
    IEnumerable<FeedPost> GetAllFeedPosts();
}