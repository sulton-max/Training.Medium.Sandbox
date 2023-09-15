using Shared.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesSection.Services.Interfaces
{
    public interface IPostDetailsService
    {
        IQueryable<PostDetails> Get(Expression<Func<PostDetails, bool>> expression);
    }
}
