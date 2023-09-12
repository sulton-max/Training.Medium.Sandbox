using System.Reflection;
using Humanizer;
using Shared.DataAccess.Contexts;

namespace Sandbox.Data.Context;

public class TestingContext : AppFileContext
{
    private TestingContext(string rootPath) : base(rootPath)
    {
        var test = Assembly.GetAssembly(typeof(TestingContext))?.Location!;
    }

    private static readonly Lazy<TestingContext> CurrentInstance = new(() => new TestingContext(Directory.GetCurrentDirectory()));

    public static TestingContext Instance => CurrentInstance.Value;
}