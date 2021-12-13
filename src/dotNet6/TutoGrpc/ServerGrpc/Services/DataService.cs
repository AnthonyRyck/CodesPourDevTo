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
        return AllUsers.Users;
    }

    /// <see cref="IDataService.GetCountUser"/>
    public int GetCountUser()
    {
        return AllUsers.Users.Length;
    }

    /// <see cref="IDataService.GetUser(string)"/>
    public User GetUser(string id)
    {
        return AllUsers.Users.FirstOrDefault(x => x._id == id);
    }

    #endregion
}