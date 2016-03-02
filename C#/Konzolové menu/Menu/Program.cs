using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Menu
    {
        int act;
        int ent;
        string[] menu = new string[100];
        int size;
        public Menu(string text)
        {
            string[] split = text.Split(',');
            int V = 0;
            foreach (string s in split) 
            {
                menu[V] = "\t\t" + s + "\t\t\t";
                V++;
            }
            this.act = 0;
            this.ent = -1;
            this.prepocti(menu);
        }
        public void prepocti(string[] pole)
        {
            for(int i = 0; i<pole.Length; i++)
            {
                if(pole[i] != null) this.size++;
            }
        }
        public void vypis()
        {
            for (int i = 0; i < menu.GetLength(0); i++)
            {
                if (menu[i] != null)
                {
                    if (i != act) Console.BackgroundColor = ConsoleColor.DarkGray;
                    else { Console.BackgroundColor = ConsoleColor.DarkBlue; Console.Title = menu[i]; }
                    if (i == ent) Console.ForegroundColor = ConsoleColor.Red;
                    else Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(menu[i]);
                    Console.BackgroundColor = ConsoleColor.Blue;
                }
            }
        }
        public void pohyb(int smer)
        {
            if (smer == 1)
            {
                if (act > 0) act--;
                else act = this.size-1;
            }
            else if (smer == 2)
            {
                if (act < this.size-1) act++;
                else act = 0;
            }
            Console.Clear();
            this.vypis();
        }
        public void enter()
        {
            if(this.ent != this.act) this.ent = this.act;
            else this.ent = -1;
            Console.Clear();
            this.vypis();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Clear();
            Menu main = new Menu("jedna,dva,tri,ctyri,pet,sest,sedm,osm,dfsd");
            main.vypis();
            ConsoleKeyInfo temp;
            while (true)
            {
                temp = Console.ReadKey(true);
                if (temp.Key == ConsoleKey.UpArrow)
                    main.pohyb(1);
                else if (temp.Key == ConsoleKey.DownArrow)
                    main.pohyb(2);
                else if (temp.Key == ConsoleKey.Enter)
                    main.enter();
            }
        }
    }
}
