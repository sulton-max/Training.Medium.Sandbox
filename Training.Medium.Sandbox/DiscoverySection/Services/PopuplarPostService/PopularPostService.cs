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
        private readonly IPostViewService _viewService;

        public PopularPostService
        (
            IDataContext dataContext, 
            IPostService postService,
            IPostShareService postShareService,
            IPostCommentService postCommentService,
            IPostViewService postViewService
        )
        {
            _dataContext = dataContext;
            _postService = postService;
            _postShareService = postShareService;
        }

        public List<BlogPost> GetPopularPosts()
        {
            //var LateMonthPosts = _dataContext.Posts.Where(post => post.IsDeleted != true && post.CreatedDate <= post.CreatedDate.AddMonths(1)).Take(10).ToList();
            
            var postsQuery = _postService.Get(post => true);




            //dataContext.Posts.Where(post => post.IsDeleted != true && post.CreatedDate <= post.CreatedDate.AddMonths(1)).Take(10);

            return new List<BlogPost>();
        }
    }
}
