using MyGames.Models;
using MyGames.Repositories;

namespace MyGames.Screens.CategoryScreens;

public class SelectCategoryScreen
{
    public static void Load() {}

    public static IEnumerable<Category> GetCategories()
    {
        Repository<Category> repository = new Repository<Category>();

        IEnumerable<Category> categoriesList = repository.ListAsync().Result;

        return categoriesList;
    }
}