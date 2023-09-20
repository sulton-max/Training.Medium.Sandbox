using Shared.Models.Entities;

namespace DiscoverySection.Models;

public class PostStatisticsModel
{
    public BlogPost Post { get; set; }
    public PostDetails Details { get; set; }
    public IEnumerable<PostView> Views { get; set; }
    public IEnumerable<PostComment> Comments { get; set; }
    public IEnumerable<PostShare> Shares { get; set; }
    public IEnumerable<PostFeedback> Feedbacks { get; set; }

    public PostStatisticsModel(BlogPost post, PostDetails details, IEnumerable<PostView> views, IEnumerable<PostComment> comments, IEnumerable<PostFeedback> feedbacks, IEnumerable<PostShare> shares)
    {
        Post = post;
        Details = details;
        Views = views;
        Comments = comments;
        Shares = shares;
        Feedbacks = feedbacks;
    }
}