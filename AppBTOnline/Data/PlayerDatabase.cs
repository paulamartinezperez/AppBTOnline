using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Pomelo.EntityFrameworkCore.MySql.Storage;
using Microsoft.EntityFrameworkCore;
using AppBTOnline.Models;
using System;

namespace AppBTOnline.Data;

public class PlayerDatabase
{
    AppDbContext Database;
    public PlayerDatabase()
    {
        string connectionString = Constants.DatabasePath;
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 27)));

        Database = new AppDbContext(optionsBuilder.Options);
    }

    public async Task<List<Player>> GetItemsAsync()
    {
        return await Database.Players.ToListAsync();
    }

    public async Task<bool> CheckPlayerDetailsAsync(string playerName, string playerLastName, string playerSchool)
    {
        var players = await Database.Players.ToListAsync();
        return players.Any(player => player.Name.Equals(playerName) && player.Apellidos.Equals(playerLastName) && player.CentroEducativo.Equals(playerSchool));
    }

    public async Task<Player> GetItemAsync(int id)
    {
        return await Database.Players.FirstOrDefaultAsync(i => i.ID == id);
    }

    public async Task<int> SaveItemAsync(Player item)
    {
        if (item.ID != 0)
        {
            Database.Players.Update(item);
        }
        else
        {
            Database.Players.Add(item);
        }

        return await Database.SaveChangesAsync();
    }

    public async Task<int> DeleteItemAsync(Player item)
    {
        Database.Players.Remove(item);
        return await Database.SaveChangesAsync();
    }
}
