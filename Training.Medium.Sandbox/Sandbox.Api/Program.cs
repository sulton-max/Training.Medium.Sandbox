using EntitiesSection.Services;
using EntitiesSection.Services.Interfaces;
using MembershipSection.Services;
using MembershipSection.Services.Interfaces;
using NotificationsSection.Services;
using NotificationsSection.Services.Interfaces;
using Sandbox.Api.Settings;

var builder = WebApplication.CreateBuilder(args);

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


app.MapGet("/", () => "Hello World!");

await app.RunAsync();