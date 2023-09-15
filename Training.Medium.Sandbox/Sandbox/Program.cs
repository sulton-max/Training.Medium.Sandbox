using EntitiesSection;
using EntitiesSection.Services;
using Sandbox.Data.Context;
using Shared.Data.SeedData;

var context = TestingContext.Instance;
await context.InitializeSeedDataAsync();

//var validationService = new ValidationService();
//var postService = new PostService(context);
//var postShareService = new PostShareService(context, validationService);
//var postCommentService = new PostCommentService(context);
//var postViewService = new PostViewService(context);