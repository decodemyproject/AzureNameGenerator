using System.Collections.Generic;
using System.IO;
using AzNameGenerator.Models;

namespace AzNameGenerator.DAL
{
    public class AzureResourceRepository : IJsonRepository<AzureResource>
    {
        private List<AzureResource> _azureResources;

        /// <inheritdoc />
        public AzureResource[] GetAll()
        {
            _azureResources ??= System.Text.Json.JsonSerializer
                .Deserialize<List<AzureResource>>(
                    File.ReadAllText("AzureResources.json"));

            return _azureResources?.ToArray();
        }
    }
}
