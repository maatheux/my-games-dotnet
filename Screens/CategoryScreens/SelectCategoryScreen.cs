using MyGames.Models;
using MyGames.Repositories;
using MyGames.Screens.OptionsScreens;

namespace MyGames.Screens.CategoryScreens;

public class SelectCategoryScreen
{
    public static void Load()
    {
        short selectOption;
        bool selectOptionValid;
        do
        {
            Console.Clear();
            Console.WriteLine("Categories list options:");
            Console.WriteLine("1 - Categories / 2 - Categories with linked games list / 3 - Back");

            selectOptionValid = short.TryParse(Console.ReadLine()!, out selectOption);

            if (!selectOptionValid)
            {
                Console.WriteLine("");
                Console.WriteLine("Insert a valid value...");
                Console.ReadKey();
            }
            
        } while (!selectOptionValid);

        switch (selectOption)
        {
            case 1:
                ListCategories();
                break;
            case 2:
                //
                break;
            case 3:
                SelectScreen.Load();
                break;
            default:
                Load();
                break;
        }
        
        Console.ReadKey();
        Load();
    }

    public static IEnumerable<Category> GetCategories()
    {
        Repository<Category> repository = new Repository<Category>();

        IEnumerable<Category> categoriesList = repository.ListAsync().Result;

        return categoriesList;
    }

    private static void ListCategories()
    {
        IEnumerable<Category> categoriesList = GetCategories();
        
        Console.Clear();
        Console.WriteLine("Categories List:");
        Console.WriteLine("-----------------------------");
        foreach (Category category in categoriesList)
        {
            Console.WriteLine($"Id: {category.Id} / Name: {category.Name}");
        }
    }
}