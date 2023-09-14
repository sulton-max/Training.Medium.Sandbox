using Sandbox.Data.Context;
using Sandbox.Data.SeedData;

var context = TestingContext.Instance;
await context.InitializeAsync();

var users = await context.Users.ToListAsync();
foreach (var user in users)
{
    Console.WriteLine(user);
}