using Shared.Models.Common;

namespace Shared.Models.Entities;

public class UserCredentials : SoftDeletedEntity
{
    public string Password { get; set; }
    public Guid UserId { get; set; }

    public UserCredentials(string password, Guid userId)
    {
        Id = Guid.NewGuid();
        Password = password;
        UserId = userId;
        CreatedDate = DateTime.Now;
        DeletedDate = default(DateTime);
        IsDeleted = false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Password, UserId, CreatedDate, DeletedDate);
    }

    public override bool Equals(object? obj)
    {
        if (obj != null && obj is UserCredentials)
            return GetHashCode() == obj.GetHashCode();

        return false;
    }
}