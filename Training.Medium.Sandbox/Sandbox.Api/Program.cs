using EntitiesSection.Services;
using EntitiesSection.Services.Interfaces;
using MembershipSection.Services;
using MembershipSection.Services.Interfaces;
using NotificationsSection.Services;
using NotificationsSection.Services.Interfaces;
using Sandbox.Api.Settings;
using Shared.DataAccess.Contexts;

var builder = WebApplication.CreateBuilder(args);

// validations
builder.Services.AddSingleton<IValidationService, ValidationService>();

// data access
// builder.Services.AddScoped<IDataContext, AppFileContext>(_ => new AppFileContext(builder.Environment.ContentRootPath));

// TODO : remove this
builder.Services.AddScoped<AppFileContext>(_ => new AppFileContext(builder.Environment.ContentRootPath));

// account
builder.Services.AddScoped<IUserService, UserService>();

// posts
builder.Services.AddScoped<IPostService, PostService>();

// post analysis

// notifications

// subscriptions
builder.Services.AddScoped<ISubscriptionPromotionService, SubscriptionPromotionService>();

builder.Services.Configure<EmailServerSettings>(builder.Configuration.GetSection(nameof(EmailServerSettings)));

builder.Services.AddSingleton<IEmailSenderService, EmailSenderService>().AddScoped<IEmailManagementService, EmailManagementService>();

var app = builder.Build();

await app.RunAsync();