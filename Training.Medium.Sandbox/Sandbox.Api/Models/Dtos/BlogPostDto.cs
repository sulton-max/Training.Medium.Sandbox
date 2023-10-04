using Shared.Models.Entities;

namespace Sandbox.Api.Models.Dtos;

public class BlogPostDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public Guid AuthorId { get; set; }

    public BlogPostDto()
    {
    }

    public BlogPostDto(Guid id, string title, string content, Guid authorId)
    {
        Id = id;
        Title = title;
        Content = content;
        AuthorId = authorId;
    }
    
    public static explicit operator BlogPostDto(BlogPost post)
    {
        return new BlogPostDto(post.Id, post.Title, post.Content, post.AuthorId);
    }

    public static explicit operator BlogPost(BlogPostDto blogPostDto)
    {
        return new BlogPost(blogPostDto.Id, blogPostDto.Title, blogPostDto.AuthorId, blogPostDto.Content);
    }
}