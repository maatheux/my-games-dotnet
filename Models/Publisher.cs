using Dapper.Contrib.Extensions;

namespace MyGames.Models;

[Table("Publisher")]
public class Publisher
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Country { get; set; }
}