using Shared.Models.Entities;
using System.Linq.Expressions;

namespace EntitiesSection.Services.Interfaces
{
    public interface IPostService
    {
        IQueryable<BlogPost> Get(Expression<Func<BlogPost, bool>> predicate);

        ValueTask<ICollection<BlogPost>> GetAsync(IEnumerable<Guid> ids);

        ValueTask<BlogPost?> GetByIdAsync(Guid id);

        ValueTask<BlogPost> CreateAsync(BlogPost blogPost, bool saveChanges = true);

        ValueTask<BlogPost> UpdateAsync(BlogPost blogPost, bool saveChanges = true);

        ValueTask<BlogPost> DeleteAsync(Guid id, bool saveChanges = true);

        ValueTask<BlogPost> DeleteAsync(BlogPost blogPost, bool saveChanges = true);
    }
}
