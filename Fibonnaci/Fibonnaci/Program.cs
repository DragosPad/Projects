using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonnaci
{
    class Program
    {
        static void Main(string[] args)
        {
            Fibo fib = new Fibo();
            bool printNumber = true;
            Console.Write("Enter the limit:");
            int count = int.Parse(Console.ReadLine());
            while (printNumber)
            {
                IEnumerator<int> enumer = Fibonnaci().GetEnumerator();
                //var enumer = Fibonnaci().GetEnumerator();
                Console.Write("Print more numbers Y/N : ");
                string answer = Console.ReadLine();
                if (answer == "N")
                {
                    printNumber = false;
                }
                else
                {
                    Console.WriteLine(enumer.Current);
                }
                enumer.MoveNext();
            }

            Console.WriteLine("Finish");
            Console.ReadLine();
        }
        private static IEnumerable<int> Fibonnaci()
        {
            int i, f1 = 0, f2 = 1, f3 = 0;

            yield return f1;
            yield return f2;

            while (true)
            {
                f3 = f1 + f2;
                yield return f3;
                f1 = f2;
                f2 = f3;
            }
        }
    }
}
