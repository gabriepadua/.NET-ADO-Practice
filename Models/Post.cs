using Dapper.Contrib.Extensions;

[Table("[Post]")]
public class Post
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public int CategoryId { get; set; }
}