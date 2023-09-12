using FileContext.Abstractions.Models.Entity;
using Shared.Models.Common;

namespace Shared.Models.Entities;

public class User : SoftDeletedEntity, IFileSetEntity<Guid>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EmailAddress { get; set; }
    

    public User()
    {
    }

    public User(string firstName, string lastName, string emailAddress)
    {
        Id = Guid.NewGuid();
        FirstName = firstName;
        LastName = lastName;
        EmailAddress = emailAddress;
        IsDeleted = false;
    }
}