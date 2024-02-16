using MyGames.Screens.CategoryScreens;
using MyGames.Screens.CompanyScreens;
using MyGames.Screens.PublisherScreens;

namespace MyGames.Screens.OptionsScreens;

public class UpdateScreen
{
    public static void Load()
    {
        short updateScreenOption;
        bool updateOptionValid;
        do
        {
            Console.Clear();
            Console.WriteLine("Update Options");
            Console.WriteLine("1 - Category / 2 - Company / 3 - Game / 4 - Platform / 5 - Publisher / 6 - Back");
            
            updateOptionValid = short.TryParse(Console.ReadLine()!, out updateScreenOption);

            if (!updateOptionValid)
            {
                Console.WriteLine("");
                Console.WriteLine("Insert a valid value...");
                Console.ReadKey();
            }
            
        } while (!updateOptionValid);
        
        switch (updateScreenOption)
        {
            case 1:
                UpdateCategoryScreen.Load(); 
                break;
            case 2:
                UpdateCompanyScreen.Load();
                break;
            case 3:
                // 
                break;
            case 4:
                // 
                break;
            case 5:
                UpdatePublisherScreen.Load();
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