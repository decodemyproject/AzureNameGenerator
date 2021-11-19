using System;
using System.Collections.Generic;
using AzNameGenerator.Models;

namespace AzNameGenerator.Converter
{
    public sealed class ConvertibleCollection
    {
        public ICasingStrategy CasingStrategy { get; set; }

        public IFormatStrategy FormatStrategy { get; set; }

        public List<IEntity> Input { get; set; }

        public List<string> Items { get; set; }

        public void Convert()
        {
            if (CasingStrategy == null)
            {
                throw new ArgumentNullException(nameof(CasingStrategy));
            }

            if (FormatStrategy == null)
            {
                throw new ArgumentNullException(nameof(FormatStrategy));
            }

            if (Input == null)
            {
                throw new ArgumentNullException(nameof(Input));
            }

            Items = FormatStrategy.Apply(Input);
            Items = CasingStrategy.Apply(Input, FormatStrategy);
        }

        public void UseLowercase()
        {
            CasingStrategy = new LowercaseStrategy();
        }

        public void UseShortFormat()
        {
            FormatStrategy = new ShortFormatStrategy();
        }

        public void UseLongFormat()
        {
            FormatStrategy = new LongFormatStrategy();
        }

        public void Add(IEntity entity)
        {
            Input ??= new List<IEntity>();
            Input.Add(entity);
        }
    }
}
