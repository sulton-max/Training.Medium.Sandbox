using FileBaseContext.Abstractions.Models.FileSet;
using Shared.Models.Entities;

namespace Shared.DataAccess.Contexts;

public interface IDataContext : IDisposable, IAsyncDisposable
{
    #region Accounts

    IFileSet<User, Guid> Users { get; }

    IFileSet<UserCredentials, Guid> UserCredentials { get; }

    #endregion

    #region Contents

    IFileSet<BlogPost, Guid> Posts  { get; }

    IFileSet<PostDetails, Guid> PostDetails { get; }

    IFileSet<PostView, Guid> PostViews { get; }

    IFileSet<PostFeedback, Guid> PostFeedbacks { get; }

    IFileSet<PostComment, Guid> PostComments { get; }

    IFileSet<PostShare, Guid> PostShares { get; }

    #endregion

    #region Notifications

    IFileSet<EmailTemplate, Guid> EmailTemplates { get; }

    #endregion

    ValueTask SaveChangesAsync();
}