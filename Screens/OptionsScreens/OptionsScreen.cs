﻿namespace MyGames.Screens.OptionsScreens;

public static class OptionsScreen
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("Welcome to My Games!");
        Console.WriteLine("----------------------------------------------------");
        Console.WriteLine("Action options list:");
        Console.WriteLine("1 - Insert / 2 - List / 3 - Delete / 4 - Update");
        short actionOption = short.Parse(Console.ReadLine()!);

        switch (actionOption)
        {
            case 1: InsertScreen.Load(); break;
            case 2: break;
            case 3: break;
            case 4: break;
            default:
                Load(); break;
        }
    }
}