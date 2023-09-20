namespace Shared.Extensions;

public static class EnumExtensions
{
    public static ICollection<string> GetValuesAsString<TEnum>() where TEnum : struct, Enum
    {
        return Enum.GetValues<TEnum>().Select(value => value.ToString()).ToList();
    }
}