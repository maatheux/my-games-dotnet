using Dapper.Contrib.Extensions;

namespace MyGames.Models;

[Table("GamePlataform")]
public class GamePlataform
{
    public int GameId { get; set; }
    public int PlataformId { get; set; }
}