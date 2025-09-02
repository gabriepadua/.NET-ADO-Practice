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

            // ReadUsers();
            // ReadUser();
            // CreateUser();
            // UpdateUser();
            DeleteUser();

        }

        public static void ReadUsers()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var users = connection.GetAll<User>();

                foreach (var user in users)
                {
                    Console.WriteLine($"user: {user.Name}");
                }
            }
        }
        public static void ReadUser()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var user = connection.Get<User>(1);
                Console.WriteLine($"user: {user.Name}");
            }
        }
        public static void CreateUser()
        {
            var user = new User()
            {
                Bio = "Devlo",
                Email = "hello@balta.io",
                Image = "https://",
                Name = "Teste Balta",
                PasswordHash = "HASH",
                Slug = "equipe-teste"

            };
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Insert<User>(user);
                Console.WriteLine("Cadastrado com sucesso");
            }
        }
        public static void UpdateUser()
        {
            var user = new User()
            {
                Id = 4,
                Bio = "BALTA IO EDITADO",
                Email = "hello@baltaEDITADO.io",
                Image = "https://",
                Name = "Teste EDITADOBalta",
                PasswordHash = "HASH",
                Slug = "equipe-teste2"

            };
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Update<User>(user);
                Console.WriteLine("Atualizado com sucesso");
            }
        }
        public static void DeleteUser()
        {

            using (var connection = new SqlConnection(connectionString))
            {
                var user = connection.Get<User>(4);
                connection.Delete<User>(user);
                Console.WriteLine("Exclusão com sucesso");
            }
        }
    }
}
