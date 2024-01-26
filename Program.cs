
using Microsoft.Data.SqlClient;
using MyGames;
using MyGames.Screens.OptionsScreens;

var userDb = System.Environment.GetEnvironmentVariable("USER_DB");
var passwordDb = System.Environment.GetEnvironmentVariable("PASSWORD_DB");

string CONNECTION_STRING = 
    $"Server=localhost,1433;Initial Catalog=MyGames;User ID={userDb};Password={passwordDb};TrustServerCertificate=true;";

Database.Connection = new SqlConnection(CONNECTION_STRING);

try
{
    Database.Connection.Open();
}
catch (Exception e)
{
    Console.WriteLine("Oops! It was not possible connect to database...");
    Console.WriteLine($"Error: {e.Message}");
}

OptionsScreen.Load();

Console.ReadKey();
Database.Connection.Close();
