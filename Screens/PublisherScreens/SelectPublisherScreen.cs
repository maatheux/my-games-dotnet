using MyGames.Enums;
using MyGames.Models;
using MyGames.Repositories;
using MyGames.Screens.OptionsScreens;

namespace MyGames.Screens.PublisherScreens;

public class SelectPublisherScreen
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("Publishers List:");
        Console.WriteLine("-----------------------------");

        IEnumerable<Publisher> publishers = GetPublishers();

        foreach (Publisher publisher in publishers)
        {
            Console.WriteLine($"Id: {publisher.Id} / Name: {publisher.Name} / Country: {publisher.Country}");
        }

        Console.ReadKey();
        SelectScreen.Load();
    }

    public static IEnumerable<Publisher> GetPublishers()
    {
        Repository<Publisher> repository = new Repository<Publisher>();

        IEnumerable<Publisher> publishersList = repository.ListAsync().Result;

        return publishersList;
    }
    
}