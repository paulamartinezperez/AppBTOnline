using SQLite;
using AppBTOnline.Models;


namespace AppBTOnline.Data;

public class PlayerDatabase
{
    SQLiteAsyncConnection Database;
    public PlayerDatabase()
    {
    }
    async Task Init()
    {
        if (Database is not null)
            return;

        Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        var result = await Database.CreateTableAsync<Player>();
    }
    public async Task<List<Player>> GetItemsAsync()
    {
        await Init();
        return await Database.Table<Player>().ToListAsync();
    }

    public async Task<bool> CheckPlayerDetailsAsync(string playerName, string playerLastName, string playerSchool)
    {
        await Init();
        var players = await Database.Table<Player>().ToListAsync();
        return players.Any(player => player.Name.Equals(playerName) && player.Apellidos.Equals(playerLastName) && player.CentroEducativo.Equals(playerSchool));
    }


    //public async Task<List<Player>> GetItemsNotDoneAsync()
    //{
    //    await Init();
    //    return await Database.Table<Player>().Where(t => t.Done).ToListAsync();

    //    // SQL queries are also possible
    //    //return await Database.QueryAsync<TodoItem>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
    //}

    public async Task<Player> GetItemAsync(int id)
    {
        await Init();
        return await Database.Table<Player>().Where(i => i.ID == id).FirstOrDefaultAsync();
    }

    public async Task<int> SaveItemAsync(Player item)
    {
        await Init();

        if (item.ID != 0)
        {
            return await Database.UpdateAsync(item);
        }
        else
        {
            return await Database.InsertAsync(item);
        }
    }

    public async Task<int> DeleteItemAsync(Player item)
    {
        await Init();
        return await Database.DeleteAsync(item);
    }
}
