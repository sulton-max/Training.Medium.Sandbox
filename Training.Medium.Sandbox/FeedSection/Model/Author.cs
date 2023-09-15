using Bogus;

namespace FeedSection;

public class Author
{
    public List<Author> _authors;
    
    public long Id { get; set; }
    public string FullName { get; set; }
    public string About { get; set; }

    public Author()
    {
        
    }
    
    public Author(int count)
    {
        _authors = GetFakeAuthors(count);
    }


    private static List<Author> GetFakeAuthors(int countOfFakes)
    {
        int lastId = 1;
        
        Faker<Author> _fakeAuthors = new Faker<Author>()
                        .RuleFor(author => author.Id, author => lastId++)
                        .RuleFor(author => author.FullName, FullName => FullName.Person.FullName)
                        .RuleFor(author => author.About, About => About.Lorem.Letter(10));
        
        return _fakeAuthors.Generate(countOfFakes);
    }
    public override string ToString()
    {
        return $"{Id} {FullName} {About}";
    }
}