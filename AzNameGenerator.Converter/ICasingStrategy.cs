using System.Collections.Generic;
using AzNameGenerator.Models;

namespace AzNameGenerator.Converter
{
    public interface ICasingStrategy
    {
        public List<string> Apply(List<IEntity> input, IFormatStrategy formatStrategy);
    }
}
