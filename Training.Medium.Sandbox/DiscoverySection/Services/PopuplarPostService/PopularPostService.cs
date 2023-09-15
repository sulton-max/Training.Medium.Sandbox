using Shared.DataAccess.Contexts;
using Shared.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Models.Entities;

namespace DiscoverySection.Services.PopuplarPostService
{
    public class PopularPostService : IPopularPostService
    {
        private readonly IDataContext dataContext;

        public PopularPostService(IDataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public List<BlogPost> GetPopularPosts()
        {
            var LateMonthPosts = dataContext.Posts.Where(post => post.IsDeleted != true && post.CreatedDate <= post.CreatedDate.AddMonths(1)).Take(10).ToList();


            //dataContext.Posts.Where(post => post.IsDeleted != true && post.CreatedDate <= post.CreatedDate.AddMonths(1)).Take(10);

            return new List<BlogPost>();
        }
    }
}
