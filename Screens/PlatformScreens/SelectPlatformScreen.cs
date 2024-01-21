using MyGames.Models;
using MyGames.Repositories;

namespace MyGames.Screens.PlatformScreens;

public class SelectPlatformScreen
{
    public static void Load() {}

    public static IEnumerable<Platform> GetPlatforms()
    {
        Repository<Platform> repository = new Repository<Platform>();

        IEnumerable<Platform> platformsList = repository.ListAsync().Result;

        return platformsList;
    }
}