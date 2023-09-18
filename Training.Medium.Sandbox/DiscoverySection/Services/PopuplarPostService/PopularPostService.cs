using Shared.DataAccess.Contexts;
using Shared.Models.Entities;
using EntitiesSection.Services.Interfaces;

namespace DiscoverySection.Services.PopuplarPostService
{
    public class PopularPostService : IPopularPostService
    {
        private readonly IPostService _postService;
        private readonly IPostShareService _postShareService;
        private readonly IPostCommentService _commentService;
        private readonly IPostDetailsService _postDetailsService;
        private readonly IPostViewService _viewService;

        public PopularPostService(
            IPostService postService,
            IPostShareService postShareService,
            IPostCommentService postCommentService,
            IPostDetailsService postDetailsService,
            IPostViewService postViewService
        )
        {
            _postService = postService;
            _postShareService = postShareService;
            _commentService = postCommentService;
            _postDetailsService = postDetailsService;
            _viewService = postViewService;
        }

        public ValueTask<List<BlogPost>> GetPopularPostsAsync()
        {
            var postsQuery = _postService.Get(post => true);
            var postViewsQuery = _viewService.Get(post => true);
            var postCommentsQuery = _commentService.Get(post => true);
            var postShareQuery = _postShareService.Get(post => true);
            var postDetailsQuery = _postDetailsService.Get(post => true);

            var popularPostQuery = (from post in postsQuery
                    join postViews in postViewsQuery on post.Id equals postViews.PostId into postView
                    join postComments in postCommentsQuery on post.Id equals postComments.PostId into postComment
                    join postShares in postShareQuery on post.Id equals postShares.PostId into postShare
                    let totalViews = postView.Count()
                    let totalComments = postComment.Count()
                    let totalShares = postShare.Count()
                    orderby (totalViews + totalComments + totalShares) descending
                    select new {post, totalViews, totalComments, totalShares})
                .Take(100)
                .ToList();

            var posts = _postService.Get(post => true).ToList();
            return new ValueTask<List<BlogPost>>(posts);
        }
    }
}