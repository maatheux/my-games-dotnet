using MyGames.Enums;
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
                ListCategories(EListWithLinkType.WithLink);
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

    public static IEnumerable<Category> GetCategoriesWithGames()
    {
        CategoryRepository repository = new CategoryRepository();

        IEnumerable<Category> categoriesList = repository.GetCategoriesWithGames().Result;

        return categoriesList;
    }

    public static void ListCategories(EListWithLinkType listType = EListWithLinkType.WithoutLink)
    {
        IEnumerable<Category> categoriesList;

        switch (listType)
        {
            case EListWithLinkType.WithLink:
                categoriesList = GetCategoriesWithGames();
                break;
            default:
                categoriesList = GetCategories();
                break;
        }
        
        Console.Clear();
        Console.WriteLine("Categories List:");
        Console.WriteLine("-----------------------------");
        foreach (Category category in categoriesList)
        {
            Console.WriteLine($"Id: {category.Id} / Name: {category.Name}");

            if (listType == EListWithLinkType.WithLink && category.GamesList.Any())
            {
                Console.WriteLine("Games List:");
                foreach (Game game in category.GamesList)
                {
                    Console.WriteLine($"  - Id: {game.Id} / Name: {game.Name}");
                }
            }
        }
    }
}