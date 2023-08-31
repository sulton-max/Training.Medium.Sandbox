using System.Text.Json;
using DiscoverySection.Data;
using DiscoverySection.DataAccess;

var dataContext = new AppDataContext();
await dataContext.InitializeAsync();

Console.WriteLine(JsonSerializer.Serialize(dataContext.Posts));

// popularity measurements

// trending - the most viewed category
// viral - the most liked/disliked category
// popular - the most posted category


