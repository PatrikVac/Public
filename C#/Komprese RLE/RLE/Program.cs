using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Vstupní text komprese: ");
            string s = Console.ReadLine();
            string op = "";
            int poc = 1;
            Console.WriteLine(s);
            for (int i = 0; i < s.Length; i++)
            {
                if (i == s.Length - 1)
                {
                    if (poc > 1)
                    {
                        op = op + s[i] + poc;
                        poc = 1;
                    }
                    else
                    {
                        op = op + s[i];
                    }
                    break;
                }
                if (s[i] == s[i + 1]) poc++;
                else
                {
                    if (poc > 1)
                    {
                        op = op + s[i] + poc;
                        poc = 1;
                    }
                    else
                    {
                        op = op + s[i];
                    }                      
                }
            }
            Console.WriteLine(op);
            Console.ReadLine();
        }
    }
}
