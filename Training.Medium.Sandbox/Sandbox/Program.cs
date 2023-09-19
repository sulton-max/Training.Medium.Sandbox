using FeedSection;
using FeedSection.Service;

Console.WriteLine("================================");
var dataGenerator= new FakeDataGenerator();
var feed = dataGenerator.GetPostDetails(10);
foreach (var item in feed)
{
    Console.WriteLine(item);
}
