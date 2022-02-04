using System.Text.Json;

namespace WebApiGraphQl.Data
{
    public class DataAccess : IDataAccess
    {
        private IEnumerable<Personne> AllPeople;

        public DataAccess()
        {
            // Chargement des données JSON.
            string pathJson = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "JsonFile", "personnes.json");

            StreamReader reader = new StreamReader(pathJson);
            AllPeople = JsonSerializer.Deserialize<IEnumerable<Personne>>(reader.ReadToEnd());
        }

		/// <inheritdoc cref="IDataAccess.GetAll"/>
        public IEnumerable<Personne> GetAll()
        {
            return AllPeople;
        }

		/// <inheritdoc cref="IDataAccess.GetPersone(Guid)"/>
		public Personne GetPersonne(Guid id)
		{
			return AllPeople.FirstOrDefault(x => x.id == id);
		}
		
    }
}
