using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace MyGames.Repositories;

public class Repository<T> where T : class
{
    private readonly SqlConnection _connection;

    public Repository() => _connection = Database.Connection;

    public async Task CreateAsync(T model)
        => await _connection.InsertAsync(model);
}