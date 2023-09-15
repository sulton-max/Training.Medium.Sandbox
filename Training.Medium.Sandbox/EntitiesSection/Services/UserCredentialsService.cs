using EntitiesSection.Services.Interfaces;
using Shared.DataAccess.Contexts;
using Shared.Models.Entities;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace EntitiesSection.Services;

public class UserCredentialsService : IUserCredentialsService
{
    private readonly AppFileContext _appDataContext;
    private readonly IValidationService _validationService;

    public UserCredentialsService(AppFileContext appDataContext, IValidationService validationService)
    {
        _appDataContext = appDataContext;
        _validationService = validationService;
    }

    public async ValueTask<UserCredentials> CreateAsync(UserCredentials userCredentials, bool saveChanges = true)
    {
        if (!ValidateOnCreate(userCredentials))
            throw new ValidationException("Invalid user credentials!");

        userCredentials.Password = PasswordHasher.Hash(userCredentials.Password);
        await _appDataContext.UserCredentials.AddAsync(userCredentials);

        if (saveChanges)
            await _appDataContext.UserCredentials.SaveChangesAsync();

        return userCredentials;
    }

    public async ValueTask<UserCredentials> DeleteAsync(Guid id, bool saveChanges = true)
    {
        var oldCredentials = await GetById(id);
        if (oldCredentials.IsDeleted)
            throw new InvalidOperationException("User credentials is already Deleted!");

        oldCredentials.IsDeleted = true;
        oldCredentials.DeletedDate = DateTime.UtcNow;

        if (saveChanges)
            await _appDataContext.UserCredentials.SaveChangesAsync();
        return oldCredentials;
    }

    public async ValueTask<UserCredentials> DeleteAsync(UserCredentials userCredentials, bool saveChanges = true)
        => await DeleteAsync(userCredentials.Id, saveChanges);
    

    public IQueryable<UserCredentials> Get(Expression<Func<UserCredentials, bool>> predicate)
        => _appDataContext.UserCredentials.Where(predicate.Compile()).AsQueryable();
    

    public ValueTask<ICollection<UserCredentials>> Get(IEnumerable<Guid> ids)
    {
        var userCredentials = _appDataContext.UserCredentials
            .Where(credentials => ids.Contains(credentials.Id));

        return new ValueTask<ICollection<UserCredentials>>(userCredentials.ToList());
    }

    public async ValueTask<UserCredentials> GetById(Guid id)
    {
        var userCredentials = await _appDataContext.UserCredentials.FindAsync(id);
        //var userCredentials = _appDataContext.UserCredentials.FirstOrDefault(credentials => credentials.Id == id);
        if (userCredentials == null)
            throw new ArgumentOutOfRangeException(nameof(id), "User Credentails with the given id not found!");

        return userCredentials;
    }

    public async ValueTask<UserCredentials> UpdateAsync(string oldPassword, UserCredentials userCredentials, bool saveChanges = true)
    {
        if (!ValidateOnUpdate(userCredentials))
            throw new ValidationException("Invalid user credentials!");

        var oldCredentials = await GetById(userCredentials.Id);
        if (!PasswordHasher.Verify(oldPassword, oldCredentials.Password))
            throw new ArgumentOutOfRangeException(nameof(oldPassword), "Incorrect old Password!");

        oldCredentials.Password = PasswordHasher.Hash(userCredentials.Password);
        oldCredentials.ModifiedDate = DateTime.UtcNow;

        if (saveChanges)
            await _appDataContext.UserCredentials.SaveChangesAsync();

        return oldCredentials;
    }

    private bool UserCredentialExists(Guid id)
        => _appDataContext.UserCredentials.Any(credentials => credentials.Id == id);

    private bool ValidateOnCreate(UserCredentials userCredentials)
    {
        if (UserCredentialExists(userCredentials.Id))
            throw new InvalidOperationException("User Credentials already exists!");

        if (_appDataContext.UserCredentials.Any(credentials => credentials.UserId == userCredentials.UserId))
            throw new InvalidOperationException("The given user already has credentials!");

        ValidatePassword(userCredentials.Password);
        return true;
    }

    private bool ValidateOnUpdate(UserCredentials userCredentials)
    {
        if (!UserCredentialExists(userCredentials.Id))
            throw new InvalidOperationException("User Credentials not found!");

        ValidatePassword(userCredentials.Password);
        return true;
    }

    private void ValidatePassword(string password)
    {
        if (password.Length < 8)
            throw new ArgumentOutOfRangeException(nameof(password), "Password must contain at least 8 characters!");
    }
}