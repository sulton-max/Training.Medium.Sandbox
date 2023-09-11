using Sandbox.Data.Context;
using Sandbox.Data.SeedData;

var context = TestingContext.Instance;
await context.InitializeAsync();