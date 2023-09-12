using Sandbox.Data.Context;
using Sandbox.Data.SeedData;

var context = TestingContext.Instance;
await context.InitializeAsync();

var users = await context.Users.ToListAsync();
Console.WriteLine(users.Count);