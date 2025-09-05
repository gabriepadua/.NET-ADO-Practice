public static class UpdateTagScreen
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("Atualizando tag");
        Console.WriteLine("Insira o Id: ");
        var id = Console.ReadLine();
        Console.WriteLine("Insira o nome: ");
        var name = Console.ReadLine();
        Console.WriteLine("Insira o slug: ");
        var slug = Console.ReadLine();
        Console.WriteLine();
        Update(new Tag
        {
            Id = int.Parse(id),
            Name = name,
            Slug = slug
        });
        MenuTagScreen.Load();
        Console.ReadKey();
    }

    public static void Update(Tag tag)
    {
        try
        {
            var repository = new Repository<Tag>(Database.Connection);
            repository.Update(tag);
            Console.WriteLine("Tag atualizada com sucessso");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}