using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscoverySection.DataAccess;

namespace EntitiesSection.Services
{
    internal class UserService
    {
        private readonly AppDataContext _appDataContext;

        public UserService(AppDataContext appDataContext)
        {
            _appDataContext = appDataContext;
        }
    }
}
