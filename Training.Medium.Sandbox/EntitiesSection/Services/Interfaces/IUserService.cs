using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using
using DiscoverySection.Models;

namespace EntitiesSection.Services.Interfaces
{
    public interface IUserService
    {
        ValueTask<User> GetById(Guid Id)
        {

        }
    }
}
