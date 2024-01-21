using MyGames.Models;
using MyGames.Repositories;
using MyGames.Screens.OptionsScreens;

namespace MyGames.Screens.CompanyScreens;

public class InsertCompanyScreen
{
    public static void Load(bool isPlatformLinkUp = false)
    {
        if (!isPlatformLinkUp) Console.Clear();
        Console.WriteLine("Insert a new company:");
        Console.WriteLine("");

        Company newCompany = new Company();
        
        Console.Write("Name: ");
        newCompany.Name = Console.ReadLine()!;
        Console.WriteLine("");

        Console.Write("CEO: ");
        newCompany.Ceo = Console.ReadLine()!;
        Console.WriteLine("");

        Create(newCompany);
        Console.ReadKey();
        if (!isPlatformLinkUp) 
            InsertScreen.Load();
        else
            Console.Clear();
    }
    
    private async static void Create(Company newCompany)
    {
        try
        {
            Repository<Company> repository = new Repository<Company>();
            Console.WriteLine("Processing...");
            await repository.CreateAsync(newCompany);
            Thread.Sleep(2000);
            Console.Clear();
            Console.WriteLine("New company successfully registered!");
            Console.WriteLine("Press enter to return...");
        }
        catch (Exception e)
        {
            Console.Clear();
            Console.WriteLine("Opss! Error...");
            Console.WriteLine(e.Message);
        }
    }
}