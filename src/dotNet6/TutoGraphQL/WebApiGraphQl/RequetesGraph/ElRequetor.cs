using TutoGraphQl.Models;

namespace WebApiGraphQl.RequetesGraph
{
    public class ElRequetor
    {
        private IDataAccess _access;

        public ElRequetor(IDataAccess dataAccess)
        {
            _access = dataAccess;
        }


        public IEnumerable<Personne> GetPersonnesAsync()
        {
            return _access.GetAll();
        }

		public Personne GetPersonneById(Guid id)
		{
			return _access.GetPersonne(id);
		}

    }
}
