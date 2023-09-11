using EntitiesSection.Services.Interfaces;
using Shared.DataAccess.Contexts;

namespace EntitiesSection.Services
{
    internal class UserService
    {
        private readonly AppFileContext _appDataContext;
        private readonly IValidationService _validationService;

        public UserService(AppFileContext appDataContext, IValidationService validationService)
        {
            _appDataContext = appDataContext;
            _validationService = validationService;
        }
    }
}
