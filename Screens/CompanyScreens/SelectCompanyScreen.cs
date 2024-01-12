using MyGames.Models;
using MyGames.Repositories;

namespace MyGames.Screens.CompanyScreens;

public class SelectCompanyScreen
{
    public static void Load()
    {}

    public static IEnumerable<Company> GetCompanies()
    {
        Repository<Company> repository = new Repository<Company>();
        
        IEnumerable<Company> companiesList = repository.ListAsync().Result;
        
        return companiesList;
    }
}