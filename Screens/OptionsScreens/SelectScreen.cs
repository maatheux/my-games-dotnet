using MyGames.Screens.CategoryScreens;
using MyGames.Screens.CompanyScreens;
using MyGames.Screens.PlatformScreens;
using MyGames.Screens.PublisherScreens;

namespace MyGames.Screens.OptionsScreens;

public class SelectScreen
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("Select options:");
        Console.WriteLine("1 - Category / 2 - Company / 3 - Game / 4 - Platform / 5 - Publisher / 6 - Back");
        
        short selectOption = short.Parse(Console.ReadLine()!);

        switch (selectOption)
        {
            case 1:
                SelectCategoryScreen.Load();
                break;
            case 2:
                SelectCompanyScreen.Load();
                break;
            case 3:
                //
                break;
            case 4:
                SelectPlatformScreen.Load();
                break;
            case 5:
                SelectPublisherScreen.Load();
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