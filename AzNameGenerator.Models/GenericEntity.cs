namespace AzNameGenerator.Models
{
    public class GenericEntity : IEntity
    {
        private string Name { get; set; }

        private string ShortCode { get; set; }

        private string LongCode { get; set; }

        /// <inheritdoc />
        public string GetName() => Name;

        public void SetName(string value) => Name = value;

        /// <inheritdoc />
        public string GetShortCode() => ShortCode;

        public void SetShortCode(string value) => ShortCode = value;

        /// <inheritdoc />
        public string GetLongCode() => LongCode;

        public void SetLongCode(string value) => LongCode = value;

        /// <inheritdoc />
        public string GetScope() => string.Empty;
    }
}
