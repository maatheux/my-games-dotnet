using MyGames.Models;
using MyGames.Repositories;
using MyGames.Screens.OptionsScreens;

namespace MyGames.Screens.PublisherScreens;

public class DeletePublisherScreen
{
    public static void Load()
    {
        
        short deleteOption;
        bool deleteOptionValid;
        do
        {
            Console.Clear();
            SelectPublisherScreen.Load(false);
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

        DeletePublisher(deleteOption);

        Console.ReadKey();
        DeleteScreen.Load();

    }

    private static async Task DeletePublisher(short id)
    {
        try
        {
            Repository<Publisher> repository = new Repository<Publisher>();

            await repository.DeleteAsync(id);

            Console.WriteLine("Publisher deleted successfully!");
        }
        catch (ArgumentException e)
        {
            Console.WriteLine("Publisher not found! Insert a valid Publisher Id...");
            throw;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}