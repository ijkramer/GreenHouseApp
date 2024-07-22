using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;

namespace GreenHouseApp.Models
{

    public class PlantDatabase { 
    readonly SQLiteAsyncConnection _database;

    public PlantDatabase(string dbPath)
    {
        _database = new SQLiteAsyncConnection(dbPath);
        _database.CreateTableAsync<Plants>().Wait();
    }

    public Task<List<Plants>> GetItemsAsync()
    {
        return _database.Table<Plants>().ToListAsync();
    }

    public Task<Plants> GetItemAsync(int id)
    {
        return _database.Table<Plants>().Where(i => i.ID == id).FirstOrDefaultAsync();
    }

    public Task<int> SaveItemAsync(Plants item)
    {
        if (item.ID != 0)
        {
            return _database.UpdateAsync(item);
        }
        else
        {
            return _database.InsertAsync(item);
        }
    }

    public Task<int> DeleteItemAsync(Plants item)
    {
        return _database.DeleteAsync(item);
    }
}
}
