using MyGames.Enums;
using MyGames.Models;
using MyGames.Repositories;
using MyGames.Screens.OptionsScreens;

namespace MyGames.Screens.PlatformScreens;

public class SelectPlatformScreen
{
    public static void Load()
    {
        short selectOption;
        bool selectOptionValid;
        do
        {
            Console.Clear();
            Console.WriteLine("Platforms list options:");
            Console.WriteLine("1 - Platforms / 2 - Platforms with linked games list and category / 3 - Back");

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
                ListPlatforms();
                break;
            case 2:
                ListPlatforms(EListWithLinkType.WithLink);
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

    public static IEnumerable<Platform> GetPlatforms()
    {
        Repository<Platform> repository = new Repository<Platform>();

        IEnumerable<Platform> platformsList = repository.ListAsync().Result;

        return platformsList;
    }

    public static IEnumerable<Platform> GetPlatformsWithLinks()
    {
        PlatformRepository repository = new PlatformRepository();

        IEnumerable<Platform> platformsList = repository.GetPlataformWithLinks().Result;

        return platformsList;
    }

    public static void ListPlatforms(EListWithLinkType listType = EListWithLinkType.WithoutLink)
    {
        IEnumerable<Platform> platformsList;
        
        switch (listType)
        {
            case EListWithLinkType.WithLink:
                platformsList = GetPlatformsWithLinks();
                break;
            default:
                platformsList = GetPlatforms();
                break;
        }
        
        Console.Clear();
        Console.WriteLine("Platforms List:");
        Console.WriteLine("-----------------------------");
        foreach (Platform platform in platformsList)
        {
            Console.WriteLine($"Id: {platform.Id} / Name: {platform.Name}" 
                              + (listType == EListWithLinkType.WithLink && platform.Company != null ?
                                  $" / Company Name: {platform.Company.Name} / Company CEO: {platform.Company.Ceo}" : 
                                  "" ));

            if (listType == EListWithLinkType.WithLink && platform.GamesList.Any())
            {
                Console.WriteLine("Games List:");
                foreach (Game game in platform.GamesList)
                {
                    Console.WriteLine($"  - Id: {game.Id} / Name: {game.Name}");
                }
            }
        }
    }
}