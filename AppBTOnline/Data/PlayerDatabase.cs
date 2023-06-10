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
        await Database.CreateTableAsync<Player>();
        await Database.CreateTableAsync<Intento>();

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

    public async Task<List<Intento>> AllPlayerintentos(int id)
    {
        await Init();
        return await Database.Table<Intento>().Where(aux => aux.IDPlayer == id).ToListAsync();
         
    }

    public async Task<List<Intento>> AllPlayerintentoPregunta(int id, int num_pregunta)
    {
        await Init();
        return await Database.Table<Intento>().Where(aux => aux.IDPlayer == id && aux.IDCuestion == num_pregunta).ToListAsync();

    }

    public async Task<int> GetPlayerIntentoPreguntaCount(int id, int num_pregunta)
    {
        await Init();
        var intentos = await Database.Table<Intento>().Where(aux => aux.IDPlayer == id && aux.IDCuestion == num_pregunta).ToListAsync();
        return intentos.Count;
    }

    public async Task<int> SaveIntento(Intento item)
    {
        await Init();
        return await Database.InsertAsync(item);
    }


}
