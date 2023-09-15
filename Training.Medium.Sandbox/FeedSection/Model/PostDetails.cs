using Bogus;

namespace FeedSection;

public class PostDetails
{
    public List<PostDetails> _postDetails;
    
    public long Id { get; set; }
    public long PostId { get; set; }
    public bool IsMembershipPost { get; set; }
    public int Likes { get; set; }
    public int Comment {get; set; }
    public int ReadTime { get; set; }

    public PostDetails(int countOfFakeData)
    {
        int lastId = 1;
        var random = new Random();

        Faker<PostDetails> _fakePostDetails = new Faker<PostDetails>()
                        .RuleFor(postDetails => postDetails.Id, postDetails => lastId++)
                        .RuleFor(postDetails => postDetails.PostId, postDetails => random.Next(1, 50))
                        .RuleFor(postDetails => postDetails.IsMembershipPost, IsMembershipPost => IsMembershipPost.Random.Bool())
                        .RuleFor(postDetails => postDetails.Likes, Likes => random.Next(1, 500))
                        .RuleFor(postDetails => postDetails.Comment, Comment => random.Next(1, 100))
                        .RuleFor(postDetails => postDetails.ReadTime, ReadTime => random.Next(6, 17));
        
        _postDetails = _fakePostDetails.Generate(countOfFakeData);
    }

    public override string ToString()
    {
        return $"{Id} {PostId} {IsMembershipPost} {Likes} {Comment} {ReadTime}";
    }
}