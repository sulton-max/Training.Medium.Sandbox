using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscoverySection.Services.Models
{
    public class DiscoveryTopics
    {
        public DiscoveryTopics()
        {
            _topics = new List<string>();
        }
        public List<string> GetAllTopics()
        {
            return _topics.ToList();
        }
    }
}
