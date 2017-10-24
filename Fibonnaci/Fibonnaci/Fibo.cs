using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonnaci
{
    public class Fibo
    {
        private static IEnumerable<int> Fibonnaci()
        {
            int f1 = 0, f2 = 1, f3 = 0;

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
