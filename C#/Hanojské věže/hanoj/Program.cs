using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hanoj
{
    class Program
    {
        static void hanoj(int n, char leva, char prostredni, char prava)
        {
            if(n>1)
                hanoj(n-1, leva, prava, prostredni);
            Console.WriteLine("Krouzek byl prehozen ze sloupce {0} na sloupec {1}", leva, prava);
            if(n>1)
                hanoj(n-1, prostredni, leva, prava);
        }
        static void Main(string[] args)
        {
            hanoj(3, 'A', 'B', 'C');
            Console.ReadLine();
        }
    }
}
