using System.Linq.Expressions;
using EntitiesSection.Services.Interfaces;
using Shared.DataAccess.Contexts;
using Shared.Models.Entities;

namespace EntitiesSection.Services
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
