﻿using Dapper.Contrib.Extensions;

namespace MyGames.Models;

[Table("Company")]
public class Company
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Ceo { get; set; }
    [Write(false)]
    public IEnumerable<Plataform> Plataforms { get; set; } = new List<Plataform>();
}