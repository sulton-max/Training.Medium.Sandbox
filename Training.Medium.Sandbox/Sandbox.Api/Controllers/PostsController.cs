using Microsoft.AspNetCore.Mvc;

namespace Sandbox.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PostsController : ControllerBase
{
    #region Posts

    [HttpGet]
    public IActionResult GetPosts()
    {
        throw new NotImplementedException();
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

    [HttpGet("feedback")]
    public IActionResult GetFeedbacks()
    {
        throw new NotImplementedException();
    }

    [HttpGet("{postId:guid}/feedback")]
    public IActionResult GetFeedbacksByPostId()
    {
        throw new NotImplementedException();
    }

    [HttpGet("{postId:guid}/feedback/{feedbackId:guid}")]
    public IActionResult GetFeedbackById()
    {
        throw new NotImplementedException();
    }

    [HttpPost("{postId:guid}/feedback")]
    public IActionResult CreateFeedback()
    {
        throw new NotImplementedException();
    }

    [HttpPut("{postId:guid}/feedback/{feedbackId:guid}")]
    public IActionResult UpdateFeedback()
    {
        throw new NotImplementedException();
    }

    [HttpDelete("{postId:guid}/feedback/{feedbackId:guid}")]
    public IActionResult DeleteFeedback()
    {
        throw new NotImplementedException();
    }

    #endregion

    #region Post views

    [HttpPost("{postId:guid}/views")]
    public IActionResult AddPostView([FromBody]Guid userId)
    {
        throw new NotImplementedException();
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
    public IActionResult GetPopularPosts()
    {
        throw new NotImplementedException();
    }

    [HttpGet("trending")]
    public IActionResult GetTrendingPosts()
    {
        throw new NotImplementedException();
    }

    [HttpGet("viral")]
    public IActionResult GetNewPosts()
    {
        throw new NotImplementedException();
    }

    #endregion

}