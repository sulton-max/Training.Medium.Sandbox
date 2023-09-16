using Shared.DataAccess.Contexts;
using Shared.Models.Entities;
using EntitiesSection.Services.Interfaces;

namespace DiscoverySection.Services.PopuplarPostService
{
    public class PopularPostService : IPopularPostService
    {
        private readonly IDataContext _dataContext;
        private readonly IPostService _postService;
        private readonly IPostShareService _postShareService;
        private readonly IPostCommentService _commentService;
        private readonly IPostDetailsService _postDetailsService;
        private readonly IPostViewService _viewService;

        public PopularPostService
        (
            IDataContext dataContext,
            IPostService postService,
            IPostShareService postShareService,
            IPostCommentService postCommentService,
            IPostDetailsService postDetailsService,
            IPostViewService postViewService
            
        )
        {
            _dataContext = dataContext;
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


            /*var popularPostQuery =
                from post in postsQuery
                join postViews in postViewsQuery on post.Id equals postViews.PostId into viewGroup
                join postComments in postCommentsQuery on post.Id equals postComments.PostId into commentGroup
                join postShares in postShareQuery on post.Id equals postShares.PostId into shareGroupshareGroup
                let totalViews = viewGroup.Sum(v => v.Count)
                let totalComments = commentGroup.Count()
                let totalShares = shareGroup.Count()
                orderby (totalViews + totalComments + totalShares) descending
                select post
                ).Take(100).ToList();*/
                var posts = _postService.Get(post => true).ToList();
                
                var returnPosts = 
                    from postDetail in postDetailsQuery
                    join post in posts on postDetail.PostId equals post.Id
                    select new { Post = post };
                returnPosts.Distinct();
                 
            return new ValueTask<List<BlogPost>>(posts);
        }
    }
}
