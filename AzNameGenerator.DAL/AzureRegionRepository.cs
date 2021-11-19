using System.Collections.Generic;
using System.IO;
using AzNameGenerator.Models;

namespace AzNameGenerator.DAL
{
    public class AzureRegionRepository : IJsonRepository<AzureRegion>
    {
        private List<AzureRegion> _azureRegions;

        /// <inheritdoc />
        public AzureRegion[] GetAll()
        {
            _azureRegions ??= System.Text.Json.JsonSerializer
                .Deserialize<List<AzureRegion>>(
                    File.ReadAllText("AzureRegions.json"));

            return _azureRegions?.ToArray();
        }
    }
}
