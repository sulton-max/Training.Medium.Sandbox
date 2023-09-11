namespace EntitiesSection.Services.Interfaces;

public interface IValidationService
{
    bool IsValidName(string name);

    bool IsValidEmailAddress(string emailAddress);

    bool IsValidPhoneNumber(string phoneNumber);
}