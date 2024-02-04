using Dapper;
using Microsoft.Data.SqlClient;
using MyGames.Models;

namespace MyGames.Repositories;

public class GameRepository : Repository<Game>
{
    
    public async Task<int> CreateReturnId(Game game)
    {
        string insertSql = @"
            INSERT INTO
                [Game]
            VALUES (
                @Name,
                @Description,
                @Release,
                @Rating,
                @FavoriteFlag,
                @WishlistFlag,
                @PublisherId
            )
            SELECT SCOPE_IDENTITY()
        ";

        var newGameId = await _connection.ExecuteScalarAsync(insertSql, new
        {
            game.Name,
            game.Description,
            game.Release,
            game.Rating,
            game.FavoriteFlag,
            game.WishlistFlag,
            game.PublisherId
        });

        return Convert.ToInt32(newGameId);
    }

    public async Task<IEnumerable<Game>> ListGamesWithLink()
    {
        string query = """
                        SELECT
                            Game.Id,
                            Game.Name,
                            Game.Description,
                            Game.[Release],
                            Game.Rating,
                            Game.FavoriteFlag,
                            Game.WishlistFlag,
                            Publisher.*,
                            Category.*,
                            Platform.*
                        FROM MyGames.dbo.Game Game
                        LEFT JOIN MyGames.dbo.Publisher Publisher ON Publisher.Id = Game.PublisherId
                        LEFT JOIN MyGames.dbo.GameCategory GameCategory ON GameCategory.GameId = Game.Id
                        LEFT JOIN MyGames.dbo.Category Category ON Category.Id = GameCategory.CategoryId
                        LEFT JOIN MyGames.dbo.GamePlatform GamePlatform ON GamePlatform.GameId = Game.Id
                        LEFT JOIN MyGames.dbo.Platform Platform ON Platform.Id = GamePlatform.PlatformId 
                       """;

        List<Game> games = new List<Game>();
        
       await _connection.QueryAsync<Game, Publisher, Category, Platform, Game>(query,
            (game, publisher, category, platform) =>
            {
                Game? gameInList = games.FirstOrDefault(x => x.Id == game.Id);

                if (gameInList == null)
                {
                    gameInList = game;

                    if (publisher != null)
                        gameInList.Publisher = publisher;
                    
                    if (category != null &&
                        gameInList.Categories.FirstOrDefault(x => x.Id == category.Id) == null)
                        gameInList.Categories.Add(category);

                    if (platform != null &&
                        gameInList.Platforms.FirstOrDefault(x => x.Id == platform.Id) == null)
                        gameInList.Platforms.Add(platform);
                    
                    games.Add(gameInList);
                }
                else
                {
                    if (publisher != null)
                        gameInList.Publisher = publisher;
                    
                    if (category != null)
                        gameInList.Categories.Add(category);

                    if (platform != null)
                        gameInList.Platforms.Add(platform);
                }

                return game;
            }, splitOn: "Id, Id, Id");

       foreach (Game game in games)
       {
           if (game.Categories.Any())
               game.Categories = game.Categories.DistinctBy(x => x.Id).ToList();

           if (game.Platforms.Any())
               game.Platforms = game.Platforms.DistinctBy(x => x.Id).ToList();
       }

        return games;
    }
}