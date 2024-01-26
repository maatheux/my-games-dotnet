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
}