using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication2
{
    class Program
    {
        struct kralici
        {
            public int pohlavi;
            public int vek;
            public int X;
            public int Y;
            public int mnozil;
            public int zivy;
        }
        static void Main(string[] args)
        {
            Console.Write("Velikost pole X: ");
            int zadX = Convert.ToInt32(Console.ReadLine());
            Console.Write("Velikost pole Y: ");
            int zadY = Convert.ToInt32(Console.ReadLine());
            Console.Write("Věk králíků: ");
            int Kvek = Convert.ToInt32(Console.ReadLine());
            Console.Write("Počet králíků (MAX. {0}): ", Math.Round(zadX * zadY * 0.3));
            int pocet = Convert.ToInt32(Console.ReadLine());
            while (pocet > Math.Round(zadX * zadY * 0.3))
            {
                Console.Write("Moc králíků, zadejte znovu: ");
                pocet = Convert.ToInt32(Console.ReadLine());
            }

            // Vytvoření proměnných
            int Mpoc = pocet;
            int cykl = 0;
            string[,] pole = new string[zadX, zadY];
            kralici[] kralik = new kralici[zadX * zadY];
            int[] volnyi = new int[zadX * zadY];
            Random random = new Random();
            // naplnění pole 0-x
            for (int i = 0; i < volnyi.Length; i++)
                volnyi[i] = i;
            // první králíci
            for (int k = 0; k < pocet; k++)
            {
                kralik[k].vek = 1;
                kralik[k].zivy = 1;
                kralik[k].mnozil = 0;
                switch (random.Next(2))
                {
                    case 0: kralik[k].pohlavi = 1; break;
                    case 1: kralik[k].pohlavi = 2; break;
                }
                for (int i = 0; i < volnyi.Length; i++)
                    if (k == volnyi[i]) volnyi[i] = -1;
                kralik[k].X = random.Next(zadX); // vygenerování pozice X
                kralik[k].Y = random.Next(zadY); // vygenerování pozice Y
                for (int ki = 0; ki < pocet; ki++)
                {
                    if (kralik[k].X == kralik[ki].X && kralik[k].Y == kralik[ki].Y)
                        while (kralik[k].X != kralik[ki].X && kralik[k].Y != kralik[ki].Y)
                        {
                            kralik[k].X = random.Next(zadX);
                            kralik[k].Y = random.Next(zadY);
                        }
                }
            }
            while (pocet < zadX * zadY * 0.3 && pocet > 0)
            {
                cykl++;
                Console.Clear();
                if (Mpoc < pocet) Mpoc = pocet; // Mpoc je id králíka s nejvyšším pořadovým číslem v poli
                for (int i = 0; i < pole.GetLength(0); i++)
                {
                    for (int j = 0; j < pole.GetLength(1); j++)
                    {
                        // projde všechny králíky
                        for (int k = 0; k < Mpoc; k++)
                        {
                            if (kralik[k].X == i && kralik[k].Y == j)
                            {
                                // Zkontroluje věk, případně králíka odstraní
                                if (kralik[k].vek == Kvek + 1)
                                {
                                    kralik[k].zivy = 0;
                                    pocet--;
                                    kralik[k].X = -1;
                                    kralik[k].Y = -1;
                                    for (int v = 0; v < volnyi.Length; v++)
                                    {
                                        if (volnyi[v] == -1) { volnyi[v] = k; break; }
                                    }
                                }
                                else kralik[k].vek++;
                                // cyklus množení, králík se může množit ob-kolo
                                if (kralik[k].mnozil == 2) kralik[k].mnozil = 0;
                                if (kralik[k].mnozil == 1) kralik[k].mnozil = 2;
                                // nastaví barvu a na daných souřadnicích vytvoří králíka
                                if (kralik[k].zivy == 1)
                                {
                                    if (kralik[k].pohlavi == 1)
                                        Console.ForegroundColor = ConsoleColor.Blue;
                                    else
                                        Console.ForegroundColor = ConsoleColor.Red;
                                    pole[i, j] = "Q";
                                }
                                else
                                    pole[i, j] = " ";
                                break;
                            }
                            else
                                pole[i, j] = " ";
                        }
                        // Vypsání
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.Write(pole[i, j]);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    Console.WriteLine();
                }
                // zvolí náhodně novou souřadnici v okolí předchozí
                for (int k = 0; k < Mpoc; k++)
                {
                    bool zmena = false;
                    if (pocet > 0 && kralik[k].zivy == 1)
                    {
                        while (zmena == false)
                        {
                            switch (random.Next(9))
                            {
                                case 0:
                                    {
                                        if (kralik[k].X < zadX - 1)
                                        {
                                            bool zm = false;
                                            for (int ki = 0; ki < Mpoc; ki++)
                                                if (kralik[k].X + 1 == kralik[ki].X && kralik[k].Y == kralik[ki].Y) zm = true;
                                            if (zm == false)
                                            {
                                                kralik[k].X++;
                                                zmena = true;
                                                break;
                                            }
                                            else zm = false;
                                        }
                                        break;
                                    }
                                case 1:
                                    {
                                        if (kralik[k].X > 0)
                                        {
                                            bool zm = false;
                                            for (int ki = 0; ki < Mpoc; ki++)
                                                if (kralik[k].X - 1 == kralik[ki].X && kralik[k].Y == kralik[ki].Y) zm = true;
                                            if (zm == false)
                                            {
                                                kralik[k].X--;
                                                zmena = true;
                                                break;
                                            }
                                            else zm = false;
                                        }
                                        break;

                                    }
                                case 2:
                                    {
                                        if (kralik[k].Y < zadY - 1)
                                        {
                                            bool zm = false;
                                            for (int ki = 0; ki < Mpoc; ki++)
                                                if (kralik[k].X == kralik[ki].X && kralik[k].Y + 1 == kralik[ki].Y) zm = true;
                                            if (zm == false)
                                            {
                                                kralik[k].Y++;
                                                zmena = true;
                                                break;
                                            }
                                            else zm = false;
                                        }
                                        break;
                                    }
                                case 3:
                                    {
                                        if (kralik[k].Y > 0)
                                        {
                                            bool zm = false;
                                            for (int ki = 0; ki < Mpoc; ki++)
                                                if (kralik[k].X == kralik[ki].X && kralik[k].Y - 1 == kralik[ki].Y) zm = true;
                                            if (zm == false)
                                            {
                                                kralik[k].Y--;
                                                zmena = true;
                                                break;
                                            }
                                            else zm = false;
                                        }

                                    }
                                    break;
                                case 4:
                                    {
                                        if (kralik[k].X < zadX - 1 && kralik[k].Y < zadY - 1)
                                        {
                                            bool zm = false;
                                            for (int ki = 0; ki < Mpoc; ki++)
                                                if (kralik[k].X + 1 == kralik[ki].X && kralik[k].Y + 1 == kralik[ki].Y) zm = true;
                                            if (zm == false)
                                            {
                                                kralik[k].Y++;
                                                kralik[k].X++;
                                                zmena = true;
                                                break;
                                            }
                                            else zm = false;
                                        }
                                        break;
                                    }
                                case 5:
                                    {
                                        if (kralik[k].X > 0 && kralik[k].Y < zadY - 1)
                                        {
                                            bool zm = false;
                                            for (int ki = 0; ki < Mpoc; ki++)
                                                if (kralik[k].X - 1 == kralik[ki].X && kralik[k].Y + 1 == kralik[ki].Y) zm = true;
                                            if (zm == false)
                                            {
                                                kralik[k].Y++;
                                                kralik[k].X--;
                                                zmena = true;
                                                break;
                                            }
                                            else zm = false;
                                        }
                                        break;
                                    }
                                case 6:
                                    {
                                        if (kralik[k].X < zadX - 1 && kralik[k].Y > 0)
                                        {
                                            bool zm = false;
                                            for (int ki = 0; ki < Mpoc; ki++)
                                                if (kralik[k].X + 1 == kralik[ki].X && kralik[k].Y - 1 == kralik[ki].Y) zm = true;
                                            if (zm == false)
                                            {
                                                kralik[k].Y--;
                                                kralik[k].X++;
                                                zmena = true;
                                                break;
                                            }
                                            else zm = false;
                                        }
                                        break;
                                    }
                                case 7:
                                    {
                                        if (kralik[k].X > 0 && kralik[k].Y > 0)
                                        {
                                            bool zm = false;
                                            for (int ki = 0; ki < Mpoc; ki++)
                                                if (kralik[k].X - 1 == kralik[ki].X && kralik[k].Y - 1 == kralik[ki].Y) zm = true;
                                            if (zm == false)
                                            {
                                                kralik[k].Y--;
                                                kralik[k].X--;
                                                zmena = true;
                                                break;
                                            }
                                            else zm = false;
                                        }
                                        break;
                                    }
                                default:
                                    {
                                        bool zm = false;
                                        for (int ki = 0; ki < Mpoc; ki++)
                                            if (kralik[k].X == kralik[ki].X && kralik[k].Y == kralik[ki].Y) zm = true;
                                        if (zm == false)
                                        {
                                            zmena = true;
                                            break;
                                        }
                                        else zm = false;
                                    }
                                    break;
                            }
                        }
                    }
                }
                // zkontroluje vzájemnou polohu králíků a případně pomnoží
                for (int k = 0; k < Mpoc; k++)
                {
                    for (int kralikID = 0; kralikID < Mpoc; kralikID++) // projde ostatní králíky
                    {
                        if (kralik[k].X == kralik[kralikID].X + 1 || kralik[k].X == kralik[kralikID].X - 1)
                        {
                            if (kralik[k].Y == kralik[kralikID].Y + 1 || kralik[k].Y == kralik[kralikID].Y - 1 || kralik[k].Y == kralik[kralikID].Y)
                            {
                                if (kralik[k].vek < Kvek && kralik[kralikID].vek < Kvek && kralik[k].vek > 1 && kralik[kralikID].vek > 1 && kralik[k].mnozil == 0 && kralik[kralikID].mnozil == 0 && kralik[k].pohlavi != kralik[kralikID].pohlavi && kralik[k].zivy == 1 && kralik[kralikID].zivy == 1)
                                {
                                    kralik[k].mnozil = 1;
                                    kralik[kralikID].mnozil = 1;
                                    int nid = -1;
                                    pocet++;
                                    for (int v = 0; v < volnyi.Length; v++)
                                    {
                                        if (volnyi[v] != -1)
                                        {
                                            nid = volnyi[v];
                                            volnyi[v] = -1;
                                            break;
                                        }
                                    }
                                    kralik[nid].mnozil = 0;
                                    kralik[nid].vek = 1;
                                    kralik[nid].zivy = 1;
                                    switch (random.Next(2))
                                    {
                                        case 0: kralik[nid].pohlavi = 1; break;
                                        case 1: kralik[nid].pohlavi = 2; break;
                                    }
                                    kralik[nid].X = random.Next(zadX); // vygenerování pozice X
                                    kralik[nid].Y = random.Next(zadY); // vygenerování pozice Y
                                    for (int ki = 0; ki < pocet; ki++)
                                    {
                                        if (kralik[k].X == kralik[ki].X && kralik[k].Y == kralik[ki].Y)
                                            while (kralik[k].X != kralik[ki].X && kralik[k].Y != kralik[ki].Y)
                                            {
                                                kralik[k].X = random.Next(zadX);
                                                kralik[k].Y = random.Next(zadY);
                                            }
                                    }
                                }
                            }
                        }
                        else if (kralik[k].Y == kralik[kralikID].Y + 1 || kralik[k].Y == kralik[kralikID].Y - 1)
                        {
                            if (kralik[k].X == kralik[kralikID].X + 1 || kralik[k].X == kralik[kralikID].X - 1 || kralik[k].X == kralik[kralikID].X)
                            {
                                if (kralik[k].vek < Kvek && kralik[kralikID].vek < Kvek && kralik[k].vek > 1 && kralik[kralikID].vek > 1 && kralik[k].mnozil == 0 && kralik[kralikID].mnozil == 0 && kralik[k].pohlavi != kralik[kralikID].pohlavi && kralik[k].zivy == 1 && kralik[kralikID].zivy == 1)
                                {
                                    kralik[k].mnozil = 1;
                                    kralik[kralikID].mnozil = 1;
                                    int nid = -1;
                                    pocet++;
                                    for (int v = 0; v < volnyi.Length; v++)
                                    {
                                        if (volnyi[v] != -1)
                                        {
                                            nid = volnyi[v];
                                            volnyi[v] = -1;
                                            break;
                                        }
                                    }
                                    kralik[nid].mnozil = 0;
                                    kralik[nid].vek = 1;
                                    kralik[nid].zivy = 1;
                                    switch (random.Next(2))
                                    {
                                        case 0: kralik[nid].pohlavi = 1; break;
                                        case 1: kralik[nid].pohlavi = 2; break;
                                    }
                                    kralik[nid].X = random.Next(zadX); // vygenerování pozice X
                                    kralik[nid].Y = random.Next(zadY); // vygenerování pozice Y
                                    for (int ki = 0; ki < pocet; ki++)
                                    {
                                        if (kralik[k].X == kralik[ki].X && kralik[k].Y == kralik[ki].Y)
                                            while (kralik[k].X != kralik[ki].X && kralik[k].Y != kralik[ki].Y)
                                            {
                                                kralik[k].X = random.Next(zadX);
                                                kralik[k].Y = random.Next(zadY);
                                            }
                                    }
                                }
                            }
                        }
                    }
                }
                Console.CursorVisible = false;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("{0}. rok | {1} králíků", cykl, pocet);
                if (pocet == 0) { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Došlo k vymření kolonie. "); }
                else if (pocet >= zadX * zadY * 0.3) { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Králící se přemnožili. "); }
                else Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.ReadLine();
        }
    }
}
