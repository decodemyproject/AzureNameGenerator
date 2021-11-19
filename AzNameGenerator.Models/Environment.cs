using System.Collections.Generic;

namespace AzNameGenerator.Models
{
    public class Environment : IEntity
    {
        private string Name { get; }

        private string ShortCode { get; }

        private string LongCode { get; }

        public Environment(string name, string shortCode, string longCode)
        {
            Name = name;
            ShortCode = shortCode;
            LongCode = longCode;
        }

        /// <inheritdoc />
        public string GetName() => Name;

        /// <inheritdoc />
        public string GetShortCode() => ShortCode;

        /// <inheritdoc />
        public string GetLongCode() => LongCode;

        /// <inheritdoc />
        public string GetScope() => string.Empty;
    }
}
