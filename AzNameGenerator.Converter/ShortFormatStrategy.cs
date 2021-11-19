using System.Collections.Generic;
using System.Linq;
using AzNameGenerator.Models;

namespace AzNameGenerator.Converter
{
    public class ShortFormatStrategy : IFormatStrategy
    {
        private List<string> Values { get; set; }

        private List<string> Apply(List<string> input)
        {
            Values = input;
            return Values;
        }

        /// <inheritdoc />
        public List<string> Apply(List<IEntity> input)
            => Apply(input.Select(entity => entity.GetShortCode()).ToList());
    }
}
