using DiscoverySection.Services.DiscoveryService;
using DiscoverySection.Services.PopuplarPostService;
using DiscoverySection.Services.Trending_PostService;
using EntitiesSection;
using EntitiesSection.Services;
using EntitiesSection.Services.Interfaces;
using FileBaseContext.Context.Models.Configurations;
using MembershipSection.Services;
using MembershipSection.Services.Interfaces;
using NotificationsSection.Services;
using NotificationsSection.Services.Interfaces;
using Sandbox.Api.Settings;
using Shared.Data.SeedData;
using Shared.DataAccess.Contexts;

var builder = WebApplication.CreateBuilder(args);

// validations
builder.Services.AddSingleton<IValidationService, ValidationService>();

// data access
builder.Services.AddScoped<IDataContext, AppFileContext>(_ =>
{
    var contextOptions = new FileContextOptions<AppFileContext>
    {
        StorageRootPath = Path.Combine(builder.Environment.ContentRootPath, "Data", "DataStorage")
    };

    var context = new AppFileContext(contextOptions);
    context.FetchAsync().AsTask().Wait();

    return context;
});

// account
builder.Services.AddScoped<IUserService, UserService>();

// posts
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<IPostDetailsService, PostDetailsService>();
builder.Services.AddScoped<IPostFeedbackService, PostFeedbackService>();
builder.Services.AddScoped<IPostViewService, PostViewService>();
builder.Services.AddScoped<IPostShareService, PostShareService>();
builder.Services.AddScoped<IPostViewService, PostViewService>();
builder.Services.AddScoped<IPostCommentService, PostCommentService>();
builder.Services.AddScoped<IPopularPostService, PopularPostService>();
builder.Services.AddScoped<ITrendingPostService, TrendingPostService>();
builder.Services.AddScoped<IDiscoveryService, DiscoveryService>();

// post analysis

// notifications
builder
    .Services
    .AddSingleton<IEmailSenderService, EmailSenderService>()
    .AddScoped<IEmailManagementService, EmailManagementService>()
    .AddScoped<IEmailTemplateService, EmailTemplateService>()
    .AddScoped<IEmailPlaceholderService, EmailPlaceholderService>()
    .AddScoped<IEmailMessageService, EmailMessageService>()
    .AddScoped<IEmailService, EmailService>();

// subscriptions
builder.Services.AddScoped<ISubscriptionPromotionService, SubscriptionPromotionService>();
builder.Services.Configure<EmailServerSettings>(builder.Configuration.GetSection(nameof(EmailServerSettings)));

// dev tools
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();
builder.Services.AddRouting(options => options.LowercaseUrls = true);


var app = builder.Build();

// if (app.Environment.IsDevelopment())
// {
//     using var dataContext = app.Services.CreateAsyncScope().ServiceProvider.GetRequiredService<IDataContext>();
//     await dataContext.InitializeSeedDataAsync();
// }

app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();

await app.RunAsync();