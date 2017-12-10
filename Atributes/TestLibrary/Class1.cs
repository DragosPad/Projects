using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;


namespace TestLibrary
{
    public class Class1
    {
        public void RunAttribute()
        {

            var assembly = Assembly.GetEntryAssembly();
            var types = assembly.GetTypes();
            foreach (var type in types)
            {

                var methods = type.GetMethods();

                foreach (var method in methods)
                {
                   var attribute = method.GetCustomAttribute<ExampleAttribute>();
                   if (attribute != null)
                   {
                      var instance = Activator.CreateInstance(type);
                      method.Invoke(instance, attribute.Parameters);
                   }
                }
            }

        }

    }
}
