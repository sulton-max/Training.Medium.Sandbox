using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscoverySection.DataAccess;
using EntitiesSection.Services.Interfaces;

namespace EntitiesSection.Services
{
    internal class UserService
    {
        private readonly AppDataContext _appDataContext;
        private readonly IValidationService _validationService;

        public UserService(AppDataContext appDataContext, IValidationService validationService)
        {
            _appDataContext = appDataContext;
            _validationService = validationService;
        }

        private bool ValidateUserOnCreate(User user)
        {
            var list = new List<string>();


            throw new ValidationException(string.Join(',', list));
        }
    }
}
