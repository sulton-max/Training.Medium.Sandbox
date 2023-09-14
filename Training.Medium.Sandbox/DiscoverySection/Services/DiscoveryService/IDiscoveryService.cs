using DiscoverySection.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscoverySection.Services.DiscoveryService
{
    public interface IDiscoveryService
    {
        public List<DiscoveryTopics> GetMostCommonTopics();
    }
}
