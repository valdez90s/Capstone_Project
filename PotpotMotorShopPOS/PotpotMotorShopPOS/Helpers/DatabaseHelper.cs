using System.Configuration;
using System.Data;
using System.Data.SQLite;
using Npgsql;

public static class DatabaseHelper
{
    public static IDbConnection GetConnection(bool isOnline)
    {
        if (isOnline)
        {
            string postgresConnStr = ConfigurationManager.ConnectionStrings["PostgresConn"].ConnectionString;
            return new NpgsqlConnection(postgresConnStr);
        }
        else
        {
            string sqliteConnStr = ConfigurationManager.ConnectionStrings["SQLiteConn"].ConnectionString;
            return new SQLiteConnection(sqliteConnStr);
        }
    }
}