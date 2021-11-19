namespace AzNameGenerator.Models
{
    public class AzureResource : IEntity
    {
        public string Name { get; set; }

        public string ShortCode { get; set; }

        public string LongCode { get; set; }

        public string Scope { get; set; }

        /// <inheritdoc />
        public string GetName() => Name;

        /// <inheritdoc />
        public string GetShortCode() => ShortCode;

        /// <inheritdoc />
        public string GetLongCode() => LongCode ??= ShortCode;

        /// <inheritdoc />
        public string GetScope() => Scope;
    }
}
