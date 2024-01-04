using Microsoft.Data.SqlClient;

namespace MyGames;

public static class Database
{
    public static SqlConnection? Connection { get; set; }
}