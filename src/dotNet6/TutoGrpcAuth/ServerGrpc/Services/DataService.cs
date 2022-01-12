using System.Text.Json;

public class DataService : IDataService
{

    private List<User> AllUsers;


    public DataService()
    {
        AllUsers = LoadData()
                    .GetAwaiter()
                    .GetResult();
    }


    private async Task<List<User>> LoadData()
    {
        string pathFile = Path.Combine(AppContext.BaseDirectory, "Data", "Users.json");
        List<User> result = new List<User>();

        using (var stream = File.OpenRead(pathFile))
        {
            result = await JsonSerializer.DeserializeAsync<List<User>>(stream);
        }

        return result;
    }


    #region IDataService Implementation

    /// <see cref="IDataService.GetAllUser"/>
    public User[] GetAllUser()
    {
        return AllUsers.ToArray();
    }

    /// <see cref="IDataService.GetCountUser"/>
    public int GetCountUser()
    {
        return AllUsers.Count;
    }

    /// <see cref="IDataService.GetUser(string)"/>
    public User GetUser(string id)
    {
        return AllUsers.FirstOrDefault(x => x._id == id);
    }

    #endregion
}