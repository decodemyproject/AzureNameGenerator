using AzNameGenerator.Models;

namespace AzNameGenerator.DAL
{
    public class EnvironmentRepository : IRepository<Environment>
    {
        /// <inheritdoc />
        public Environment[] GetAll() => new Environment[]
        {
            new Environment("Production", "prod","production"),
            new Environment("Staging", "staging","staging"),
            new Environment("Test", "test","test"),
            new Environment("Development", "development","development")
        };
    }
}
