using MyGames.Models;
using MyGames.Repositories;
using MyGames.Screens.OptionsScreens;

namespace MyGames.Screens.CategoryScreens;

public class UpdateCategoryScreen
{
    public static void Load()
    {
        int updateOption;
        bool updateOptionValid;
        do
        {
            Console.Clear();
            SelectCategoryScreen.ListCategories();
            Console.WriteLine("");
            Console.WriteLine("Insert a valid Id to update:");

            updateOptionValid = int.TryParse(Console.ReadLine()!, out updateOption);

            if (!updateOptionValid)
            {
                Console.WriteLine("");
                Console.WriteLine("Insert a valid value...");
                Console.ReadKey();
            }
            
        } while (!updateOptionValid);

        UpdateCategory(updateOption);
        
        Console.ReadKey();
        UpdateScreen.Load();
        
    }

    public static async Task UpdateCategory(int id)
    {
        Repository<Category> repository = new Repository<Category>();
        Category? categoryToUpdate = repository.GetAsync(id)?.Result;

        if (categoryToUpdate == null)
        {
            Console.Clear();
            Console.WriteLine("Id not exists...");
        }
        else
        {
            bool updateNameOptionIsValid = false;
            do
            {
                Console.WriteLine("");
                Console.WriteLine($"Would you like to update 'Name' value (y/n)? (Current value: {categoryToUpdate.Name})");
                string updateNameOption = Console.ReadLine()!;

                if (new List<string>() { "YES", "Y" }.Contains(updateNameOption.ToUpper()))
                {
                    Console.WriteLine("");
                    Console.WriteLine("Insert a new value of 'Name':");
                    categoryToUpdate.Name = Console.ReadLine()!;
                    updateNameOptionIsValid = true;
                }
                else if (new List<string>() { "NO", "N" }.Contains(updateNameOption.ToUpper()))
                    updateNameOptionIsValid = true;
                else
                {
                    Console.WriteLine("--------------------------------");
                    Console.WriteLine("Insert a valid option...");
                    Console.WriteLine("");
                }

            } while (!updateNameOptionIsValid);
            
            try
            {
                await repository.UpdateAsync(categoryToUpdate);
                Console.WriteLine("");
                Console.WriteLine("Category was updated successfully!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }        
        
    }
}