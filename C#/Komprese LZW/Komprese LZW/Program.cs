using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Komprese_LZW
{
    class Program
    {
        static int GetIndex(List<string> list, string w)
        {
            int i = 0;
            foreach (string s in list)
            {
                if (s == w) return i;
                i++;
            }
            return -1;
        }
        static void Main(string[] args)
        {
            string vstup = "ABABABACDCDCDCACACA";
            List<string> list = new List<string>();
            list.Add("A");
            list.Add("B");
            list.Add("C");
            list.Add("D");
            string komprese = "";
            Console.WriteLine(GetIndex(list, "E"));
            for (int i = 0; i < vstup.Length; i++)
            {
                string find = vstup[i].ToString();
                if (GetIndex(list, find) == -1)
                {
                    list.Add(find);
                    Console.WriteLine("Do seznamu přidáno \"{0}\"", find);
                    komprese = komprese + "" + GetIndex(list, find).ToString();
                    continue;
                }
                if (i < vstup.Length - 1)
                {
                    if (i < vstup.Length - 2)
                    {
                        find = vstup[i] + "" + vstup[i + 1];
                        if (GetIndex(list, find) != -1)
                        {
                            find = find + "" + vstup[i + 2];
                            if (GetIndex(list, find) == -1)
                            {
                                list.Add(find);
                                Console.WriteLine("Do seznamu přidáno \"{0}\"", find);
                                komprese = komprese + "" + GetIndex(list, vstup[i].ToString()).ToString();
                                i++;
                                continue;
                            }
                        }
                    }
                    find = vstup[i] + "" + vstup[i + 1];
                    if (GetIndex(list, find) == -1)
                    {
                        list.Add(find);
                        Console.WriteLine("Do seznamu přidáno \"{0}\"", find);
                        komprese = komprese + "" + GetIndex(list, vstup[i].ToString()).ToString();
                        continue;
                    }
                    else
                    {
                        komprese = komprese + "" + GetIndex(list, find).ToString();
                        continue;
                    }
                }
            }
            int o = 0;
            foreach (string s in list)
            {
                Console.WriteLine(o + " - " + s);
                o++;
            }
            Console.WriteLine("Vstup:    " + vstup);
            Console.WriteLine("Komprese: " + komprese);
            Console.ReadLine();
        }
    }
}
