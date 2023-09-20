using DiscoverySection.Models;
using EntitiesSection.Services.Interfaces;
using Shared.Models.Entities;

namespace DiscoverySection.Services.PopuplarPostService
{
    public class PopularPostService : IPopularPostService
    {
        private readonly IPostService _postService;
        private readonly IPostShareService _postShareService;
        private readonly IPostCommentService _commentService;
        private readonly IPostDetailsService _postDetailsService;
        private readonly IPostViewService _viewService;
        private readonly IPostFeedbackService _postFeedbackService;

        public PopularPostService(
            IPostService postService,
            IPostShareService postShareService,
            IPostCommentService postCommentService,
            IPostDetailsService postDetailsService,
            IPostViewService postViewService,
            IPostFeedbackService postFeedbackService
        )
        {
            _postService = postService;
            _postShareService = postShareService;
            _commentService = postCommentService;
            _postDetailsService = postDetailsService;
            _viewService = postViewService;
            _postFeedbackService = postFeedbackService;
        }

        public IQueryable<PostStatisticsModel> GetPostsQuery()
        {
            var postsQuery = _postService.Get(post => true);
            var postViewsQuery = _viewService.Get(post => true);
            var postCommentsQuery = _commentService.Get(post => true);
            var postShareQuery = _postShareService.Get(post => true);
            var postDetailsQuery = _postDetailsService.Get(post => true);
            var postFeedbackQuery = _postFeedbackService.Get(post => true);

            return from post in postsQuery
                join postDetails in postDetailsQuery on post.Id equals postDetails.PostId into postDetail
                join postViews in postViewsQuery on post.Id equals postViews.PostId into postView
                join postComments in postCommentsQuery on post.Id equals postComments.PostId into postComment
                join postFeedback in postFeedbackQuery on post.Id equals postFeedback.PostId into postFeedback
                join postShares in postShareQuery on post.Id equals postShares.PostId into postShare
                select new PostStatisticsModel(post, postDetail.First(), postView, postComment, postFeedback, postShare);
        }

        public IQueryable<PostStatisticsModel> GetPopularPosts()
        {
            var postStatisticsQuery = GetPostsQuery();
            var query = from postStatistics in postStatisticsQuery
                let viewsCount = postStatistics.Views.Count()
                let commentsCount = postStatistics.Comments.Count()
                let sharesCount = postStatistics.Shares.Count()
                let feedbacksCount = postStatistics.Feedbacks.Sum(feedback => feedback.UserClaps)
                let totalScore = feedbacksCount * 3 + viewsCount * 0.5 + commentsCount * 1 + sharesCount * 4
                orderby totalScore descending
                select postStatistics;

            var test = query.Take(100).ToList();

            return query;
        }
    }
}