using Dapper.Contrib.Extensions;

namespace MyGames.Models;

[Table("GameCategory")]
public class GameCategory
{
    public int GameId { get; set; }
    public int CategoryId { get; set; }
}