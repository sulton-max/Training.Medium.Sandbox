using System.Reflection;
using FileBaseContext.Context.Models.Configurations;
using Humanizer;
using Shared.DataAccess.Contexts;

namespace Sandbox.Data.Context;

public class TestingContext : AppFileContext
{
    public TestingContext() : base(new FileContextOptions<AppFileContext>
    {
        StorageRootPath = Assembly.GetAssembly(typeof(TestingContext))?.Location!
    })
    {
    }

    private static readonly Lazy<TestingContext> CurrentInstance = new(() => new TestingContext());

    public static TestingContext Instance => CurrentInstance.Value;
}