using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoReflection.CustomedAttributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class Range : Attribute
    {
        public int MinLength { get; set; }
        public int MaxLength { get; set; }

        public Range(int min, int max)
        {
            MinLength = min;
            MaxLength = max;
        }

    }
}
