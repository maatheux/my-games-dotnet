using MyGames.Models;
using MyGames.Repositories;

namespace MyGames.Screens.PublisherScreens;

public class SelectPublisherScreen
{
    public static void Load()
    {}

    public static IEnumerable<Publisher> GetPublishers()
    {
        Repository<Publisher> repository = new Repository<Publisher>();

        IEnumerable<Publisher> publishersList = repository.ListAsync().Result;

        return publishersList;
    }
}