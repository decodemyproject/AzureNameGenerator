namespace AzNameGenerator.Models
{
    public interface IEntity
    {
        string GetName();

        string GetShortCode();

        string GetLongCode();

        string GetScope();
    }
}
