using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using EntitiesSection.Services.Interfaces;
using Shared.DataAccess.Contexts;
using Shared.Models.Entities;

namespace EntitiesSection.Services;

public class UserService : IUserService
{
    private readonly IDataContext _appDataContext;
    private readonly IValidationService _validationService;

    public UserService(IDataContext appDataContext, IValidationService validationService)
    {
        _appDataContext = appDataContext;
        _validationService = validationService;
    }

    public IQueryable<User> Get(Expression<Func<User, bool>> predicate)
    {
        return _appDataContext.Users.Where(predicate.Compile()).AsQueryable();
    }

    public ValueTask<ICollection<User>> GetAsync(IEnumerable<Guid> ids)
    {
        var users = _appDataContext.Users.Where(user => ids.Contains(user.Id));
        return new ValueTask<ICollection<User>>(users.ToList());
    }

    public ValueTask<User?> GetByIdAsync(Guid id)
    {
        var user = _appDataContext.Users.FirstOrDefault(user => user.Id == id);
        return new ValueTask<User?>(user);
    }

    public async ValueTask<User> CreateAsync(User user, bool saveChanges = true)
    {
        // var validation = ValidateOnCreate(user);
        // if (validation is not null) throw validation;

        await _appDataContext.Users.AddAsync(user);

        if (saveChanges)
            await _appDataContext.SaveChangesAsync();

        return user;
    }

    public async ValueTask<User> UpdateAsync(User user, bool saveChanges = true)
    {
        var foundUser = _appDataContext.Users.FirstOrDefault(searchingUser => searchingUser.Id == user.Id);

        if (user is null)
            throw new InvalidOperationException("User not found");

        foundUser.FirstName = user.FirstName;
        foundUser.LastName = user.LastName;
        foundUser.EmailAddress = user.EmailAddress;
        foundUser.PhoneNumber = user.PhoneNumber;

        await _appDataContext.SaveChangesAsync();
        return foundUser;
    }

    public async ValueTask<User> DeleteAsync(User user, bool saveChanges = true)
    {
        var foundUser = await GetByIdAsync(user.Id);
        if (foundUser is null)
            throw new InvalidOperationException("User not found");

        await _appDataContext.SaveChangesAsync();
        return foundUser;
    }

    public async ValueTask<User> DeleteAsync(Guid id, bool saveChanges = true)
    {
        var foundUser = await GetByIdAsync(id);
        if (foundUser is null)
            throw new InvalidOperationException("User not found");

        foundUser.IsDeleted = true;
        await _appDataContext.SaveChangesAsync();
        return foundUser;
    }

    private ValidationException? ValidateOnCreate(User user)
    {
        var exceptions = new List<Exception>();
        if (!_validationService.IsValidName(user.FirstName + " " + user.LastName))
            exceptions.Add(new Exception("Invalid first name or last name"));

        if (!_validationService.IsValidEmailAddress(user.EmailAddress))
            exceptions.Add(new Exception());

        return new ValidationException();
    }
}