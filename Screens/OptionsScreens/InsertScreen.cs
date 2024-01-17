using MyGames.Screens.CategoryScreens;
using MyGames.Screens.CompanyScreens;
using MyGames.Screens.GameScreens;
using MyGames.Screens.PlataformScreens;
using MyGames.Screens.PublisherScreens;

namespace MyGames.Screens.OptionsScreens;

public static class InsertScreen
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("Insert options:");
        Console.WriteLine("1 - Category / 2 - Company / 3 - Game / 4 - Platform / 5 - Publisher / 6 - Back");
        
        short insertOption = short.Parse(Console.ReadLine()!);
        
        switch (insertOption)
        {
            case 1:
                InsertCategoryScreen.Load();
                break;
            case 2:
                InsertCompanyScreen.Load();
                break;
            case 3:
                InsertGameScreen.Load();
                break;
            case 4: 
                InsertPlataformScreen.Load();
                break;
            case 5: 
                InsertPublisherScreen.Load();
                break;
            case 6: 
                OptionsScreen.Load();
                break;
            default:
                Load(); break;
        }

    }
}