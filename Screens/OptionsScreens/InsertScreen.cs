namespace MyGames.Screens.OptionsScreens;

public static class InsertScreen
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("Insert options:");
        Console.WriteLine("1 - Category / 2 - Company / 3 - Game / 4 - Platform / 5 - Publisher");
        
        short insertOption = short.Parse(Console.ReadLine()!);
        
        switch (insertOption)
        {
            case 1: break;
            case 2: break;
            case 3: break;
            case 4: break;
            case 5: break;
            default:
                Load(); break;
        }

    }
}