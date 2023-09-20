using DiscoverySection.Models;

namespace DiscoverySection.Services.DiscoveryService
{
    public interface IDiscoveryService
    {
        public ValueTask<DiscoveryTopics> GetMostCommonTopics();
    }
}
