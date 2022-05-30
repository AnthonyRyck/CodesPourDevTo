namespace WebApi.Services
{
    public interface IDataAccess
    {
		/// <summary>
		/// Retourne toutes personnes
		/// </summary>
		/// <returns></returns>
        IEnumerable<Personne> GetAll();

		/// <summary>
		/// Retourne la personne par rapport à son ID
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Personne GetPersonne(Guid id);

	}
}
