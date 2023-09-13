using Shared.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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
