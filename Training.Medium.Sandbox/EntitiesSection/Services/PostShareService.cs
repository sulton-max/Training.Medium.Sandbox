using EntitiesSection.Services.Interfaces;
using Shared.DataAccess.Contexts;
using Shared.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesSection.Services
{
    public class PostShareService : IPostShareService
    {
        private readonly IDataContext _appDataContext;
        private readonly IValidationService _validationService;

        public PostShareService(IDataContext appFileContext, IValidationService validationService)
        {
            _appDataContext = appFileContext;
            _validationService = validationService;
        }

        public IQueryable<PostShare> Get(Expression<Func<PostShare, bool>> predicate)
        {
            return _appDataContext.PostShares.Where(predicate.Compile()).AsQueryable();
        }

        public ValueTask<ICollection<PostShare>> GetAsync(IEnumerable<Guid> ids)
        {
            var sharing = _appDataContext.PostShares.Where(sharings => ids.Contains(sharings.Id));
            return new ValueTask<ICollection<PostShare>>(sharing.ToList());
        }

        public ValueTask<PostShare?> GetByIdAsync(Guid id)
        {
            var sharing = _appDataContext.PostShares.FirstOrDefault(sharing => sharing.Id == id);
            return new ValueTask<PostShare?>(sharing);
        }

        public async ValueTask<PostShare> SendAsync(PostShare sharing, bool saveChanges = true)
        {
            // var validation = ValidateOnCreate(user);
            // if (validation is not null) throw validation;

            await _appDataContext.PostShares.AddAsync(sharing);

            if (saveChanges)
                await _appDataContext.SaveChangesAsync();

            return sharing;
        }

        private bool isValidSendingPost(PostShare sharing)
        {
            var validationSharingPost = _appDataContext.PostShares.FirstOrDefault(x => x.UserId == sharing.UserId && x.PostId == sharing.PostId);
            if (validationSharingPost != null)
            {
                return true;
            }
            return false;
        }

       
        
        //private ValidationException? ValidateOnCreate(PostShare sharing)
        //{
        //    var exceptions = new List<Exception>();
        //    if (!_validationService.IsValidName(sharing.FirstName + " " + sharing.LastName))
        //        exceptions.Add(new Exception("Invalid first name or last name"));

        //    if (!_validationService.IsValidEmailAddress(sharing.EmailAddress))
        //        exceptions.Add(new Exception());

        //    return new ValidationException();
        //}

    }
}
