using Shared.Models.Common;

namespace Shared.Models.Entities;

using FileContext.Abstractions.Models.Entity;

public class User : SoftDeletedEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EmailAddress { get; set; }
    public string PhoneNumber { get; set; }

    public User()
    {

    }

    public User(Guid id, string firstName, string lastName, string emailAddress, string phoneNumber)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        EmailAddress = emailAddress;
        PhoneNumber = phoneNumber;
        CreatedDate = DateTime.UtcNow;
        DeletedDate = default(DateTime);
        IsDeleted = false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(FirstName, LastName, CreatedDate, DeletedDate, PhoneNumber, EmailAddress);
    }

    public override bool Equals(object? obj)
    {
        return obj is User user && user.GetHashCode().Equals(GetHashCode());
    }

    public override string ToString()
    {
        return $"Id: {Id}, first name: {FirstName}, last name: {LastName}, email address: {EmailAddress}, phone: {PhoneNumber}";
    }
}