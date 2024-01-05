using Dapper.Contrib.Extensions;

namespace MyGames.Models;

[Table("Category")]
public class Category : Base
{
    public string Name { get; set; }
}