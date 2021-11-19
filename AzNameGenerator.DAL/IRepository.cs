namespace AzNameGenerator.DAL
{
    public interface IRepository<out T> where T : class
    {
        T[] GetAll();
    }
}
