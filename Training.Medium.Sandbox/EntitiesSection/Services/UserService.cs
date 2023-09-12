using System.Linq.Expressions;
using EntitiesSection.Services.Interfaces;
using Shared.DataAccess.Contexts;
using Shared.Models.Entities;

namespace EntitiesSection.Services
{
    public class UserService : IUserService
    {
        private readonly AppFileContext _appDataContext;
        private readonly IValidationService _validationService;

        public UserService(AppFileContext appDataContext, IValidationService validationService)
        {
            _appDataContext = appDataContext;
            _validationService = validationService;
        }

        public IQueryable<User> Get(Expression<Func<User, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public ValueTask<ICollection<User>> Get(IEnumerable<Guid> id)
        {
            throw new NotImplementedException();
        }

        public ValueTask<User> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public ValueTask<User> CreateAsync(User user, bool saveChanges = true)
        {
            throw new NotImplementedException();
        }

        public ValueTask<User> UpdateAsync(User user, bool saveChanges = true)
        {
            throw new NotImplementedException();
        }

        public ValueTask<User> DeleteAsync(Guid id, bool saveChanges = true)
        {
            throw new NotImplementedException();
        }

        public ValueTask<User> DeleteAsync(User user, bool saveChanges = true)
        {
            throw new NotImplementedException();
        }
    }
}
