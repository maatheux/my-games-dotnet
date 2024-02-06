using MyGames.Enums;
using MyGames.Models;
using MyGames.Repositories;
using MyGames.Screens.CompanyScreens;
using MyGames.Screens.OptionsScreens;

namespace MyGames.Screens.CategoryScreens;

public class DeleteCategoryScreen
{
    public static void Load()
    {
        short deleteOption;
        bool deleteOptionValid;
        do
        {
            Console.Clear();
            SelectCategoryScreen.ListCategories();
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
            GameCategoryRepository gameCategoryRepository = new GameCategoryRepository();
            await gameCategoryRepository.DeleteGameCategoryAsync(id);
            

            Repository<Category> categoryRepository = new Repository<Category>();

            await categoryRepository.DeleteAsync(id);
            
            Console.WriteLine("Category deleted successfully!");
        }
        catch (ArgumentException e)
        {
            Console.WriteLine("Publisher not found! Insert a valid Publisher Id...");
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