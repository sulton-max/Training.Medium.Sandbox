﻿using Bogus;
using Shared.DataAccess.Contexts;
using Shared.Enums;
using Shared.Models.Common;
using Shared.Models.Entities;

namespace Shared.Data.SeedData;

public static class SeedData
{
    public static async ValueTask InitializeSeedDataAsync(this IDataContext fileContext)
    {
        // accounts
        if (!fileContext.Users.Any())
            await fileContext.AddAsync<User>(100);

        if (!fileContext.UserCredentials.Any())
            await fileContext.AddAsync<UserCredentials>(100);

        // posts
        if (!fileContext.Posts.Any())
            await fileContext.AddAsync<BlogPost>(1_000);

        if (!fileContext.PostDetails.Any())
            await fileContext.AddAsync<PostDetails>(30_000);

        if (!fileContext.PostViews.Any())
            await fileContext.AddAsync<PostView>(1_000);

        if (!fileContext.PostShares.Any())
            await fileContext.AddAsync<PostShare>(10_000);

        if (!fileContext.PostComments.Any())
            await fileContext.AddAsync<PostComment>(10_000);

        if (!fileContext.PostFeedbacks.Any())
            await fileContext.AddAsync<PostFeedback>(10_000);

        // notifications
        if (!fileContext.EmailTemplates.Any())
            await fileContext.AddAsync<EmailTemplate>(1000);

        await fileContext.SaveChangesAsync();
    }

    private static async ValueTask AddAsync<TEntity>(this IDataContext context, int count) where TEntity : IEntity
    {
        var task = typeof(TEntity) switch
        {
            { } t when t == typeof(User) => context.AddUsersAsync(count),
            { } t when t == typeof(UserCredentials) => context.AddUserCredentials(count),
            { } t when t == typeof(BlogPost) => context.AddPostsAsync(count),
            { } t when t == typeof(PostDetails) => context.AddPostDetailsAsync(count),
            { } t when t == typeof(PostView) => context.AddPostViewsAsync(count),
            { } t when t == typeof(PostShare) => context.AddPostSharesAsync(count),
            { } t when t == typeof(PostComment) => context.AddPostCommentsAsync(count),
            { } t when t == typeof(PostFeedback) => context.AddPostFeedback(count),
            { } t when t == typeof(EmailTemplate) => context.AddEmailTemplates(count),
            _ => new ValueTask(Task.CompletedTask)
        };

        await task;
    }

    #region Accounts

    private static async ValueTask AddUsersAsync(this IDataContext context, int count)
    {
        var faker = EntityFakers.GetUserFaker(context);
        var uniqueUsers = new HashSet<User>(faker.Generate(100_000));
        var test = uniqueUsers.Take(count);
        await context.Users.AddRangeAsync(uniqueUsers.Take(count).ToArray());
    }

    private static async ValueTask AddUserCredentials(this IDataContext context, int count)
    {
        var faker = EntityFakers.GetUserCredentialsFaker(context);
        var userCredentials = faker.Generate(context.Users.Count());
        await context.UserCredentials.AddRangeAsync(userCredentials.Take(count).ToArray());
    }

    #endregion

    #region Posts

    private static async ValueTask AddPostsAsync(this IDataContext context, int count)
    {
        var faker = EntityFakers.GetBlogPostFaker(context);
        var uniquePosts = new HashSet<BlogPost>(faker.Generate(100_000));

        await context.Posts.AddRangeAsync(uniquePosts.Take(count).ToArray());
    }

    private static async ValueTask AddPostDetailsAsync(this IDataContext context, int count)
    {
        var faker = EntityFakers.GetPostDetailsFaker(context);
        var postDetails = faker.Generate(context.Posts.Count());

        await context.PostDetails.AddRangeAsync(postDetails.Take(count).ToArray());
    }

    private static async ValueTask AddPostViewsAsync(this IDataContext context, int count)
    {
        var faker = EntityFakers.GetPostViewFaker(context);
        var uniquePostViews = new HashSet<PostView>(faker.Generate(100_000));

        await context.PostViews.AddRangeAsync(uniquePostViews.Take(count).ToArray());
    }

    private static async ValueTask AddPostSharesAsync(this IDataContext context, int count)
    {
        var faker = EntityFakers.GetPostShareFaker(context);
        var uniquePostViews = new HashSet<PostShare>(faker.Generate(100_000));

        await context.PostShares.AddRangeAsync(uniquePostViews.Take(count).ToArray());
    }

    private static async ValueTask AddPostCommentsAsync(this IDataContext context, int count)
    {
        var faker = EntityFakers.GetPostCommentFaker(context);
        var uniquePostComments = new HashSet<PostComment>(faker.Generate(100_000));

        await context.PostComments.AddRangeAsync(uniquePostComments.Take(count).ToArray());
    }

    private static async ValueTask AddPostFeedback(this IDataContext context, int count)
    {
        var faker = EntityFakers.GetPostFeedbackFaker(context);
        var uniquePostFeedbacks = new HashSet<PostFeedback>(faker.Generate(100_000));

        await context.PostFeedbacks.AddRangeAsync(uniquePostFeedbacks.Take(count).ToArray());
    }

    #endregion

    #region Notifications

    private static async ValueTask AddEmailTemplates(this IDataContext context, int count)
    {
        var list = new List<EmailTemplate>
        {
            new EmailTemplate() { Subject = "Welcome to our system!", Body = "Hi {{FullName}}, welcome to our system!" },
            new EmailTemplate() { Subject = "Account activated", Body = "Dear {{FullName}}, We are pleased to inform you that your account has been activated. You can now log in and start using our system."},
            new EmailTemplate() { Subject = "Account deleted", Body = "Dear {{FullName}}, We are sorry to inform you that your account has been deleted from our system. This action was taken because [reason for account deletion]." },
            new EmailTemplate() { Subject = "Your password has been reset", Body = "Dear {{FullName}}, Your password has been reset. Your new password is: {{NewPassword}}." },
            new EmailTemplate() { Subject = "Your account has been suspended", Body = "Dear {{FullName}}, Your account has been suspended. Please contact us for more information." },
            new EmailTemplate() { Subject = "Account update email", Body = "Your account has been updated. Your new account details are as follows: [account details]" }

        };

        await context.EmailTemplates.AddRangeAsync(list.Take(count).ToArray());
    }

    #endregion
}
