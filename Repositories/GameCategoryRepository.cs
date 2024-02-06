using System.Collections;
using Dapper;
using MyGames.Models;

namespace MyGames.Repositories;

public class GameCategoryRepository : Repository<GameCategory>
{
    public async Task<IEnumerable<GameCategory>> GetAllGameCategoryAsync()
    {
        string query = """
                        SELECT 
                            GameId, 
                            CategoryId
                        FROM MyGames.dbo.GameCategory
                       """;

        IEnumerable<GameCategory> gameCategoryList = await _connection.QueryAsync<GameCategory>(query);

        return gameCategoryList;
    }

    public async Task DeleteGameCategoryAsync(int id)
    {
        string query = """
                           DELETE FROM MyGames.dbo.GameCategory
                           WHERE CategoryId=@CategoryId
                       """;

        await _connection.ExecuteAsync(query, new
        {
            CategoryId = id
        });
    }
}