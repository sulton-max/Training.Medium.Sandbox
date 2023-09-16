using FileContext.Abstractions.Models.FileSet;
using Shared.Models.Entities;

namespace Shared.DataAccess.Contexts;

public interface IDataContext : IAsyncDisposable
{
    IFileSet<PostComment, Guid> PostComments { get; }
    IFileSet<User, Guid> Users { get; }
    IFileSet<BlogPost, Guid> Posts { get; }
    IFileSet<PostView, Guid> PostViews { get; }
    IFileSet<UserCredentials, Guid> UserCredentials { get; }
    IFileSet<EmailTemplate, Guid> EmailTemplates { get; }
    IFileSet<PostShare, Guid> PostShares { get; }
    IFileSet<PostFeedback, Guid> PostFeedbacks { get; }
    IFileSet<PostDetails, Guid> PostDetails { get; }

    ValueTask SaveChangesAsync();
}