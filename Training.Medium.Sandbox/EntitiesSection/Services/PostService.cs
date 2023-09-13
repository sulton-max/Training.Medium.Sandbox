using EntitiesSection.Services.Interfaces;
using Shared.DataAccess.Contexts;
using Shared.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesSection.Services
{
    internal class PostService : IPostService
    {
        private readonly AppFileContext _appDataContext;
        //private readonly IValidationService _validationService;

        public PostService(AppFileContext appDataContext)    //IValidationService validationService
        {
            _appDataContext = appDataContext;
            //_validationService = validationService;
        }

        public async ValueTask<BlogPost> CreateAsync(BlogPost blogPost, bool saveChanges = true)
        {
            await _appDataContext.Posts.AddAsync(blogPost);

            if(saveChanges)
                await _appDataContext.SaveChangesAsync();
                
            return blogPost;
        }

        public async ValueTask<BlogPost> DeleteAsync(Guid id, bool saveChanges = true)
        {
            var foundPost = await GetByIdAsync(id);
            if (foundPost is null)
                throw new InvalidOperationException("You searched post not found");

            foundPost.IsDeleted = true;
            await _appDataContext.SaveChangesAsync();
            return foundPost;
        }

        public async ValueTask<BlogPost> DeleteAsync(BlogPost blogPost, bool saveChanges = true)
        {
            var foundPost = await GetByIdAsync(blogPost.Id);
            if (foundPost is null)
                throw new InvalidOperationException("You searched post not found");

            await _appDataContext.SaveChangesAsync();
            return foundPost;
        }

        public IQueryable<BlogPost> Get(Expression<Func<BlogPost, bool>> predicate)
        {
            return _appDataContext.Posts.Where(predicate.Compile()).AsQueryable();
        }

        public ValueTask<ICollection<BlogPost>> GetAsync(IEnumerable<Guid> ids)
        {
            var posts = _appDataContext.Posts.Where(post => ids.Contains(post.Id));
            return new ValueTask<ICollection<BlogPost>>(posts.ToList());
        }

        public ValueTask<BlogPost?> GetByIdAsync(Guid id)
        {
            var post = _appDataContext.Posts.FirstOrDefault(post => post.Id == id);
            return new ValueTask<BlogPost?>(post);
        }

        public async ValueTask<BlogPost> UpdateAsync(BlogPost blogPost, bool saveChanges = true)
        {
            var foundPost = _appDataContext.Posts.FirstOrDefault(serached =>  serached.Id == blogPost.Id);
            if (blogPost is null)
                throw new InvalidOperationException("Post not found!");

            foundPost.Title = blogPost.Title;
            foundPost.AuthorId = blogPost.AuthorId;
            foundPost.Content = blogPost.Content;

            await _appDataContext.SaveChangesAsync();
            return foundPost;
        }
    }
}
