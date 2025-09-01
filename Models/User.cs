public class User
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string ?Email { get; set; }
    public required string ?PasswordHash { get; set; }
    public string? Bio { get; set; }
    public string? Image { get; set; }
    public string? Slug{ get; set; }
}
