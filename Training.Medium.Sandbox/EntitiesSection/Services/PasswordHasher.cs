using BCrypt;
namespace EntitiesSection.Services;

public static class PasswordHasher
{
    public static string Hash(string password)
    {
        var saltWorkFactor = DateTime.Now.Second % 10;
        var hash = BCrypt.Net.BCrypt.EnhancedHashPassword(password, saltWorkFactor);
        return hash;
    }

    public static bool Verify(string password, string hash)
        => BCrypt.Net.BCrypt.EnhancedVerify(password, hash);
    
}