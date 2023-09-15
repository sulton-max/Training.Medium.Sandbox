using Sandbox.Data.Context;
using Shared.Data.SeedData;

var context = TestingContext.Instance;
await context.InitializeSeedDataAsync();

foreach(var post in context.Posts)
{
    Console.WriteLine(post);
}