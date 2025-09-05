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
            var connection = new SqlConnection(connectionString);
            connection.Open();

            // ReadUsers(connection);
            ReadUsersWithRoles(connection);
            // CreateUsers(connection);
            // ReadRoles(connection);
            // ReadTags(connection);
            // CreateUser();
            // UpdateUser();
            // DeleteUser();

            connection.Close();
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
