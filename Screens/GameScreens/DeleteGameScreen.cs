using MyGames.Models;
using MyGames.Repositories;
using MyGames.Screens.OptionsScreens;

namespace MyGames.Screens.GameScreens;

public class DeleteGameScreen
{
    public static void Load()
    {
        int deleteOption;
        bool deleteOptionValid;
        do
        {
            Console.Clear();
            SelectGameScreen.ListGames();
            Console.WriteLine("");
            Console.WriteLine("Insert a valid Id to delete:");

            deleteOptionValid = int.TryParse(Console.ReadLine()!, out deleteOption);

            if (!deleteOptionValid)
            {
                Console.WriteLine("");
                Console.WriteLine("Insert a valid value...");
                Console.ReadKey();
            }
            
        } while (!deleteOptionValid);

        DeleteGame(deleteOption);

        Console.ReadKey();
        DeleteScreen.Load();

    }

    private static async Task DeleteGame(int id)
    {
        try
        {
            GameCategoryRepository gameCategoryRepository = new GameCategoryRepository();
            await gameCategoryRepository.DeleteGameCategoryByGameIsAsync(id);

            GamePlatformRepository gamePlatformRepository = new GamePlatformRepository();
            await gamePlatformRepository.DeleteGamePlatformByGameId(id);

            Repository<Game> gameRepository = new Repository<Game>();
            await gameRepository.DeleteAsync(id);
            
            Console.WriteLine("Game deleted successfully!");

        }
        catch (ArgumentException e)
        {
            Console.WriteLine("Game not found! Insert a valid Game Id...");
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