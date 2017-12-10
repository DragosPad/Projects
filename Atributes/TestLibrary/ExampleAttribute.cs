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
        private object[] parameters;

        public object[] Parameters
        {
            get {
                return parameters;
            }
         
        }

        public ExampleAttribute(params object[] parameters)
        {
            this.parameters = parameters;
        }

    }
}
