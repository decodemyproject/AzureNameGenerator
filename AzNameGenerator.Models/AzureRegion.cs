namespace AzNameGenerator.Models
{
    public class AzureRegion : IEntity
    {
        public string Name { get; set; }

        public string GeoShortCode { get; set; }

        public string DatacenterShortCode { get; set; }

        public string ShortCode { get; set; }

        public string Encoding { get; set; }

        public string GeoID { get; set; }

        public string DatacenterID { get; set; }

        public string Scope { get; set; }

        /// <inheritdoc />
        public string GetName() => Name;

        /// <inheritdoc />
        public string GetShortCode() => GeoShortCode;

        /// <inheritdoc />
        public string GetLongCode() => ShortCode;

        /// <inheritdoc />
        public string GetScope() => Scope;
    }
}
