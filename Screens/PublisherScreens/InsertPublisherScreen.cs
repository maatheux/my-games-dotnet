using MyGames.Models;
using MyGames.Repositories;
using MyGames.Screens.OptionsScreens;

namespace MyGames.Screens.PublisherScreens;

public class InsertPublisherScreen
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("Insert a new publisher:");
        Console.WriteLine("");

        Publisher newPublisher = new Publisher();
        
        Console.Write("Name: ");
        newPublisher.Name = Console.ReadLine()!;
        Console.WriteLine("");
        
        Console.Write("Country: ");
        newPublisher.Country = Console.ReadLine()!;
        
        Create(newPublisher);
        Console.ReadKey();
        InsertScreen.Load();

    }

    private async static void Create(Publisher newPublisher)
    {
        try
        {
            Repository<Publisher> repository = new Repository<Publisher>();
            Console.WriteLine("Processing...");
            await repository.CreateAsync(newPublisher);
            Thread.Sleep(2000);
            Console.Clear();
            Console.WriteLine("New publisher successfully registered!");
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