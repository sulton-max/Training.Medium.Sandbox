using Shared.Models.Common;

namespace Shared.Models.Entities;

public class User : SoftDeletedEntity
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EmailAddress { get; set; }

    public User(string FirstName, string LastName, string EmailAddress)
    {
        Id = Guid.NewGuid();
        base.IsDeleted = false;
        this.FirstName = FirstName;
        this.LastName = LastName;
        this.EmailAddress = EmailAddress;
    }



}