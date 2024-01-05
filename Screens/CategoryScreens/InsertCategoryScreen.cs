using MyGames.Models;
using MyGames.Repositories;
using MyGames.Screens.OptionsScreens;

namespace MyGames.Screens.CategoryScreens;

public static class InsertCategoryScreen
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("Insert a new category:");
        Console.WriteLine("");

        Category newCategory = new Category();
        
        Console.Write("Name: ");
        newCategory.Name = Console.ReadLine()!;
        
        Create(newCategory);
        Console.ReadKey();
        InsertScreen.Load();

    }

    private async static void Create(Category newCategory)
    {
        try
        {
            Repository<Category> repository = new Repository<Category>();
            Console.WriteLine("Processing...");
            await repository.CreateAsync(newCategory);
            Thread.Sleep(2000);
            Console.Clear();
            Console.WriteLine("New category successfully registered!");
            Console.WriteLine("Press enter to return...");
        }
        catch (Exception e)
        {
            Console.Clear();
            Console.WriteLine("Opss! Error...");
            Console.WriteLine(e.Message);
        }
    }
}