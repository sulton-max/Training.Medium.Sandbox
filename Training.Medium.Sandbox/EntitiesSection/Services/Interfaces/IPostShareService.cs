using Shared.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesSection.Services.Interfaces
{
    public interface IPostShareService
    {
        IQueryable<PostShare> Get(Expression<Func<PostShare, bool>> predicate);

        ValueTask<ICollection<PostShare>> GetAsync(IEnumerable<Guid> ids);

        ValueTask<PostShare?> GetByIdAsync(Guid id);

        ValueTask<PostShare> SendAsync(PostShare user, bool saveChanges = true);
        
    }
}
