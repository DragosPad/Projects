using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clasa
{
    class Program
    {
        static void Main(string[] args)
        {
            Contact c = new Contact();
            //c.DateOfBirth = new DateTime(1943, 12, 8);
            //Console.WriteLine(c.ToString());
            //Console.WriteLine(c.age);
            //c.F();
            //Console.WriteLine(c.age);
            //c.G();
            //Console.WriteLine(c.age);

            c.FirstName = "Jim";
            c.LastName = "Marison";
            //c.VerifyEmailAddress("joe@example.com");
            bool result = c.VerifyEmailAddress("joe@example.com");
            Console.WriteLine(c.ToString());
            c.Search(37.479444f, -122.450278f);
            c.Search(37.479444f, -122.450278f, 50);
            c.Search(37.479444f, -122.450278f, 50, "en");
           Console.WriteLine(c.VerifyEmailAddress("joe@example.com"));
           Console.WriteLine(c.VerifyEmailAddress("jim@example.com"));

            Console.ReadLine();

        }
    }
}
