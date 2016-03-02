using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Vlakna___Monitor___Zamčení
{
    class Program
    {
        static object zamek = new object();
        static void pocitej()
        {
            Monitor.Enter(zamek);
            for (int i = 0; i < 2000; i++)
            {
                Console.WriteLine("{0} - {1}", Thread.CurrentThread.Name, i);
            }
            Monitor.Exit(zamek);
            
        }
        static void Main(string[] args)
        {
            Thread t1 = new Thread(pocitej);
            t1.Name = "vlakno 1";
            t1.Start();

            Thread.CurrentThread.Name = "Hlavni vlakno";
            pocitej();

            Console.ReadLine();
        }
    }
}
