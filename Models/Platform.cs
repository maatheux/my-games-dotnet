using Dapper.Contrib.Extensions;

namespace MyGames.Models;

[Table("Platform")]
public class Platform
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int IdCompanyOwner { get; set; }
}