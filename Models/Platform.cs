using Dapper.Contrib.Extensions;

namespace MyGames.Models;

[Table("Platform")]
public class Platform
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int IdCompanyOwner { get; set; }
    [Write(false)]
    public Company? Company { get; set; }

    [Write(false)] public IList<Game> GamesList { get; set; } = new List<Game>();
}