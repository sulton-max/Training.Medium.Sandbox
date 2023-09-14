using EntitiesSection.Services;
using EntitiesSection.Services.Interfaces;
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
builder.Services.AddScoped<IDataContext, AppFileContext>(_ => new AppFileContext(builder.Environment.ContentRootPath));

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

// dev tools
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();
builder.Services.AddRouting(options => options.LowercaseUrls = true);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    await using var dataContext = app.Services.CreateAsyncScope().ServiceProvider.GetRequiredService<IDataContext>();
    await dataContext.InitializeSeedDataAsync();
}

app.UseSwagger();
app.UseSwaggerUI();

await app.RunAsync();