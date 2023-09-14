using EntitiesSection.Services.Interfaces;
using Shared.DataAccess.Contexts;
using Shared.Models.Entities;
using System.Linq.Expressions;

namespace EntitiesSection.Services
{
    public class PostService : IPostService
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

        private bool ValidateOnCreate(BlogPost blogPost)
        {
            var result = _appDataContext.Posts.FirstOrDefault(x => x.IsDeleted == false && x.Title == blogPost.Title && x.Content == blogPost.Content && x.AuthorId == blogPost.AuthorId && x.Id == blogPost.Id);
            return result != null;
        }

        private bool ValidateOnUpdate(BlogPost blogPost)
        {
            var existingPost = _appDataContext.Posts.FirstOrDefault(x => x.Id == blogPost.Id && x.IsDeleted == false);
            if (existingPost == null)
            {
                return false;
            }
            bool isTitleUnique = !_appDataContext.Posts.Any(x => 
                x.Id != blogPost.Id &&
                x.IsDeleted == false &&
                x.Title == blogPost.Title
            );
            if (!isTitleUnique)
            {
                return false;
            }
            return true;
        }

        private bool ValidatePost(BlogPost blogPost)
        {
            if (string.IsNullOrEmpty(blogPost.Title))
            {
                return false;
            }
            if (string.IsNullOrEmpty(blogPost.Content))
            {
                return false;
            }
            return true;
        }
    }
}
