using Shared.Models.Common;
using System.Reflection.Metadata;

namespace Shared.Models.Entities;

public class BlogPost : SoftDeletedEntity
{
    public BlogPost()
    { }

    public BlogPost(Guid id, string title, Guid authorId, string content)
    {
        Id = id;
        Title = title;
        AuthorId = authorId;
        Content = content;
    }

    public string Title { get; set; }
    public string Content { get; set; }
    public Guid AuthorId { get; set; }

    // TODO : Add is banned property
}