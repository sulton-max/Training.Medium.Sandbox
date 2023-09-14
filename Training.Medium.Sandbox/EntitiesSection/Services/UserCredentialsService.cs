using EntitiesSection.Services.Interfaces;
using Shared.DataAccess.Contexts;
using Shared.Models.Entities;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

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
        await _appDataContext.UserCredentials.AddAsync(userCredentials);

        if (saveChanges)
            await _appDataContext.SaveChangesAsync();

        return userCredentials;
    }

    public ValueTask<UserCredentials> DeleteAsync(Guid id, bool saveChanges = true)
    {
        throw new NotImplementedException();
    }

    public ValueTask<UserCredentials> DeleteAsync(UserCredentials userCredentials, bool saveChanges = true)
    {
        throw new NotImplementedException();
    }

    public IQueryable<UserCredentials> Get(Expression<Func<UserCredentials, bool>> predicate)
    {
        return _appDataContext.UserCredentials.Where(predicate.Compile()).AsQueryable();
    }

    public ValueTask<ICollection<UserCredentials>> Get(IEnumerable<Guid> id)
    {
        throw new NotImplementedException();
    }

    public async ValueTask<UserCredentials> GetById(Guid id)
    {
        return await _appDataContext.UserCredentials.FindAsync(id);

    }

    public ValueTask<UserCredentials> UpdateAsync(UserCredentials userCredentials, bool saveChanges = true)
    {
        throw new NotImplementedException();
    }

    private bool IsValidCreatedUser(UserCredentials userCredentials)
    {
        var existingUserCredentials =
            _appDataContext.UserCredentials.FirstOrDefault(x => x.UserId == userCredentials.UserId);
        if (existingUserCredentials == null)
        {
            return false; 
        }
        return true;
    }
    private bool IsValidUpdatedUser(UserCredentials userCredentials, string newpassword)
    {
        var existingUserCRedintials =
            _appDataContext.UserCredentials.FirstOrDefault(x => x.UserId == userCredentials.UserId);
        if (existingUserCRedintials == null)
        {
            return false;
        }

        const string passwordPattern = @"^(.{0,7}|[^0-9]*|[^A-Z])$";
        if (!Regex.IsMatch(newpassword, passwordPattern))
        {
            return false;
        }
        return true;
    }
}
