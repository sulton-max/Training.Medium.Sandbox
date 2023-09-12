using EntitiesSection.Services.Interfaces;

namespace EntitiesSection.Services;

public class ValidationService : IValidationService
{
    public bool IsValidName(string name) => true;

    public bool IsValidEmailAddress(string emailAddress) => true;

    public bool IsValidPhoneNumber(string phoneNumber) => true;
}