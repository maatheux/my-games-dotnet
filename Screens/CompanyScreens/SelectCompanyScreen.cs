using MyGames.Models;
using MyGames.Repositories;
using MyGames.Screens.OptionsScreens;

namespace MyGames.Screens.CompanyScreens;

public class SelectCompanyScreen
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("Companies List:");

        IEnumerable<Company> companiesList = GetCompanies();

        foreach (Company company in companiesList)
        {
            Console.WriteLine($"Id: {company.Id} / Name: {company.Name} / CEO: {company.Ceo}");
        }

        Console.ReadKey();
        SelectScreen.Load();
    }

    public static IEnumerable<Company> GetCompanies()
    {
        Repository<Company> repository = new Repository<Company>();
        
        IEnumerable<Company> companiesList = repository.ListAsync().Result;
        
        return companiesList;
    }
}