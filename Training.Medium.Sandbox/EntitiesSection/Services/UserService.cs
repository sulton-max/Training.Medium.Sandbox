<<<<<<< HEAD
﻿using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using DiscoverySection.DataAccess;
using DiscoverySection.Models;
using EntitiesSection.Services.Interfaces;
=======
﻿using EntitiesSection.Services.Interfaces;
using Shared.DataAccess.Contexts;
>>>>>>> main

namespace EntitiesSection.Services
{
    public class UserService : IUserService
    {
<<<<<<< HEAD
        private readonly AppDataContext _appDataContext;
        private readonly ValidationService _validationService;
        private List<Exception> exceptions;

        public UserService(AppDataContext appDataContext, ValidationService validationService)
        {
            _appDataContext = appDataContext;
            _validationService = validationService;
        }

        public async ValueTask<User> CreateAsync(User user, bool saveChanges = true)
        {
            var validation = ValidateOnCreate(user);
            if (validation is not null) throw validation;

            await _appDataContext.Users.AddAsync(user);

            if (saveChanges)
                await _appDataContext.SaveChangesAsync();
            return user;

        }

        private ValidationException? ValidateOnCreate(User user)
        {
            if (!_validationService.IsValidName(user.FirstName + " " + user.LastName))
                exceptions.Add(new Exception("Invalid first name or last name"));

            if (!_validationService.IsValidEmailAddress(user.EmailAddress))
                exceptions.Add(new Exception());


            return new ValidationException();
        }


        public async ValueTask<User> DeleteAsync(Guid id, bool saveChanges = true)
        {
            var result = _appDataContext.Users.FirstOrDefault(user => user.Id == id).isDeleted = true;

            if (result is null)
                throw new Exception();

            _appDataContext.SaveChangesAsync();
            return result;
        }

        public async ValueTask<User> DeleteAsync(User user, bool saveChanges = true)
        {
            var result = _appDataContext.Users.FirstOrDefault(foundedUser => foundedUser.Equals(user)).isDeleted = true;
            if (result is null)
                throw new Exception();

            _appDataContext.SaveChangesAsync();
            return result;
        }

        public IQueryable<User> Get(Expression<Func<User, bool>> predicate)
        {
            return _appDataContext.Users.AsQueryable().Where(predicate.Compile());
        }

        public async ValueTask<ICollection<User>> Get(IEnumerable<Guid> id)
        {
            var result = _appDataContext.Users.FirstOrDefault(user => user).Where(user => user.Id.Equals(id));
            if (result is null)
                throw new Exception();

            return result;
        }

        public async ValueTask<User> GetById(Guid id)
        {
            var result = _appDataContext.Users.FirstOrDefault(user => user.Id == id);
            if (result is null)
                throw new Exception();

            return result;
        }

        public async ValueTask<User> UpdateAsync(User user, bool saveChanges = true)
        {
            //var result = _appDataContext.Users.FindAsync(user.Id);
            var result = _appDataContext.Users.FirstOrDefault(searchingUser => searchingUser.Id == user.Id);
            result.FirstName = user.FirstName;
            result.LastName = user.LastName;
            result.EmailAddress = user.EmailAddress;
            result.PhoneNumber = user.PhoneNumber;
            _appDataContext.SaveChangesAsync();
            return result;
=======
        private readonly AppFileContext _appDataContext;
        private readonly IValidationService _validationService;

        public UserService(AppFileContext appDataContext, IValidationService validationService)
        {
            _appDataContext = appDataContext;
            _validationService = validationService;
>>>>>>> main
        }

        public IQueryable<User> Get(Expression<Func<User, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public ValueTask<ICollection<User>> Get(IEnumerable<Guid> id)
        {
            throw new NotImplementedException();
        }

        public ValueTask<User> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public ValueTask<User> CreateAsync(User user, bool saveChanges = true)
        {
            throw new NotImplementedException();
        }

        public ValueTask<User> UpdateAsync(User user, bool saveChanges = true)
        {
            throw new NotImplementedException();
        }

        public ValueTask<User> DeleteAsync(Guid id, bool saveChanges = true)
        {
            throw new NotImplementedException();
        }

        public ValueTask<User> DeleteAsync(User user, bool saveChanges = true)
        {
            throw new NotImplementedException();
        }
    }
}
