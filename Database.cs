using Microsoft.Data.SqlClient;

public static class Database
{
    public static SqlConnection Connection = new SqlConnection("sua-connection-string");
}