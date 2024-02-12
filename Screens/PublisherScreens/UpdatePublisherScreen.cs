using MyGames.Models;
using MyGames.Repositories;
using MyGames.Screens.OptionsScreens;

namespace MyGames.Screens.PublisherScreens;

public class UpdatePublisherScreen
{
    public static void Load()
    {
        int updateOption;
        bool updateOptionValid;
        do
        {
            Console.Clear();
            SelectPublisherScreen.Load(false);
            Console.WriteLine("");
            Console.WriteLine("Insert a valid Id to update:");

            updateOptionValid = true;
            updateOptionValid = int.TryParse(Console.ReadLine()!, out updateOption);

            if (!updateOptionValid)
            {
                Console.WriteLine("");
                Console.WriteLine("Insert a valid value...");
                Console.ReadKey();
            }
            
        } while (!updateOptionValid);

        UpdatePublisher(updateOption);
        
        Console.ReadKey();
        UpdateScreen.Load();

    }

    private static async Task UpdatePublisher(int id)
    {
        Repository<Publisher> repository = new Repository<Publisher>();
        Publisher? publisherToUpdate = repository.GetAsync(id)?.Result;

        if (publisherToUpdate == null)
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
                Console.WriteLine($"Would you like to update 'Name' value (y/n)? (Current value: {publisherToUpdate.Name})");
                string updateNameOption = Console.ReadLine()!;

                if (new List<string>() { "YES", "Y" }.Contains(updateNameOption.ToUpper()))
                {
                    Console.WriteLine("");
                    Console.WriteLine("Insert a new value of 'Name':");
                    publisherToUpdate.Name = Console.ReadLine()!;
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

            bool updateCountryOptionIsValid = false;
            do
            {
                Console.WriteLine("");
                Console.WriteLine($"Would you like to update 'Country' value (y/n)? (Current value: {publisherToUpdate.Country})");
                string updateCountryOption = Console.ReadLine()!;
    
                if (new List<string>() { "YES", "Y" }.Contains(updateCountryOption.ToUpper()))
                {
                    Console.WriteLine("");
                    Console.WriteLine("Insert a new value of 'Country':");
                    publisherToUpdate.Country = Console.ReadLine()!;
                    updateCountryOptionIsValid = true;
                }
                else if (new List<string>() { "NO", "N" }.Contains(updateCountryOption.ToUpper()))
                    updateCountryOptionIsValid = true;
                else
                {
                    Console.WriteLine("--------------------------------");
                    Console.WriteLine("Insert a valid option...");
                    Console.WriteLine("");
                }
    
            } while (!updateCountryOptionIsValid);
    
            try
            {
                await repository.UpdateAsync(publisherToUpdate);
                Console.WriteLine("");
                Console.WriteLine("Publisher was updated successfully!");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error message: {e.Message}");
                throw;
            }
        }
        
    }
}