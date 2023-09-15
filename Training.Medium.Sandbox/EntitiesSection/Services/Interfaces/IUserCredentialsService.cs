﻿using Shared.Models.Entities;
using System.Linq.Expressions;

namespace EntitiesSection.Services.Interfaces;

public interface IUserCredentialsService
{
    IQueryable<UserCredentials> Get(Expression<Func<UserCredentials, bool>> predicate);

    ValueTask<ICollection<UserCredentials>> Get(IEnumerable<Guid> ids);

    ValueTask<UserCredentials> GetById(Guid id);

    ValueTask<UserCredentials> CreateAsync(UserCredentials userCredentials, bool saveChanges = true);

    ValueTask<UserCredentials> UpdateAsync(string oldPassword, UserCredentials userCredentials, bool saveChanges = true);

    ValueTask<UserCredentials> DeleteAsync(Guid id, bool saveChanges = true);

    ValueTask<UserCredentials> DeleteAsync(UserCredentials userCredentials, bool saveChanges = true);
}
