using Dapper;
using MyGames.Models;

namespace MyGames.Repositories;

public class CategoryRepository : Repository<Category>
{
    public async Task<IEnumerable<Category>> GetCategoriesWithGames()
    {
        string query = """
                           SELECT
                       	    Category.*,
                       	    Game.*
                           FROM MyGames.dbo.Category Category
                           LEFT JOIN MyGames.dbo.GameCategory GameCategory ON Category.Id = GameCategory.CategoryId
                           LEFT JOIN MyGames.dbo.Game Game on Game.Id = GameCategory.GameId;
                       """;

        List<Category> categories = new List<Category>();

        await _connection.QueryAsync<Category, Game, Category>(query, (category, game) =>
        {
            Category? categoryInList = categories.FirstOrDefault(x => x.Id == category.Id);

            if (categoryInList == null)
            {
                categoryInList = category;
                if (game != null)
                    categoryInList.GamesList.Add(game);
                
                categories.Add(categoryInList);
            }
            else
                if (game != null)
                    categoryInList.GamesList.Add(game);

            return category;
        }, splitOn: "Id");

        return categories;
    }
}