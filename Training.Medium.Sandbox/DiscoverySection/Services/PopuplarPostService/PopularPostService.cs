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
        public PopularPostService(IDataContext dataContext)
        {
            
        }

        public List<BlogPost> GetPopularPosts()
        {
            return new List<BlogPost>();
        }
    }
}
