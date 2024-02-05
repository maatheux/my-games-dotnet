namespace MyGames.Screens.OptionsScreens;

public static class OptionsScreen
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("Welcome to My Games!");
        Console.WriteLine("----------------------------------------------------");
        Console.WriteLine("Action options list:");
        Console.WriteLine("1 - Insert / 2 - List / 3 - Delete / 4 - Update / 5 - Exit");
        short actionOption = short.Parse(Console.ReadLine()!);

        switch (actionOption)
        {
            case 1: InsertScreen.Load(); break;
            case 2: SelectScreen.Load(); break;
            case 3: DeleteScreen.Load(); break;
            case 4: break;
            case 5:
                System.Environment.Exit(0);
                break;
            default:
                Load(); break;
        }
    }
}