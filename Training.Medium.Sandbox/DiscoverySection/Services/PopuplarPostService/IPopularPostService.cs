using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Models.Entities;

namespace DiscoverySection.Services.PopuplarPostService
{
    public interface IPopularPostService
    {
        public List<BlogPost> GetPopularPosts();
    }
}
