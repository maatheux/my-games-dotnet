using Dapper.Contrib.Extensions;

namespace MyGames.Models;

public class Base
{
    [Write(false)]
    public int Id { get; set; }
}