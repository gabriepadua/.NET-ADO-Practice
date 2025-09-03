using Dapper.Contrib.Extensions;

[Table("[Category]")]
public class Category
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Slug { get; set; }
}