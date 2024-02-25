using System.Globalization;
using MyGames.Models;
using MyGames.Repositories;
using MyGames.Screens.OptionsScreens;
using MyGames.Screens.PublisherScreens;

namespace MyGames.Screens.GameScreens;

public class UpdateGameScreen
{
    public static void Load()
    {
        int updateOption;
        bool updateOptionValid;
        do
        {
            Console.Clear();
            SelectGameScreen.ListGamesWithAllInfo();
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

        UpdateGame(updateOption);
        
        Console.ReadKey();
        UpdateScreen.Load();
    }

    private static async Task UpdateGame(int id)
    {
        Repository<Game> repository = new Repository<Game>();
        Game? gameToUpdate = repository.GetAsync(id)?.Result;

        if (gameToUpdate == null)
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
                Console.WriteLine($"Would you like to update 'Name' value (y/n)? (Current value: {gameToUpdate.Name})");
                string updateNameOption = Console.ReadLine()!;

                if (new List<string>() { "YES", "Y" }.Contains(updateNameOption.ToUpper()))
                {
                    Console.WriteLine("");
                    Console.WriteLine("Insert a new value of 'Name':");
                    gameToUpdate.Name = Console.ReadLine()!;
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
            
            bool updateDescriptionOptionIsValid = false;
            do
            {
                Console.WriteLine("");
                Console.WriteLine($"Would you like to update 'Description' value (y/n)? (Current value: {gameToUpdate.Description})");
                string updateDescriptionOption = Console.ReadLine()!;

                if (new List<string>() { "YES", "Y" }.Contains(updateDescriptionOption.ToUpper()))
                {
                    Console.WriteLine("");
                    Console.WriteLine("Insert a new value of 'Description':");
                    gameToUpdate.Description = Console.ReadLine()!;
                    updateDescriptionOptionIsValid = true;
                }
                else if (new List<string>() { "NO", "N" }.Contains(updateDescriptionOption.ToUpper()))
                    updateDescriptionOptionIsValid = true;
                else
                {
                    Console.WriteLine("--------------------------------");
                    Console.WriteLine("Insert a valid option...");
                    Console.WriteLine("");
                }

            } while (!updateDescriptionOptionIsValid);
            
            bool updateRatingOptionIsValid = false;
            do
            {
                Console.WriteLine("");
                Console.WriteLine($"Would you like to update 'Rating' value (y/n)? (Current value: {gameToUpdate.Rating})");
                string updateRatingOption = Console.ReadLine()!;

                if (new List<string>() { "YES", "Y" }.Contains(updateRatingOption.ToUpper()))
                {
                    bool newRatingIsValid;
                    int newRating;
                    do
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Insert a new value of 'Rating':");
                        
                        newRatingIsValid = int.TryParse(Console.ReadLine()!, out newRating);

                        if (newRatingIsValid && newRating is >= 1 and <= 5)
                        {
                            gameToUpdate.Rating = newRating;
                            updateRatingOptionIsValid = true;
                        }
                        
                    } while (!newRatingIsValid && newRating is < 1 or > 5);
                }
                else if (new List<string>() { "NO", "N" }.Contains(updateRatingOption.ToUpper()))
                    updateRatingOptionIsValid = true;
                else
                {
                    Console.WriteLine("--------------------------------");
                    Console.WriteLine("Insert a valid option...");
                    Console.WriteLine("");
                }

            } while (!updateRatingOptionIsValid);
            
            bool updateReleaseOptionIsValid = false;
            do
            {
                Console.WriteLine("");
                Console.WriteLine($"Would you like to update 'Release' value (y/n)? (Current value: {gameToUpdate.Release})");
                string updateReleaseOption = Console.ReadLine()!;

                if (new List<string>() { "YES", "Y" }.Contains(updateReleaseOption.ToUpper()))
                {
                    bool newReleaseIsValid;
                    DateTime newRelease;
                    do
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Insert a new value of 'Release':");
                        
                        newReleaseIsValid = DateTime.TryParseExact
                            (
                                Console.ReadLine()!,
                                "dd/MM/yyyy",
                                CultureInfo.InvariantCulture,
                                DateTimeStyles.None,
                                out newRelease
                            );

                        if (newReleaseIsValid)
                        {
                            gameToUpdate.Release = newRelease;
                            updateReleaseOptionIsValid = true;
                        }
                        
                    } while (!newReleaseIsValid);
                }
                else if (new List<string>() { "NO", "N" }.Contains(updateReleaseOption.ToUpper()))
                    updateReleaseOptionIsValid = true;
                else
                {
                    Console.WriteLine("--------------------------------");
                    Console.WriteLine("Insert a valid option...");
                    Console.WriteLine("");
                }

            } while (!updateReleaseOptionIsValid);
            
            bool updateWishlistFlagOptionIsValid = false;
            do
            {
                Console.WriteLine("");
                Console.WriteLine($"Would you like to {(gameToUpdate.WishlistFlag ? "remove it from" : "add it to")} wishlist (y/n)?");
                string updateWishlistFlagOption = Console.ReadLine()!;

                if (new List<string>() { "YES", "Y" }.Contains(updateWishlistFlagOption.ToUpper()))
                {
                    gameToUpdate.WishlistFlag = !gameToUpdate.WishlistFlag;
                    updateWishlistFlagOptionIsValid = true;
                }
                else if (new List<string>() { "NO", "N" }.Contains(updateWishlistFlagOption.ToUpper()))
                    updateWishlistFlagOptionIsValid = true;
                else
                {
                    Console.WriteLine("--------------------------------");
                    Console.WriteLine("Insert a valid option...");
                    Console.WriteLine("");
                }

            } while (!updateWishlistFlagOptionIsValid);
            
            bool updateFavoriteFlagOptionIsValid = false;
            do
            {
                Console.WriteLine("");
                Console.WriteLine($"Would you like to {(gameToUpdate.FavoriteFlag ? "remove it from" : "add it to")} favorite list (y/n)?");
                string updateFavoriteFlagOption = Console.ReadLine()!;

                if (new List<string>() { "YES", "Y" }.Contains(updateFavoriteFlagOption.ToUpper()))
                {
                    gameToUpdate.FavoriteFlag = !gameToUpdate.FavoriteFlag;
                    updateFavoriteFlagOptionIsValid = true;
                }
                else if (new List<string>() { "NO", "N" }.Contains(updateFavoriteFlagOption.ToUpper()))
                    updateFavoriteFlagOptionIsValid = true;
                else
                {
                    Console.WriteLine("--------------------------------");
                    Console.WriteLine("Insert a valid option...");
                    Console.WriteLine("");
                }

            } while (!updateFavoriteFlagOptionIsValid);

            Repository<Publisher> publisherRepository = new Repository<Publisher>();
            Publisher? linkedPublisher = publisherRepository.GetAsync(gameToUpdate.PublisherId)?.Result;
            bool updatePublisherIdOptionIsValid = false;
            do
            {
                Console.WriteLine("");
                Console.WriteLine($"Would you like to update 'Publisher' value (y/n)? (Current value: {linkedPublisher?.Name})");
                string updatePublisherIdOption = Console.ReadLine()!;
        
                if (new List<string>() { "YES", "Y" }.Contains(updatePublisherIdOption.ToUpper()))
                {
                    do
                    {
                        Console.WriteLine("");
                        SelectPublisherScreen.Load(false);
                        Console.WriteLine("");
                        Console.WriteLine("Insert a valid id to update value of 'Publisher':");
                        int newId;
                        updatePublisherIdOptionIsValid = int.TryParse(Console.ReadLine()!, out newId);
                    
                        if (updatePublisherIdOptionIsValid)
                            gameToUpdate.PublisherId = newId;
                        else
                        {
                            Console.WriteLine("--------------------------------");
                            Console.WriteLine("Insert a valid Id...");
                            Console.WriteLine("");
                        }
                    } while (!updatePublisherIdOptionIsValid);
                    
                }
                else if (new List<string>() { "NO", "N" }.Contains(updatePublisherIdOption.ToUpper()))
                    updatePublisherIdOptionIsValid = true;
                else
                {
                    Console.WriteLine("--------------------------------");
                    Console.WriteLine("Insert a valid option...");
                    Console.WriteLine("");
                }
        
            } while (!updatePublisherIdOptionIsValid);
            
            // Update publisher, categories and plataforms

            try
            {
                await repository.UpdateAsync(gameToUpdate);
                Console.WriteLine("");
                Console.WriteLine("Game was updated successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error message: {e.Message}");
                throw;
            }
            
            
        }
    }
}