using Dapper;
using MyGames.Models;

namespace MyGames.Repositories;

public class PlatformRepository : Repository<Platform>
{
    public async Task<IEnumerable<Platform>> GetPlataformWithLinks()
    {
        string query = """
                       SELECT
                       	Platform.Id,
                       	Platform.Name,
                       	Company.*,
                       	Game.*
                       FROM MyGames.dbo.Platform Platform
                       LEFT JOIN MyGames.dbo.Company Company ON Company.Id = Platform.IdCompanyOwner 
                       LEFT JOIN MyGames.dbo.GamePlatform GamePlatform ON GamePlatform.PlatformId = Platform.Id
                       LEFT JOIN MyGames.dbo.Game Game ON Game.Id = GamePlatform.GameId 
                       """;

        List<Platform> platforms = new List<Platform>();

        await _connection.QueryAsync<Platform, Company, Game, Platform>(query, (platform, company, game) =>
        {
	        Platform? platformInList = platforms.FirstOrDefault(x => x.Id == platform.Id);

	        if (platformInList == null)
	        {
		        platformInList = platform;
		        if (game != null)
			        platformInList.GamesList.Add(game);

		        if (company != null)
			        platform.Company = company;
		        
		        platforms.Add(platformInList);
	        }
	        else
	        {
		        if (game != null)
			        platformInList.GamesList.Add(game);

		        if (company != null)
			        platformInList.Company = company;
	        }

	        return platform;
        }, splitOn: "Id,Id");

        return platforms;
    }
}