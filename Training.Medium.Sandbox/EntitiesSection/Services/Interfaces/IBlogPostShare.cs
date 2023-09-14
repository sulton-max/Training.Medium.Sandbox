﻿using Shared.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesSection.Services.Interfaces
{
    public interface IBlogPostShare
    {
        IQueryable<BlogPostShare> Get(Expression<Func<BlogPostShare, bool>> predicate);

        ValueTask<ICollection<BlogPostShare>> GetAsync(IEnumerable<Guid> ids);

        ValueTask<BlogPostShare?> GetByIdAsync(Guid id);

        ValueTask<BlogPostShare> CreateAsync(BlogPostShare user, bool saveChanges = true);

        ValueTask<BlogPostShare> UpdateAsync(BlogPostShare user, bool saveChanges = true);

        ValueTask<BlogPostShare> DeleteAsync(Guid id, bool saveChanges = true);

        ValueTask<BlogPostShare> DeleteAsync(BlogPostShare user, bool saveChanges = true);
    }
}
