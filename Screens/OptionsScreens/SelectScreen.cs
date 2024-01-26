﻿using MyGames.Screens.CategoryScreens;

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
                //
                break;
            case 3:
                //
                break;
            case 4:
                //
                break;
            case 5:
                //
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