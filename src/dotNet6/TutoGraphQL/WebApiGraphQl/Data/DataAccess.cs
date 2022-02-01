using System.Text.Json;
using System.Text.Json.Serialization;

namespace WebApiGraphQl.Data
{
    public class DataAccess : IDataAccess
    {
        private IEnumerable<Personne> Personnes;

        public DataAccess()
        {
            // Chargement des données JSON.
            string pathJson = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "JsonFile", "personnes.json");

            StreamReader reader = new StreamReader(pathJson);
            Personnes = JsonSerializer.Deserialize<IEnumerable<Personne>>(reader.ReadToEnd());
        }

        public IEnumerable<Personne> GetAll()
        {
            return Personnes;
        }
    }
}
