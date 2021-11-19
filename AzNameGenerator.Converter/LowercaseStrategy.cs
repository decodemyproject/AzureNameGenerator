using System.Collections.Generic;
using System.Linq;
using AzNameGenerator.Models;

namespace AzNameGenerator.Converter
{
    public class LowercaseStrategy : ICasingStrategy
    {
        public List<string> Apply(List<IEntity> input, IFormatStrategy strategy) => strategy.Apply(input);
    }
}
