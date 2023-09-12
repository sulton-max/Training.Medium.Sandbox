using EntitiesSection.Models.Common;
using FileContext.Abstractions.Models.Entity;

namespace EntitiesSection.Models;

public class User : SoftDeletedEntity, IFileSetEntity<Guid>
{
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string emailAddress { get; set; }
    public string phoneNumber { get; set; }

    public User(Guid id, string firstName, string lastName, string emailAddress, string phoneNumber)
    {
        base.Id = id;
        this.firstName = firstName;
        this.lastName = lastName;
        this.emailAddress = emailAddress;
        this.phoneNumber = phoneNumber;
        this.CreatedDate = DateTime.UtcNow;
        DeletedDate = default(DateTime);
        IsDeleted = false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(this.Id + this.firstName, this.lastName, this.CreatedDate, this.DeletedDate, this.phoneNumber, this.emailAddress);
    }

    public override bool Equals(object? obj)
    {
        return this.GetHashCode().Equals(obj.GetHashCode());
    }

    public override string ToString()
    {
        return $"Id: {Id}, first name: {firstName}, last name: {lastName}, email address: {emailAddress}, phone: {phoneNumber}";
    }
}
