using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLibrary
{
    [AttributeUsage(AttributeTargets.Method)]
    public class ExampleAttribute : Attribute
    {
        public ExampleAttribute(object x, object y, object z)
        {
        
         
        }

    }
}
