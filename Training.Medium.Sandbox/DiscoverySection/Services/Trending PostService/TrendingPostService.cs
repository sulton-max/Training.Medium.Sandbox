using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.DataAccess.Contexts;
using Shared.Models.Entities;

namespace DiscoverySection.Services.Trending_PostService
{
    public class TrendingPostService : ITrendingPostService
    {
        private readonly AppFileContext _appDataContext;
        public TrendingPostService(AppFileContext appDataContext)
        {
            _appDataContext = appDataContext;
        }
        public List<BlogPost> GetTrendingPosts()
        {
            _ = _appDataContext.FetchAsync();
            var TrendingPosts = _appDataContext.Posts.Select(post => post);
            TrendingPosts = (IEnumerable<BlogPost>)(from Post in _appDataContext.Posts
                                join View in _appDataContext.PostViews on Post.Id equals View.Id
                                    join Clap in _appDataContext.PostFeedbacks on Post.Id equals Clap.PostId
                                        join Savings in _appDataContext.PostShares on Post.Id equals Savings.BlogPostId
                                select new { Posts = Post, Views = View, Feedbacks = Clap, PostShares = Savings }).ToList();
            
            //TrendingPosts = _appDataContext.PostViews.GroupJoin(Posts, Views => Views,
            //    Posts => Posts.)
            return new List<BlogPost>();
        }
    }
}
