using System.Collections.Generic;
using System.Linq;
using AzNameGenerator.Models;

namespace AzNameGenerator.Converter
{
    public class LongFormatStrategy : IFormatStrategy
    {
        private List<string> Values { get; set; }

        private List<string> Apply(IEnumerable<string> input)
        {
            Values = input.Select(val => val.ToLower()).ToList();
            return Values;
        }

        /// <inheritdoc />
        public List<string> Apply(List<IEntity> input)
            => Apply(input.Select(entity => entity.GetLongCode()).ToList());
    }
}
