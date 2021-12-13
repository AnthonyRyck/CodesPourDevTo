using System.Text.Json;

public class DataService : IDataService
{

    private UsersCollection AllUsers;


    public DataService()
    {
        AllUsers = LoadData()
                    .GetAwaiter()
                    .GetResult();
    }


    private async Task<UsersCollection> LoadData()
    {
        string pathFile = Path.Combine(AppContext.BaseDirectory, "Data", "Users.json");

        // En utilisant un stream.
        using(var stream = File.OpenRead(pathFile))
        {
            return await JsonSerializer.DeserializeAsync<UsersCollection>(stream);
        }
    }


    #region IDataService Implementation

    /// <see cref="IDataService.GetAllUser"/>
    public User[] GetAllUser()
    {
        throw new NotImplementedException();
    }

    /// <see cref="IDataService.GetCountUser"/>
    public int GetCountUser()
    {
        throw new NotImplementedException();
    }

    /// <see cref="IDataService.GetUser(string)"/>
    public User GetUser(string id)
    {
        throw new NotImplementedException();
    }

    #endregion
}