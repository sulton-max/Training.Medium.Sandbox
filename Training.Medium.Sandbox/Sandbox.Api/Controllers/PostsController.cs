using DiscoverySection.Services.PopuplarPostService;
using DiscoverySection.Services.Trending_PostService;
using EntitiesSection.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Shared.DataAccess.Contexts;

namespace Sandbox.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PostsController : ControllerBase
{
    private readonly IPostService _postService;
    private readonly IPostViewService _postViewService;

    public PostsController(IPostService postService, IPostViewService postViewService)
    {
        _postService = postService;
        _postViewService = postViewService;
    }

    #region Posts

    [HttpGet]
    public IActionResult GetPosts([FromServices] IPostService postService)
    {
        var result = postService.Get(post => true);
        return Ok(result);
    }

    [HttpGet("{postId:guid}")]
    public IActionResult GetPostById()
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    public IActionResult CreatePost()
    {
        throw new NotImplementedException();
    }

    [HttpPut]
    public IActionResult UpdatePost()
    {
        throw new NotImplementedException();
    }

    [HttpDelete("{postId:guid}")]
    public IActionResult DeletePost()
    {
        throw new NotImplementedException();
    }

    #endregion

    #region Post Comments

    [HttpGet("comments")]
    public IActionResult GetComments()
    {
        throw new NotImplementedException();
    }

    [HttpGet("{postId:guid}/comments")]
    public IActionResult GetCommentsByPostId()
    {
        throw new NotImplementedException();
    }

    [HttpGet("{postId:guid}/comments/{commentId:guid}")]
    public IActionResult GetCommentById()
    {
        throw new NotImplementedException();
    }

    [HttpPost("{postId:guid}/comments")]
    public IActionResult CreateComment()
    {
        throw new NotImplementedException();
    }

    [HttpPut("{postId:guid}/comments/{commentId:guid}")]
    public IActionResult UpdateComment()
    {
        throw new NotImplementedException();
    }

    [HttpDelete("{postId:guid}/comments/{commentId:guid}")]
    public IActionResult DeleteComment()
    {
        throw new NotImplementedException();
    }

    #endregion

    #region Post feedback

    [HttpGet("feedbacks")]
    public IActionResult GetFeedbacks()
    {
        throw new NotImplementedException();
    }

    [HttpGet("{postId:guid}/feedbacks")]
    public IActionResult GetFeedbacksByPostId()
    {
        throw new NotImplementedException();
    }

    [HttpGet("{postId:guid}/feedbacks/{feedbackId:guid}")]
    public IActionResult GetFeedbackById()
    {
        throw new NotImplementedException();
    }

    [HttpPost("{postId:guid}/feedbacks")]
    public IActionResult CreateFeedback()
    {
        throw new NotImplementedException();
    }

    [HttpPut("{postId:guid}/feedbacks/{feedbackId:guid}")]
    public IActionResult UpdateFeedback()
    {
        throw new NotImplementedException();
    }

    [HttpDelete("{postId:guid}/feedbacks/{feedbackId:guid}")]
    public IActionResult DeleteFeedback()
    {
        throw new NotImplementedException();
    }

    #endregion

    #region Post views

    [HttpPost("{postId:guid}/views")]
    public IActionResult AddPostView([FromBody] Guid postId)
    {
        var result = _postViewService.GetByPostId(postId);
        return Ok(result);
    }

    #endregion

    #region Post share

    [HttpGet("{postId:guid}/share")]
    public IActionResult GetPostShares()
    {
        throw new NotImplementedException();
    }

    [HttpPost("{postId:guid}/share")]
    public IActionResult CreatePostShare()
    {
        throw new NotImplementedException();
    }

    #endregion

    #region Post save

    [HttpGet("{postId:guid}/save")]
    public IActionResult GetPostSaves()
    {
        throw new NotImplementedException();
    }

    [HttpPost("{postId:guid}/save")]
    public IActionResult CreatePostSave()
    {
        throw new NotImplementedException();
    }

    #endregion

    #region Feed

    [HttpGet("feed")]
    public IActionResult GetFeedPosts()
    {
        throw new NotImplementedException();
    }

    [HttpGet("popular")]
    public async ValueTask<IActionResult> GetPopularPosts([FromServices] IPopularPostService popularPostService)
    {
        var result = await popularPostService.GetPopularPostsAsync();
        return result.Any() ? Ok(result) : NotFound();
    }

    [HttpGet("trending")]
    public async ValueTask<IActionResult> GetTrendingPosts([FromServices]ITrendingPostService trendingPostService)
    {
        var result = await trendingPostService.GetTrendingPostsAsync();
        return result.Any() ? Ok(result) : NotFound();
    }

    [HttpGet("viral")]
    public IActionResult GetNewPosts()
    {
        throw new NotImplementedException();
    }

    #endregion
}