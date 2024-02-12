using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace MyGames.Repositories;

public class Repository<T> where T : class
{
    protected readonly SqlConnection _connection;

    public Repository() => _connection = Database.Connection;

    public async Task CreateAsync(T model)
        => await _connection.InsertAsync(model);

    public async Task<IEnumerable<T>> ListAsync()
        => await _connection.GetAllAsync<T>();

    public async Task<T>? GetAsync(int id)
        => await _connection.GetAsync<T>(id);

    public async Task DeleteAsync(T model)
        => await _connection.DeleteAsync<T>(model);

    public async Task DeleteAsync(int id)
    {
        if (id != 0)
        {
            var model = GetAsync(id).Result;

            await _connection.DeleteAsync<T>(model);
        }
    }

    public async Task UpdateAsync(T model)
        => await _connection.UpdateAsync(model);
}