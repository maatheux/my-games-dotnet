using MyGames.Models;
using MyGames.Repositories;
using MyGames.Screens.OptionsScreens;

namespace MyGames.Screens.CompanyScreens;

public class DeleteCompanyScreen
{
    public static void Load()
    {
        short deleteOption;
        bool deleteOptionValid;
        do
        {
            Console.Clear();
            SelectCompanyScreen.Load(false);
            Console.WriteLine("");
            Console.WriteLine("Insert a valid Id to delete:");

            deleteOptionValid = short.TryParse(Console.ReadLine()!, out deleteOption);

            if (!deleteOptionValid)
            {
                Console.WriteLine("");
                Console.WriteLine("Insert a valid value...");
                Console.ReadKey();
            }
            
        } while (!deleteOptionValid);

        DeleteCompany(deleteOption);
        
        Console.ReadKey();
        DeleteScreen.Load();

    }

    private static async Task DeleteCompany(short id)
    {
        try
        {
            Repository<Company> repository = new Repository<Company>();

            await repository.DeleteAsync(id);
            
            Console.WriteLine("Company deleted successfully!");
        }
        catch (ArgumentException e)
        {
            Console.WriteLine("Company not found! Insert a valid Publisher Id...");
            throw;
        }
        catch (Microsoft.Data.SqlClient.SqlException e)
        {
            Console.WriteLine("");
            Console.WriteLine("Delete query was not executed. An error was found...");
            Console.WriteLine($"Error message: {e.Message}");
            throw;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}