using FeedSection.Service;

Console.WriteLine("================================");
var dataGenerator= new FakeDataGenerator();
var feed = dataGenerator.GetFeedPost(10);
foreach (var item in feed)
{
    Console.WriteLine(item);
}
