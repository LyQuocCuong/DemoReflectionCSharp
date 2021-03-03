using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoReflection.CustomedAttributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class Author : Attribute
    {
        public string Name { get; set; }
        public string Country { get; set; }
    }
}
