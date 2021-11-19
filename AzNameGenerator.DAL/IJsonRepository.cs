namespace AzNameGenerator.DAL
{
    public interface IJsonRepository<out T> : IRepository<T> where T : class
    {

    }
}
