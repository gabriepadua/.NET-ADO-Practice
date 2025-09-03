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

            ReadUsers(connection);
            ReadRoles(connection);
            ReadTags(connection);
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
            }
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
    }
}
