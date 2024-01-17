using Dapper.Contrib.Extensions;

namespace MyGames.Models;

[Table("Game")]
public class Game
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime Release { get; set; }
    public int Rating { get; set; }
    public bool FavoriteFlag { get; set; }
    public bool WishlistFlag { get; set; }
    public int PublisherId { get; set; }

    [Write(false)]
    public IEnumerable<Category> Categories { get; set; } = new List<Category>();
    [Write(false)]
    public IEnumerable<Plataform> Plataforms { get; set; } = new List<Plataform>();
}