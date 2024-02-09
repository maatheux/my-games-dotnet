using Dapper;
using MyGames.Models;

namespace MyGames.Repositories;

public class GamePlatformRepository : Repository<GamePlatform>
{
    public async Task DeleteGamePlatformByPlatformId(int id)
    {
        string query = """
                           DELETE FROM MyGames.dbo.GamePlatform
                           WHERE PlatformId=@PlatformId
                       """;

        await _connection.ExecuteAsync(query, new
        {
            PlatformId = id
        });
    }

    public async Task DeleteGamePlatformByGameId(int id)
    {
        string query = """
                           DELETE FROM MyGames.dbo.GamePlatform
                           WHERE GameId=@GameId
                       """;

        await _connection.ExecuteAsync(query, new
        {
            GameId = id
        });
    }
}