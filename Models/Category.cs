﻿using Dapper.Contrib.Extensions;

namespace MyGames.Models;

[Table("Category")]
public class Category
{
    
    public int Id { get; set; }
    public string Name { get; set; }
}