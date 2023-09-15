using Shared.Models.Common;

namespace Shared.Models.Entities;

public class UserCredentials : SoftDeletedEntity
{
    public string Password { get; set; }
    public Guid UserId { get; init; }

    public UserCredentials(string password, Guid userId)
    {
        Id = Guid.NewGuid();
        Password = password;
        UserId = userId;
        CreatedDate = DateTime.UtcNow;
        IsDeleted = false;
    }

    public override string ToString()
    {
        return $"Password: {Password} \n" +
            $"UserId: {UserId} \n" +
            $"CreatedDate: {CreatedDate} \n" +
            $"ModifiedDate: {ModifiedDate} \n" +
            $"DeletedDate: {DeletedDate} \n" +
            $"IsDeleted: {IsDeleted}\n\n";
    }
}