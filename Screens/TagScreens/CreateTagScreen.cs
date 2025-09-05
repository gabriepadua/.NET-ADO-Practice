public static class CreateTagScreen
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("Nova tag");
        Console.WriteLine("Insira o nome: ");
        var name = Console.ReadLine() ?? string.Empty;
        Console.WriteLine("Insira o slug: ");
        var slug = Console.ReadLine();
        Console.WriteLine();
        Create(new Tag
        {
            Name = name,
            Slug = slug
        });
        MenuTagScreen.Load();
        Console.ReadKey();
    }

    public static void Create(Tag tag)
    {
        try
        {
            var repository = new Repository<Tag>(Database.Connection);
            repository.Create(tag);
            Console.WriteLine("Tag cadastrada com sucesso!");
        }
        catch (Exception ex)
        {

            Console.WriteLine(ex.Message);
        }
    }
}