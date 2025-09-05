public static class DeleteTagScreen
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("Excluir tag");
        Console.WriteLine("Insira o Id: ");
        var id = Console.ReadLine() ?? string.Empty;
        Console.WriteLine();
        Delete(int.Parse(id));
        MenuTagScreen.Load();
        Console.ReadKey();
    }

    public static void Delete(int id)
    {
        try
        {
            var repository = new Repository<Tag>(Database.Connection);
            repository.Delete(id);
            Console.WriteLine("Tag deletada com sucessso");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
