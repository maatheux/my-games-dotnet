using Dapper.Contrib.Extensions;

namespace MyGames.Models;

[Table("Plataform")]
public class Plataform
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int IdCompanyOwner { get; set; }
}