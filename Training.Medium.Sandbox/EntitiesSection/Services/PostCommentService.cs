﻿using EntitiesSection.Services.Interfaces;
using Shared.DataAccess.Contexts;
using Shared.Models.Entities;
using System.Linq.Expressions;

namespace EntitiesSection.Services;

public class PostCommentService : IPostCommentService
{
    private readonly IDataContext _appDataContext;

    public PostCommentService(IDataContext appDataContext)
    {
        _appDataContext = appDataContext;
    }

    public async ValueTask<PostComment> CreateAsync(PostComment postComment, bool saveChanges = true)
    {
        await _appDataContext.PostComments.AddAsync(postComment);
        if(saveChanges)
            await _appDataContext.SaveChangesAsync();
        return postComment;
    }

    public async ValueTask<PostComment> DeleteAsync(Guid id, bool saveChanges = true)
    {
        var foundPostcomment = await GetByIdAsync(id);
        if (foundPostcomment is null)
            throw new InvalidOperationException("You searched comment not found");

        foundPostcomment.IsDeleted = true;
        await _appDataContext.SaveChangesAsync();
        return foundPostcomment;
    }

  
    public async ValueTask<PostComment> DeleteAsync(PostComment postComment, bool saveChanges = true)
    {
        var foundPostComment = await GetByIdAsync(postComment.Id);
        if (foundPostComment is null)
            throw new InvalidOperationException("Comment not found");

        await _appDataContext.SaveChangesAsync();
        return foundPostComment;
    }

    public IQueryable<PostComment> Get(Expression<Func<PostComment, bool>> predicate)
    {
        return _appDataContext.PostComments.Where(predicate.Compile()).AsQueryable();
    }

    public ValueTask<ICollection<PostComment>> GetAsync(IEnumerable<Guid> ids)
    {
        var comments = _appDataContext.PostComments.Where(comment => ids.Contains(comment.Id));
        return new ValueTask < ICollection<PostComment>>(comments.ToList());
    }

    public ValueTask<PostComment?> GetByIdAsync(Guid id)
    {
        var comment = _appDataContext.PostComments.FirstOrDefault(comment => comment.Id == id);
        return new ValueTask<PostComment?>(comment);
    }

    public async ValueTask<PostComment> UpdateAsync(PostComment postComment, bool saveChanges = true)
    {
        var foundComment = _appDataContext.PostComments.FirstOrDefault(comment => comment.Id ==  postComment.Id);
        if (postComment is null)
            throw new InvalidOperationException("Comment not found");

        foundComment.PostId = postComment.PostId;
        foundComment.Id = postComment.Id;
        foundComment.CommenterId = postComment.CommenterId;
        foundComment.Message = postComment.Message;

        await _appDataContext.SaveChangesAsync();
        return foundComment;
    }
    private bool IsValidCreatedComment(PostComment comment)
    {
        var existingComment = _appDataContext.PostComments.FirstOrDefault(x => x.CommenterId == comment.CommenterId &&
                                                                               x.IsDeleted == false &&
                                                                               x.PostId == comment.PostId &&
                                                                               x.Message != null);
        if (existingComment != null)
        {
            return true;
        }

        return false;
    }

    private bool IsValidUpdatedComment(PostComment comment)
    {
        var updatingPostComment = _appDataContext.PostComments.FirstOrDefault(x => x.CommenterId == comment.CommenterId &&
            x.IsDeleted == false &&
            x.PostId == comment.PostId &&
            x.Message!= null);
        if (updatingPostComment != null)
        {
            return true;
        }

        return false;
    }

    private bool IsValidDeletedComment(PostComment comment)
    {
        var deletingPostComment = _appDataContext.PostComments.FirstOrDefault(x => x.CommenterId == comment.CommenterId &&
            x.IsDeleted == false &&
            x.PostId == comment.PostId &&
            x.Message != null);
        if (deletingPostComment!= null)
        {
            return true;
        }

        return false;
    }
}