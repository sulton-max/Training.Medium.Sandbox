using System.Data;
using FeedSection.Iinterface;
using FeedSection.Model;

namespace FeedSection.Service;

public class FeedService: IFeedService
{
    private static FakeDataGenerator feedData = new FakeDataGenerator();
    private IEnumerable<FeedPost> feedPostList = feedData.GetFeedPost(100);
    public IEnumerable<FeedPost> GetLastAddedPosts() => 
                    feedPostList.Where(feedPost => feedPost.Post.CreatedDateTime >= DateTime.Now.AddDays(-30) 
                                                   && feedPost.Post.CreatedDateTime <= DateTime.Now); 
    public IEnumerable<FeedPost> GetMoreLikedPosts() =>
                    feedPostList.OrderByDescending(feedPost => feedPost.PostDetails.Likes);
    public IEnumerable<FeedPost> GetMoreCommentedPosts() =>
                    feedPostList.OrderByDescending(feedPost => feedPost.PostDetails.Comment);
    public IEnumerable<FeedPost> GetAllFeedPosts()
    {
        throw new NotImplementedException();
    }
}