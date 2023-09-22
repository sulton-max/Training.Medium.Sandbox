using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using EntitiesSection.Services.Interfaces;


using Shared.Models.Entities;

namespace EntitiesSection.Services
{
    public class SavedPostService : ISavedPostService
    {
        //List
        private readonly List<SavedPost> _savedPosts = new List<SavedPost>();

        //AddToSaveAsync Methodi
        public async ValueTask<SavedPost> AddToSaveAsync(User user, bool saveChanges = true)
        {
            var savedPost = new SavedPost
            {
                Id = Guid.NewGuid(), 
                UserId = user.Id, 
                PostId = Guid.NewGuid()
            };

            _savedPosts.Add(savedPost);
            return await Task.FromResult(savedPost);
        }

        //DeleteSaveAsync methodi
        public async ValueTask<SavedPost> DeleteSaveAsync(User user, bool saveChanges = true)
        {
            var savedPost = _savedPosts.FirstOrDefault(sp => sp.UserId == user.Id);
            if (savedPost == null)
            {
                throw new InvalidOperationException("Saved post not found.");
            }

            _savedPosts.Remove(savedPost);

            return await Task.FromResult(savedPost);
        }

        //Get methodi
        public IQueryable<SavedPost> Get(Expression<Func<SavedPost, bool>> predicate)
        {
            return _savedPosts.AsQueryable().Where(predicate);
        }

        //GetByIdAsync methodi
        public async ValueTask<SavedPost?> GetByIdAsync(Guid id)
        {
            return await Task.FromResult(_savedPosts.FirstOrDefault(sp => sp.Id == id));
        }

        //GetByUserIdAsync methodi
        public async ValueTask<ICollection<SavedPost>> GetByUserIdAsync(IEnumerable<Guid> ids)
        {
            var idList = ids.ToList();
            return await Task.FromResult(_savedPosts.Where(sp => idList.Contains(sp.UserId)).ToList());
        }
    }
}
