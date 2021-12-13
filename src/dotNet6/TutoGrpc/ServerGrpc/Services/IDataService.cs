
public interface IDataService
{
    /// <summary>
    /// Récupère l'utilisateur par rapport à son ID.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    User GetUser(string id);

    /// <summary>
    /// Récupère tous les utilisateurs.
    /// </summary>
    /// <returns></returns>
    User[] GetAllUser();

    /// <summary>
    /// Retourne le nombre d'utilisateur.
    /// </summary>
    /// <returns></returns>
    int GetCountUser();
}