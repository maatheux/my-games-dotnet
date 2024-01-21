using Dapper.Contrib.Extensions;

namespace MyGames.Models;

[Table("GamePlatform")]
public class GamePlatform
{
    public int GameId { get; set; }
    public int PlatformId { get; set; }
}