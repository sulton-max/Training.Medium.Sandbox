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
            
            var posts = _postService.Get(post => true).ToList();
            return new ValueTask<List<BlogPost>>(posts);
        }
    }
}
