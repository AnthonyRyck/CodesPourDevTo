namespace WebApiGraphQl.Data
{
    public interface IDataAccess
    {
        IEnumerable<Personne> GetAll();
    }
}
