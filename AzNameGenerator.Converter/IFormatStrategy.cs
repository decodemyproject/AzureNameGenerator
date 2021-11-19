using System.Collections.Generic;
using AzNameGenerator.Models;

namespace AzNameGenerator.Converter
{
    public interface IFormatStrategy
    {
        public List<string> Apply(List<IEntity> input);
    }
}