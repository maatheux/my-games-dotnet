using System.Globalization;
using MyGames.Models;
using MyGames.Repositories;
using MyGames.Screens.CategoryScreens;
using MyGames.Screens.OptionsScreens;
using MyGames.Screens.PublisherScreens;
using MyGames.shared.utils;

namespace MyGames.Screens.GameScreens;

public class InsertGameScreen
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("Insert a new game:");
        Console.WriteLine("");

        Game newGame = new Game();
        
        Console.Write("Name: ");
        newGame.Name = Console.ReadLine()!;
        Console.WriteLine("");
        
        Console.Write("Description: ");
        newGame.Description = Console.ReadLine()!;
        Console.WriteLine("");

        bool dateIsValid;
        string newDate;
        DateTime insertedDate;

        do
        {
            Console.Write("Release Date (Ex: 31/12/1970): ");
            newDate = Console.ReadLine()!;
            // dateIsValid = DateRegex.IsValidDate(newDate);
            dateIsValid = DateTime.TryParseExact
            (
                newDate, 
                "dd/MM/yyyy", 
                CultureInfo.InvariantCulture, 
                DateTimeStyles.None, 
                out insertedDate
            );

            if (!dateIsValid)
            {
                Console.WriteLine("");
                Console.WriteLine("Insert a valid date...");
                Console.WriteLine("");
            }
            
            
        } while (!dateIsValid);

        newGame.Release = insertedDate;
        Console.WriteLine("");

        do
        {
            Console.Write("Rating (1 - 5): ");
            newGame.Rating = int.Parse(Console.ReadLine()!);
        } while (newGame.Rating is < 1 or > 5);
        Console.WriteLine("");

        bool validFavoriteFlagField;
        string favoriteFlagField;
        do
        {
            Console.WriteLine("Would you like to add that game to your Favorite Game list? (y/n): ");
            favoriteFlagField = Console.ReadLine()!;

            validFavoriteFlagField = true;
            
            if (new List<string>() { "YES", "Y" }.Contains(favoriteFlagField.ToUpper()))
                newGame.FavoriteFlag = true;
            else if (new List<string>() { "NO", "N" }.Contains(favoriteFlagField.ToUpper()))
                newGame.FavoriteFlag = false;
            else
                validFavoriteFlagField = false;
        } while (!validFavoriteFlagField);
        Console.WriteLine("");
        
        bool validWishlistFlagField;
        string wishlistFlagField;
        do
        {
            Console.WriteLine("Would you like to add that game to your Game Wishlist? (y/n): ");
            wishlistFlagField = Console.ReadLine()!;

            validWishlistFlagField = true;
            
            if (new List<string>() { "YES", "Y" }.Contains(wishlistFlagField.ToUpper()))
                newGame.WishlistFlag = true;
            else if (new List<string>() { "NO", "N" }.Contains(wishlistFlagField.ToUpper()))
                newGame.WishlistFlag = false;
            else
                validWishlistFlagField = false;
        } while (!validWishlistFlagField);
        Console.WriteLine("");

        Game linkedGame = LinkPublisher(newGame);
        newGame.PublisherId = linkedGame.PublisherId;
        Console.WriteLine("");

        int createdGameId = Create(newGame).Result;

        newGame.Id = createdGameId;

        LinkCategory(newGame);
        
        
        Console.WriteLine($"{newGame.Name} - {newGame.Release} - {newGame.Rating} - {newGame.FavoriteFlag} - {newGame.WishlistFlag} - {newGame.PublisherId}");
        Console.ReadKey();
        InsertScreen.Load();

    }

    private async static Task<int> Create(Game newGame)
    {
        int createdGameId = 0;
        
        try
        {
            GameRepository repository = new GameRepository();
            //Console.WriteLine("Processing...");
            createdGameId = await repository.CreateReturnId(newGame);
            // Console.Clear();
            // Console.WriteLine("New company successfully registered!");
            // Console.WriteLine("Press enter to return...");
        }
        catch (Exception e)
        {
            Console.Clear();
            Console.WriteLine("Opss! Error...");
            Console.WriteLine(e.Message);
        }

        return createdGameId;
    }

    public static Game LinkPublisher(Game game)
    {
        bool isGameLinked = false;
        string createNewPublisherOption;
        int publisherId;

        do
        {
            IEnumerable<Publisher> publishersList = SelectPublisherScreen.GetPublishers();
            Console.WriteLine("Publishers Options");
            foreach (Publisher publisher in publishersList)
            {
                Console.WriteLine($"Id: {publisher.Id} / Name: {publisher.Name}");
            }
            Console.WriteLine("");
            
            Console.Write("Would you like to create a new publisher? (y/n): ");
            createNewPublisherOption = Console.ReadLine()!;
            Console.WriteLine("");

            if (new List<string>() { "YES", "Y" }.Contains(createNewPublisherOption.ToUpper()))
            {
                InsertPublisherScreen.Load(true);
            }
            else if (new List<string>() { "NO", "N" }.Contains(createNewPublisherOption.ToUpper()))
            {
                bool validOption;
                do
                {
                    Console.Write("Insert publisher id to link up: ");
                    validOption = int.TryParse(Console.ReadLine()!, out publisherId);
                    Console.WriteLine("");
                } while (!validOption);

                Publisher? selectedPublisher = publishersList.FirstOrDefault(publisher => publisher.Id == publisherId);
                if (selectedPublisher != null)
                {
                    game.PublisherId = selectedPublisher.Id;
                    isGameLinked = true;
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
            
        } while (!isGameLinked);

        return game;
    }
    
    public async static void LinkCategory(Game game)
    {
        bool isGameLinked = false;
        string createNewCategoryOption;
        IList<int> categoryIds = new List<int>();
        IList<int> categoriesError = new List<int>();
        IList<Category> categoriesSuccess = new List<Category>();

        do
        {
            IEnumerable<Category> categoriesList = SelectCategoryScreen.GetCategories();
            Console.WriteLine("Categories Options");
            foreach (Category category in categoriesList)
            {
                Console.WriteLine($"Id: {category.Id} / Name: {category.Name}");
            }
            Console.WriteLine("");
            
            Console.Write("Would you like to create a new category? (y/n): ");
            createNewCategoryOption = Console.ReadLine()!;
            Console.WriteLine("");

            if (new List<string>() { "YES", "Y" }.Contains(createNewCategoryOption.ToUpper()))
            {
                InsertCategoryScreen.Load(true);
            }
            else if (new List<string>() { "NO", "N" }.Contains(createNewCategoryOption.ToUpper()))
            {
                bool validOption, addNewIdOption;
                int categoryId;
                do
                {
                    Console.Write("Insert category id to link up: ");
                    validOption = int.TryParse(Console.ReadLine()!, out categoryId);
                    if (validOption) categoryIds.Add(categoryId);
                    Console.WriteLine("");

                    do
                    {
                        Console.WriteLine("Would you like to link up another category? (y/n): ");
                        string addNewId = Console.ReadLine()!;
                        if (new List<string>() { "YES", "Y" }.Contains(addNewId.ToUpper()))
                        {
                            addNewIdOption = true;
                            validOption = false;
                        }
                        else if (new List<string>() { "NO", "N" }.Contains(addNewId.ToUpper()))
                            addNewIdOption = true;
                        else
                        {
                            Console.WriteLine("");
                            Console.WriteLine("Insert a valid option...");
                            Console.WriteLine("");
                            addNewIdOption = false;
                        }
                        Console.WriteLine("");

                    } while (!addNewIdOption);
                        
                } while (!validOption);

                Repository<GameCategory> gameCategoryRepository = new Repository<GameCategory>();

                isGameLinked = true;

                foreach (int id in categoryIds)
                {
                    Category? selectedCategory = categoriesList.FirstOrDefault(category => category.Id == id);
                    if (selectedCategory != null)
                    {
                        GameCategory newGameCategory = new GameCategory()
                        {
                            GameId = game.Id,
                            CategoryId = selectedCategory.Id
                        };

                        await gameCategoryRepository.CreateAsync(newGameCategory);
                        categoriesSuccess.Add(selectedCategory);
                    }
                    else
                    {
                        categoriesError.Add(id);
                        isGameLinked = false;
                    }
                }
                Console.WriteLine("");

                Console.WriteLine("Game linked up to categories:");
                foreach (Category category in categoriesSuccess)
                {
                    Console.WriteLine($"Id: {category.Id} / Name: {category.Name}");
                }
                
                Console.WriteLine("");

                if (!isGameLinked)
                {
                    Console.WriteLine("Ids not found: ");
                    foreach (int id in categoriesError)
                    {
                        Console.WriteLine($"Id: {id}");
                    }
                }
                Console.WriteLine("");

            }
            else
            {
                Console.WriteLine("--------------------------------");
                Console.WriteLine("Insert a valid option...");
                Console.WriteLine("");
            }
            
        } while (!isGameLinked);

    }
}