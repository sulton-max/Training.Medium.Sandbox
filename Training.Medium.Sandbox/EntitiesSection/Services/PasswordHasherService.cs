using EntitiesSection.Services.Interfaces;

namespace EntitiesSection.Services;

public class PasswordHasherService : IPasswordHasherService
{
    public string Hash(string password)
    {
        var saltWorkFactor = DateTime.Now.Second % 10;
        var hash = BCrypt.Net.BCrypt.EnhancedHashPassword(password, saltWorkFactor);
        return hash;
    }

    public bool Verify(string password, string hash)
        => BCrypt.Net.BCrypt.EnhancedVerify(password, hash);
}