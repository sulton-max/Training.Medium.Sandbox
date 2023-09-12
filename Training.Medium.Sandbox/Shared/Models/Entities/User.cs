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
        return HashCode.Combine(this.Id + this.FirstName, this.LastName, this.CreatedDate, this.DeletedDate, this.PhoneNumber, this.EmailAddress);
    }

    public override bool Equals(object? obj)
    {
        return this.GetHashCode().Equals(obj.GetHashCode());
    }

    public override string ToString()
    {
        return $"Id: {Id}, first name: {FirstName}, last name: {LastName}, email address: {EmailAddress}, phone: {PhoneNumber}";
    }
}