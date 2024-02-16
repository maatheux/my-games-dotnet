using MyGames.Models;
using MyGames.Repositories;
using MyGames.Screens.CompanyScreens;
using MyGames.Screens.OptionsScreens;

namespace MyGames.Screens.PlatformScreens;

public class UpdatePlataformScreen
{
    public static void Load()
    {
        int updateOption;
        bool updateOptionValid;
        do
        {
            Console.Clear();
            SelectPlatformScreen.ListPlatforms();
            Console.WriteLine("");
            Console.WriteLine("Insert a valid Id to update:");

            updateOptionValid = int.TryParse(Console.ReadLine()!, out updateOption);

            if (!updateOptionValid)
            {
                Console.WriteLine("");
                Console.WriteLine("Insert a valid value...");
                Console.ReadKey();
            }
            
        } while (!updateOptionValid);

        UpdatePlatform(updateOption);
        
        Console.ReadKey();
        UpdateScreen.Load();
    }
    
    private static async Task UpdatePlatform(int id)
    {
        Repository<Platform> repository = new Repository<Platform>();
        Platform? platformToUpdate = repository.GetAsync(id)?.Result;

        if (platformToUpdate == null)
        {
            Console.Clear();
            Console.WriteLine("Id not exists...");
        }
        else
        {
            bool updateNameOptionIsValid = false;
            do
            {
                Console.WriteLine("");
                Console.WriteLine($"Would you like to update 'Name' value (y/n)? (Current value: {platformToUpdate.Name})");
                string updateNameOption = Console.ReadLine()!;

                if (new List<string>() { "YES", "Y" }.Contains(updateNameOption.ToUpper()))
                {
                    Console.WriteLine("");
                    Console.WriteLine("Insert a new value of 'Name':");
                    platformToUpdate.Name = Console.ReadLine()!;
                    updateNameOptionIsValid = true;
                }
                else if (new List<string>() { "NO", "N" }.Contains(updateNameOption.ToUpper()))
                    updateNameOptionIsValid = true;
                else
                {
                    Console.WriteLine("--------------------------------");
                    Console.WriteLine("Insert a valid option...");
                    Console.WriteLine("");
                }

            } while (!updateNameOptionIsValid);

            Repository<Company> companyRepository = new Repository<Company>();
            Company? linkedCompany = companyRepository.GetAsync(platformToUpdate.IdCompanyOwner)?.Result;
            
            bool updateIdCompanyOptionIsValid = false;
            do
            {
                Console.WriteLine("");
                Console.WriteLine($"Would you like to update 'Company' value (y/n)? (Current value: {linkedCompany.Name})");
                string updateIdCompanyOption = Console.ReadLine()!;
        
                if (new List<string>() { "YES", "Y" }.Contains(updateIdCompanyOption.ToUpper()))
                {
                    do
                    {
                        Console.WriteLine("");
                        SelectCompanyScreen.Load(false);
                        Console.WriteLine("");
                        Console.WriteLine("Insert a valid id to update value of 'Company':");
                        int newId;
                        updateIdCompanyOptionIsValid = int.TryParse(Console.ReadLine()!, out newId);
                    
                        if (updateIdCompanyOptionIsValid)
                            platformToUpdate.IdCompanyOwner = newId;
                        else
                        {
                            Console.WriteLine("--------------------------------");
                            Console.WriteLine("Insert a valid Id...");
                            Console.WriteLine("");
                        }
                    } while (!updateIdCompanyOptionIsValid);
                    
                }
                else if (new List<string>() { "NO", "N" }.Contains(updateIdCompanyOption.ToUpper()))
                    updateIdCompanyOptionIsValid = true;
                else
                {
                    Console.WriteLine("--------------------------------");
                    Console.WriteLine("Insert a valid option...");
                    Console.WriteLine("");
                }
        
            } while (!updateIdCompanyOptionIsValid);

            try
            {
                await repository.UpdateAsync(platformToUpdate);
                Console.WriteLine("");
                Console.WriteLine("Platform was updated successfully!");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error message: {e.Message}");
                throw;
            }
        }
    }
}

