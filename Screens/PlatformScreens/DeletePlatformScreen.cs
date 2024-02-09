using MyGames.Models;
using MyGames.Repositories;
using MyGames.Screens.OptionsScreens;

namespace MyGames.Screens.PlatformScreens;

public class DeletePlatformScreen
{
    public static void Load()
    {
        short deleteOption;
        bool deleteOptionValid;
        do
        {
            Console.Clear();
            SelectPlatformScreen.ListPlatforms();
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

        DeletePlatform(deleteOption);

        Console.ReadKey();
        DeleteScreen.Load();
    }

    private static async Task DeletePlatform(int id)
    {
        try
        {
            GamePlatformRepository gamePlatformRepository = new GamePlatformRepository();
            await gamePlatformRepository.DeleteGamePlatformByPlatformId(id);

            Repository<Platform> platformRepository = new Repository<Platform>();
            await platformRepository.DeleteAsync(id);

            Console.WriteLine("Platform deleted successfully!");
        }
        catch (ArgumentException e)
        {
            Console.WriteLine("Platform not found! Insert a valid Platform Id...");
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