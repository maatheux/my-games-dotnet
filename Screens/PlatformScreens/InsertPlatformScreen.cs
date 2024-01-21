using MyGames.Models;
using MyGames.Repositories;
using MyGames.Screens.CompanyScreens;
using MyGames.Screens.OptionsScreens;

namespace MyGames.Screens.PlatformScreens;

public class InsertPlatformScreen
{
    public static void Load(bool isGameLinkUp = false)
    {
        if (!isGameLinkUp) Console.Clear();
        Console.WriteLine("Insert a new platform:");
        Console.WriteLine("");

        Platform newPlatform = new Platform();
        
        Console.Write("Name: ");
        newPlatform.Name = Console.ReadLine()!;
        Console.WriteLine("");

        Platform linkedPlatform = LinkCompany(newPlatform);
        newPlatform.IdCompanyOwner = linkedPlatform.IdCompanyOwner;
        Console.WriteLine("");
        
        Console.WriteLine($"{newPlatform.Name} - {newPlatform.IdCompanyOwner}");
        Console.ReadKey();

        Create(newPlatform);
        Console.ReadKey();
        if (!isGameLinkUp)
            InsertScreen.Load();
        else
            Console.Clear();
        
    }

    private async static void Create(Platform newPlatform)
    {
        try
        {
            Repository<Platform> repository = new Repository<Platform>();
            Console.WriteLine("Processing...");
            await repository.CreateAsync(newPlatform);
            Thread.Sleep(2000);
            Console.Clear();
            Console.WriteLine("New platform successfully registered!");
            Console.WriteLine("Press enter to return...");
        }
        catch (Exception e)
        {
            Console.Clear();
            Console.WriteLine("Opss! Error...");
            Console.WriteLine(e.Message);
        }
    }

    private static Platform LinkCompany(Platform platform)
    {
        bool isPlatformLinked = false;
        string createNewCompanyOption;
        int companyId;

        do
        {
            IEnumerable<Company> companiesList = SelectCompanyScreen.GetCompanies();
            Console.WriteLine("Companies Options");
            foreach (Company company in companiesList)
            {
                Console.WriteLine($"Id: {company.Id} / Name: {company.Name}");
            }
            Console.WriteLine("");

            Console.Write("Would you like to create a new company? (y/n): ");
            createNewCompanyOption = Console.ReadLine()!;
            Console.WriteLine("");

            if (new List<string>() { "YES", "Y" }.Contains(createNewCompanyOption.ToUpper()))
            {
                InsertCompanyScreen.Load(true);
            }
            else if (new List<string>() { "NO", "N" }.Contains(createNewCompanyOption.ToUpper()))
            {
                bool validOption = true;
                do
                {
                    Console.Write("Insert company id to link up: ");
                    validOption = int.TryParse(Console.ReadLine()!, out companyId);
                    Console.WriteLine("");
                } while (!validOption);

                Company? selectedCompany = companiesList.FirstOrDefault(company => company.Id == companyId);
                if (selectedCompany != null)
                {
                    platform.IdCompanyOwner = selectedCompany.Id;
                    isPlatformLinked = true;
                }
                else
                {
                    Console.WriteLine("Id not found! Insert a valid Id...");
                    Console.WriteLine("");
                }
            }
            else
            {
                Console.WriteLine("--------------------------------");
                Console.WriteLine("Insert a valid option...");
                Console.WriteLine("");
            }
            
            
        } while (!isPlatformLinked);

        
        return platform;
    }
}