using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesSection.Services.Interfaces;
using Shared.DataAccess.Contexts;
using Shared.Models.Entities;

namespace DiscoverySection.Services.Trending_PostService
{
    public class TrendingPostService : ITrendingPostService
    {
        private readonly IDataContext _appDataContext;
        private readonly IPostService _postService;
        private readonly IPostShareService _postShareService;
        private readonly IPostCommentService _commentService;
        private readonly IPostDetailsService _postDetailsService;
        private readonly IPostFeedbackService _postFeedbackService;
        private readonly IPostViewService _viewService;
        public TrendingPostService(
            IDataContext dataContext,
            IPostService postService,
            IPostShareService postShareService,
            IPostCommentService postCommentService,
            IPostDetailsService postDetailsService,
            IPostFeedbackService postFeedbackService,
            IPostViewService postViewService
        )
        {
            _appDataContext = dataContext;
            _postService = postService;
            _postShareService = postShareService;
            _commentService = postCommentService;
            _postDetailsService = postDetailsService;
            _postFeedbackService = postFeedbackService;
            _viewService = postViewService;
        }
        public async ValueTask<List<BlogPost>> GetTrendingPostsAsync()
        {
            var postsQuery = _postService.Get(post => true);
            var postViewsQuery = _viewService.Get(post => true);
            var postCommentsQuery = _commentService.Get(post => true);
            var postShareQuery = _postShareService.Get(post => true);
            var postDetailsQuery = _postDetailsService.Get(post => true);
            var postFeedbackService = _postFeedbackService.Get(post => true);

            var trendingPostsQuery =
                from post in postsQuery
                join postView in postViewsQuery on post.Id equals postView.PostId
                join postShare in postShareQuery on post.Id equals postShare.PostId
                join postComment in postCommentsQuery on post.Id equals postComment.PostId
                join postFeedback in postCommentsQuery on post.Id equals postFeedback.PostId
                select new { Posts = post, Views = postView, Feedbacks = postFeedback, PostShares = postShare };

            //var trendingPosts = trendingPostsQuery.ToList();

            return trendingPostsQuery.Select(result => result.Posts).ToList();
        }
    }
}
