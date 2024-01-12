using Dapper.Contrib.Extensions;

namespace MyGames.Models;

public class Base
{
    [Write(false)]
    [Key]
    public int Id { get; set; }
}