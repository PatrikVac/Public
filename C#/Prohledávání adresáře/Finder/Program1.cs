using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Finder
{
    class Program
    {
        static void Main(string[] args)
        {
            string search = Console.ReadLine();
            //Najdi(@"S:\Soundtracks", 0, search);
            Console.Clear();
            Console.Write("Klíčové slovo \"{0}\" nalezeno:", search);
            NajdiD(@"s:\Soundtracks", 0, search);

            Console.ReadKey();
        }
        static void Najdi(string dir, int uroven, string search)
        {
            foreach (string s in Directory.GetDirectories(dir))
            {
                string srch = s.Replace(dir + "\\", "");
                if (search == srch)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(s);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    VyberSoubory(s, srch);
                    break;
                }
                else
                {
                    Najdi(s, uroven + 1, search);
                    Console.WriteLine(s);
                }
            }
        }
        static void VyberSoubory(string srch, string bsrch)
        {
            foreach (string s in Directory.GetFiles(srch))
            {
                string write = s.Replace(srch + "\\", "");
                Console.WriteLine("" + write);
            }
        }
        static void NajdiD(string dir, int uroven, string search)
        {
            int end = 0;
            foreach (string a in Directory.GetDirectories(dir))
            {
                string fo = a.Replace(dir + "\\", "");
                string diric = "";
                if (fo.ToLower().Contains(search.ToLower()))
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("\nSložka: ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(fo);
                    diric = dir + "\\" + fo + "\\";
                    Console.ForegroundColor = ConsoleColor.Gray;
                    end = 1;
                }
                string bub;
                if (diric != "") bub = diric;
                else bub = a;
                DirectoryInfo di = new DirectoryInfo(bub);
                FileInfo[] file = di.GetFiles();
                foreach (FileInfo b in file)
                {
                    //string fs = b.Replace(a + "\\", "");

                    if (b.ToString().ToLower().Contains(search.ToLower()))
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("\nSoubor: ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("{0} ", b);
                        Console.ForegroundColor = ConsoleColor.Gray;
                        string j = b.FullName.Replace(dir, "");
                        Console.WriteLine("({0})", j.Replace("\\" + b.ToString(), ""));
                        Console.ForegroundColor = ConsoleColor.Gray;
                        end = 1;
                    }
                    else if (diric != "")
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("\tSoubor: ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(b);
                        Console.ForegroundColor = ConsoleColor.Gray;
                        end = 1;
                    }

                }
                diric = "";

            }
            if (end == 0)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Soubor \"{0}\" nebyl nalezen!", search);
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }
    }
}