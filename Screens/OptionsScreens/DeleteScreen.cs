using MyGames.Screens.PublisherScreens;

namespace MyGames.Screens.OptionsScreens;

public class DeleteScreen
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("Delete Options");
        Console.WriteLine("1 - Category / 2 - Company / 3 - Game / 4 - Platform / 5 - Publisher / 6 - Back");

        short deleteOption = short.Parse(Console.ReadLine()!);

        switch (deleteOption)
        {
            case 1:
                //
                break;
            case 2:
                //
                break;
            case 3:
                //
                break;
            case 4:
                //
                break;
            case 5:
                DeletePublisherScreen.Load();
                break;
            case 6:
                OptionsScreen.Load();
                break;
            default:
                Load();
                break;
        }

    }
}