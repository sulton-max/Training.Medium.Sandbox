using FileContext.Abstractions.Models.FileSet;
using Shared.Models.Entities;

namespace Shared.DataAccess.Contexts;

public interface IDataContext : IAsyncDisposable
{
    IFileSet<User, Guid> Users { get; }
    IFileSet<BlogPost, Guid> Posts { get; }
    IFileSet<PostView, Guid> PostViews { get; }
    IFileSet<PostFeedback, Guid> PostFeedbacks { get; }

    ValueTask SaveChangesAsync();
}