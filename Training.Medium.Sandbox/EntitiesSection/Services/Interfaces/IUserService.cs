using System.Linq.Expressions;
using Shared.Models.Entities;

namespace EntitiesSection.Services.Interfaces
{
    public interface IUserService
    {
        IQueryable<User> Get(Expression<Func<User, bool>> predicate);

        ValueTask<ICollection<User>> Get(IEnumerable<Guid> id);

        ValueTask<User> GetById(Guid id);

        public ValueTask<User> CreateAsync(User user, bool saveChanges = true);

        ValueTask<User> UpdateAsync(User user, bool saveChanges = true);

        ValueTask<User> DeleteAsync(Guid id, bool saveChanges = true);

        ValueTask<User> DeleteAsync(User user, bool saveChanges = true);
    }
}
