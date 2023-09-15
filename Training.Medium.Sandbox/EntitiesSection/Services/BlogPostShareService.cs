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
    public class BlogPostShareService : IBlogPostShare
    {
        private readonly AppFileContext _appDataContext;
        private readonly IValidationService _validationService;

        public BlogPostShareService(AppFileContext appFileContext, IValidationService validationService)
        {
            _appDataContext = appFileContext;
            _validationService = validationService;
        }

        public IQueryable<BlogPostShare> Get(Expression<Func<BlogPostShare, bool>> predicate)
        {
            return _appDataContext.PostShares.Where(predicate.Compile()).AsQueryable();
        }

        public ValueTask<ICollection<BlogPostShare>> GetAsync(IEnumerable<Guid> ids)
        {
            var sharing = _appDataContext.PostShares.Where(sharings => ids.Contains(sharings.Id));
            return new ValueTask<ICollection<BlogPostShare>>(sharing.ToList());
        }

        public ValueTask<BlogPostShare?> GetByIdAsync(Guid id)
        {
            var sharing = _appDataContext.PostShares.FirstOrDefault(sharing => sharing.Id == id);
            return new ValueTask<BlogPostShare?>(sharing);
        }

        public async ValueTask<BlogPostShare> SendAsync(BlogPostShare sharing, bool saveChanges = true)
        {
            // var validation = ValidateOnCreate(user);
            // if (validation is not null) throw validation;

            await _appDataContext.PostShares.AddAsync(sharing);

            if (saveChanges)
                await _appDataContext.SaveChangesAsync();

            return sharing;
        }

       
        
        //private ValidationException? ValidateOnCreate(BlogPostShare sharing)
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
