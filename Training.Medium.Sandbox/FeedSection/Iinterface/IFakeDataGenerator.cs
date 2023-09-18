using FeedSection.Model;

namespace FeedSection.Iinterface;

public interface IFakeDataGenerator
{
    public IEnumerable<Author> GetAuthor(int countOfData);
    public IEnumerable<Post> GetPost(int countOfData);
    public IEnumerable<PostDetails> GetPostDetails(int countOfData);
    public IEnumerable<FeedPost> GetFeedPost(int countOfData);
}