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
        }

        public static void ReadUsers()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var users = connection.GetAll<User>();

                foreach (var user in users)
                {
                    Console.WriteLine("user:", user.Name);
                }
            }
        }
    }
}
