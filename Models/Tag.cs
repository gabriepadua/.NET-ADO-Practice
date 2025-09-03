using Dapper.Contrib.Extensions;

[Table("[Tag]")]
public class Tag
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Slug { get; set; }
}