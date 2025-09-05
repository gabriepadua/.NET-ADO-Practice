using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using Dapper.Contrib.Extensions;

namespace Program
{
    class Program
    {
        private static string connectionString = string.Empty;
        static void Main(string[] args)
        {

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("app.settings.json", optional: false, reloadOnChange: true);

            IConfiguration configuration = builder.Build();
            connectionString = configuration.GetConnectionString("DefaultConnection")!;
            Database.Connection = new SqlConnection(connectionString);
            Database.Connection.Open();

            // ReadUsers(connection);
            // ReadUsersWithRoles(connection);
            // CreateUsers(connection);
            // ReadRoles(connection);
            // ReadTags(connection);
            // CreateUser();
            // UpdateUser();
            // DeleteUser();

            Load();
            Console.ReadKey();
            Database.Connection.Close();
        }

        private static void Load()
        {
            Console.Clear();
            Console.WriteLine("Meu Blog");
            Console.WriteLine("-----------------");
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine();
            Console.WriteLine("1 - Gestão de usuário");
            Console.WriteLine("2 - Gestão de perfil");
            Console.WriteLine("3 - Gestão de categoria");
            Console.WriteLine("4 - Gestão de tag");
            Console.WriteLine("5 - Vincular perfil/usuário");
            Console.WriteLine("6 - Vincular post/tag");
            Console.WriteLine("7 - Relatórios");
            Console.WriteLine();
            Console.WriteLine();
            var option = short.Parse(Console.ReadLine()!);

            switch (option)
            {
                case 4:
                    MenuTagScreen.Load();
                    break;
                default: Load(); break;
            }
        }

        public static void ReadUsers(SqlConnection connection)
        {

            var repository = new Repository<User>(connection);
            var items = repository.GetAll();
            foreach (var item in items)
            {
                Console.WriteLine(item.Name);
                foreach (var role in item.Roles)
                {
                    Console.WriteLine($" - {role.Name}");
                }
            }
        }
        public static void CreateUsers(SqlConnection connection)
        {

            var user = new User()
            {
                Email = "gabriel@padua2.com",
                Bio = "bio2",
                Image = "Image2",
                Name = "Nome GABRIEL2",
                PasswordHash = "TesteHash2",
                Slug = "slug2"
            };
            var repository = new Repository<User>(connection);
            repository.Create(user);
        }
        public static void ReadRoles(SqlConnection connection)
        {

            var repository = new Repository<Role>(connection);
            var items = repository.GetAll();
            foreach (var item in items)
            {
                Console.WriteLine(item.Name);
            }
        }
        public static void ReadTags(SqlConnection connection)
        {

            var repository = new Repository<Tag>(connection);
            var items = repository.GetAll();
            foreach (var item in items)
            {
                Console.WriteLine(item.Name);
            }
        }

        private static void ReadUsersWithRoles(SqlConnection connection)
        {
            var repository = new UserRepository(connection);
            var items = repository.ReadWithRole();
            foreach (var item in items)
            {
                Console.WriteLine(item.Name);
                foreach (var role in item.Roles)
                {
                    if (role != null)
                        Console.WriteLine($" - {role.Name}");
                }
            }
        }
    }
}
