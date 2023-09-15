using EntitiesSection.Services.Interfaces;
using Shared.DataAccess.Contexts;
using Shared.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesSection
{
    public class PostDetailsService : IPostDetailsService
    {
        private readonly IDataContext dataContext;

        public PostDetailsService(IDataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public IQueryable<PostDetails> Get(Expression<Func<PostDetails, bool>> predicate)
        {
            return dataContext.PostDetails.Where(predicate.Compile()).AsQueryable();
        }
    }
}
