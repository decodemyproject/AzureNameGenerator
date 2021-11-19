using System.Collections.Generic;
using AzNameGenerator.Models;

namespace AzNameGenerator.Converter
{
    public class LowercaseStrategy : ICasingStrategy
    {
        public List<string> Apply(List<IEntity> input, IFormatStrategy formatStrategy) => formatStrategy.Apply(input);
    }
}
