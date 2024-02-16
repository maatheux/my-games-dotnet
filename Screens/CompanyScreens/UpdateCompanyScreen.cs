using MyGames.Models;
using MyGames.Repositories;
using MyGames.Screens.OptionsScreens;

namespace MyGames.Screens.CompanyScreens;

public class UpdateCompanyScreen
{
    public static void Load()
    {
        int updateOption;
        bool updateOptionValid;
        do
        {
            Console.Clear();
            SelectCompanyScreen.Load(false);
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

        UpdateCompany(updateOption);

        Console.ReadKey();
        UpdateScreen.Load();


    }

    private static async Task UpdateCompany(int id)
    {
        Repository<Company> repository = new Repository<Company>();
        Company? companyToUpdate = repository.GetAsync(id)?.Result;

        if (companyToUpdate == null)
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
                Console.WriteLine($"Would you like to update 'Name' value (y/n)? (Current value: {companyToUpdate.Name})");
                string updateNameOption = Console.ReadLine()!;

                if (new List<string>() { "YES", "Y" }.Contains(updateNameOption.ToUpper()))
                {
                    Console.WriteLine("");
                    Console.WriteLine("Insert a new value of 'Name':");
                    companyToUpdate.Name = Console.ReadLine()!;
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
            
            bool updateCeoOptionIsValid = false;
            do
            {
                Console.WriteLine("");
                Console.WriteLine($"Would you like to update 'Ceo' value (y/n)? (Current value: {companyToUpdate.Ceo})");
                string updateCeoOption = Console.ReadLine()!;

                if (new List<string>() { "YES", "Y" }.Contains(updateCeoOption.ToUpper()))
                {
                    Console.WriteLine("");
                    Console.WriteLine("Insert a new value of 'Ceo':");
                    companyToUpdate.Ceo = Console.ReadLine()!;
                    updateCeoOptionIsValid = true;
                }
                else if (new List<string>() { "NO", "N" }.Contains(updateCeoOption.ToUpper()))
                    updateCeoOptionIsValid = true;
                else
                {
                    Console.WriteLine("--------------------------------");
                    Console.WriteLine("Insert a valid option...");
                    Console.WriteLine("");
                }

            } while (!updateCeoOptionIsValid);

            try
            {
                await repository.UpdateAsync(companyToUpdate);
                Console.WriteLine("");
                Console.WriteLine("Company was updated successfully!");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error message: {e.Message}");
                throw;
            }
        }
    }
}