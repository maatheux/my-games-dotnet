using MyGames.Models;
using MyGames.Repositories;
using MyGames.Screens.OptionsScreens;

namespace MyGames.Screens.GameScreens;

public class SelectGameScreen
{
    public static void Load()
    {
        short selectOption;
        bool selectOptionValid;
        do
        {
            Console.Clear();
            Console.WriteLine("Games list options:");
            Console.WriteLine("1 - Game names / 2 - Games with additional info / 3 - Games with all info / 4 - Favorite Games List / 5 - Wishlist Games List / 6 - Back");

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
                ListGames();
                break;
            case 2:
                ListGamesWithAdditionalInfo();
                break;
            case 3:
                ListGamesWithAllInfo();
                break;
            case 4:
                ListGamesWithAdditionalInfo(favorites: true);
                break;
            case 5:
                ListGamesWithAdditionalInfo(wishlist: true);
                break;
            case 6:
                SelectScreen.Load();
                break;
            default:
                Load();
                break;
        }
        
        Console.ReadKey();
        Load();
    }

    private static IEnumerable<Game> GetGames(bool favorites = false, bool wishlist = false)
    {
        Repository<Game> repository = new Repository<Game>();

        IEnumerable<Game> gamesList = repository.ListAsync().Result;

        if (favorites)
            gamesList = gamesList.Where(x => x.FavoriteFlag);

        if (wishlist)
            gamesList = gamesList.Where(x => x.WishlistFlag);

        return gamesList;
    }

    private static IEnumerable<Game> GetGamesWithLinks()
    {
        GameRepository repository = new GameRepository();

        IEnumerable<Game> gamesList = repository.ListGamesWithLink().Result;

        return gamesList;
    }

    private static void ListGames()
    {
        IEnumerable<Game> gamesList = GetGames();
        
        Console.Clear();
        Console.WriteLine("Games List");
        Console.WriteLine("----------------------------");

        foreach (Game game in gamesList)
        {
            Console.WriteLine($"Id: {game.Id} / Name: {game.Name}");
        }
    }

    private static void ListGamesWithAdditionalInfo(bool favorites = false, bool wishlist = false)
    {
        IEnumerable<Game> gamesList = GetGames(favorites, wishlist);
        
        Console.Clear();
        if (favorites)
            Console.WriteLine("Favorite Games List");
        else if (wishlist)
            Console.WriteLine("Games Wishlist");
        else
            Console.WriteLine("Games List");
        Console.WriteLine("----------------------------");

        foreach (Game game in gamesList)
        {
            Console.WriteLine($"Id: {game.Id} / Name: {game.Name} / Release: {game.Release:dd/MM/yyyy} / Rating (1 - 5): {game.Rating}");
            Console.WriteLine($"Description: {game.Description}");
            Console.WriteLine("");
        }
    }

    private static void ListGamesWithAllInfo()
    {
        IEnumerable<Game> gamesList = GetGamesWithLinks();
        
        Console.Clear();
        Console.WriteLine("Games List");
        Console.WriteLine("----------------------------");

        foreach (Game game in gamesList)
        {
            Console.WriteLine($"Id: {game.Id} / Name: {game.Name} / Release: {game.Release:dd/MM/yyyy} / Rating (1 - 5): {game.Rating}");
            Console.WriteLine($"Description: {game.Description}");
            
            if (game.Publisher != null)
                Console.WriteLine($"Publisher: {game.Publisher.Name}");

            if (game.Categories.Any())
            {
                Console.WriteLine("Categories:");
                foreach (Category category in game.Categories)
                {
                    Console.WriteLine($" - Name: {category.Name}");
                }
            }

            if (game.Platforms.Any())
            {
                Console.WriteLine("Platforms:");
                foreach (Platform platform in game.Platforms)
                {
                    Console.WriteLine($" - Name: {platform.Name}");
                }
            }
                
            Console.WriteLine("");
        }
        
    }
    
}