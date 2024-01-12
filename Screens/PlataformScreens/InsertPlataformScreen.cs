using MyGames.Models;
using MyGames.Repositories;
using MyGames.Screens.CompanyScreens;
using MyGames.Screens.OptionsScreens;

namespace MyGames.Screens.PlataformScreens;

public class InsertPlataformScreen
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("Insert a new plataform:");
        Console.WriteLine("");

        Plataform newPlataform = new Plataform();
        
        Console.Write("Name: ");
        newPlataform.Name = Console.ReadLine()!;
        Console.WriteLine("");

        Plataform linkedPlataform = LinkCompany(newPlataform);
        newPlataform.IdCompanyOwner = linkedPlataform.IdCompanyOwner;
        Console.WriteLine("");
        
        Console.WriteLine($"{newPlataform.Name} - {newPlataform.IdCompanyOwner}");
        Console.ReadKey();

        Create(newPlataform);
        Console.ReadKey();
        InsertScreen.Load();
        
    }

    private async static void Create(Plataform newPlataform)
    {
        try
        {
            Repository<Plataform> repository = new Repository<Plataform>();
            Console.WriteLine("Processing...");
            await repository.CreateAsync(newPlataform);
            Thread.Sleep(2000);
            Console.Clear();
            Console.WriteLine("New plataform successfully registered!");
            Console.WriteLine("Press enter to return...");
        }
        catch (Exception e)
        {
            Console.Clear();
            Console.WriteLine("Opss! Error...");
            Console.WriteLine(e.Message);
        }
    }

    private static Plataform LinkCompany(Plataform plataform)
    {
        bool isPlataformLinked = false;
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
                    plataform.IdCompanyOwner = selectedCompany.Id;
                    isPlataformLinked = true;
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
            
            
        } while (!isPlataformLinked);

        
        return plataform;
    }
}