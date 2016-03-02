using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ConsoleApplication1
{
    class Program
    {
        struct souradnice
        {
            public int X;
            public int Y;
        }
        struct lod
        {
            public souradnice cast1;
            public souradnice cast2;
            public souradnice cast3;
            public souradnice cast4;
            public souradnice cast5;
            public souradnice cast6;
            public souradnice cast7;
            public bool potopena;
        }
        static souradnice zamereni;
        static souradnice posledni;
        static souradnice PosledniVystrel;
        static int HracScore = 0;
        static int PCScore = 0;
        static string status = "ZAČÁTEK";
        static void Novy(string[,] pole1, string[,] pole2, lod[] lod_hrac, lod[] lod_PC)
        {  
            for (int i = 0; i < pole2.GetLength(0); i++)
            {
                for (int j = 0; j < pole2.GetLength(1); j++)
                {
                    pole1[i, j] = "  ";
                    pole2[i, j] = "  ";
                }
            }
            for (int l = 0; l < lod_PC.Length; l++)
            {
                lod_hrac[l].cast1.X = -1; lod_hrac[l].cast1.Y = -1;
                lod_hrac[l].cast2.X = -1; lod_hrac[l].cast2.Y = -1;
                lod_hrac[l].cast3.X = -1; lod_hrac[l].cast3.Y = -1;
                lod_hrac[l].cast4.X = -1; lod_hrac[l].cast4.Y = -1;
                lod_hrac[l].cast5.X = -1; lod_hrac[l].cast5.Y = -1;
                lod_hrac[l].cast6.X = -1; lod_hrac[l].cast6.Y = -1;
                lod_hrac[l].cast7.X = -1; lod_hrac[l].cast7.Y = -1;
                lod_hrac[l].potopena = false;

                lod_PC[l].cast1.X = -1; lod_PC[l].cast1.Y = -1;
                lod_PC[l].cast2.X = -1; lod_PC[l].cast2.Y = -1;
                lod_PC[l].cast3.X = -1; lod_PC[l].cast3.Y = -1;
                lod_PC[l].cast4.X = -1; lod_PC[l].cast4.Y = -1;
                lod_PC[l].cast5.X = -1; lod_PC[l].cast5.Y = -1;
                lod_PC[l].cast6.X = -1; lod_PC[l].cast6.Y = -1;
                lod_PC[l].cast7.X = -1; lod_PC[l].cast7.Y = -1;
                lod_PC[l].potopena = false;
            }
        }
        static void UmistiLod(int X, int Y, int i, lod[] lod)
        {
            if (i == 9)
            {
                lod[i].cast1.X = X; lod[i].cast1.Y = Y;
                lod[i].cast2.X = X; lod[i].cast2.Y = Y - 1;
                lod[i].cast3.X = X; lod[i].cast3.Y = Y + 1;
                lod[i].cast4.X = X; lod[i].cast4.Y = Y - 2;
                lod[i].cast5.X = X; lod[i].cast5.Y = Y + 2;
                lod[i].cast6.X = X - 1; lod[i].cast6.Y = Y - 1;
                lod[i].cast7.X = X - 1; lod[i].cast7.Y = Y + 1;
            }
            if (i < 4)
            {
                lod[i].cast1.X = X; lod[i].cast1.Y = Y;
                lod[i].cast2.X = X; lod[i].cast2.Y = Y + 1;
            }
            if (i == 6 || i == 5 || i == 4)
            {
                lod[i].cast1.X = X; lod[i].cast1.Y = Y;
                lod[i].cast2.X = X; lod[i].cast2.Y = Y + 1;
                lod[i].cast3.X = X; lod[i].cast3.Y = Y - 1;
            }
            if (i == 7 || i == 8)
            {
                lod[i].cast1.X = X; lod[i].cast1.Y = Y;
                lod[i].cast2.X = X; lod[i].cast2.Y = Y + 1;
                lod[i].cast3.X = X; lod[i].cast3.Y = Y - 1;
                lod[i].cast4.X = X - 1; lod[i].cast4.Y = Y;
            }

        }
        static void UMISTI(lod[] lod, string[,] pole, string[,] PC, lod[] lod_PC)
        {
            Random random = new Random();
            int velikost = pole.GetLength(0);
            Console.CursorVisible = false;
            for (int i = 9; i >= 0; i--)
            {
                if (i == 9)
                {
                    lod[i].cast1.X = 0;
                    lod[i].cast1.Y = 0;
                    int X = random.Next(velikost);
                    int Y = random.Next(velikost);
                    while (X == 0 || X == velikost - 1 || Y == 0 || Y == velikost - 1 || pole[X, Y] != "  " || pole[X - 1, Y] != "  " || pole[X + 1, Y] != "  " || pole[X, Y - 1] != "  " || pole[X, Y + 1] != "  " || pole[X + 1, Y + 1] != "  " || pole[X - 1, Y - 1] != "  " || pole[X + 1, Y - 1] != "  " || pole[X - 1, Y + 1] != "  ")
                    {
                        X = random.Next(velikost);
                        Y = random.Next(velikost);
                    }
                    pole[X, Y] = " L";
                    if (Y <= velikost - 5 && Y >= 4 && X != velikost && X >= 2 && pole[X, Y + 2] == "  " && pole[X, Y + 3] == "  " && pole[X, Y - 2] == "  " && pole[X, Y - 3] == "  " && pole[X - 1, Y + 2] == "  " && pole[X - 1, Y + 3] == "  " && pole[X - 1, Y - 2] == "  " && pole[X - 1, Y - 3] == "  " && pole[X + 1, Y + 2] == "  " && pole[X + 1, Y + 3] == "  " && pole[X + 1, Y - 2] == "  " && pole[X + 1, Y - 3] == "  " && pole[X - 2, Y - 2] == "  " && pole[X - 2, Y - 1] == "  " && pole[X - 2, Y] == "  " && pole[X - 2, Y + 1] == "  " && pole[X - 2, Y + 2] == "  ")
                    {
                        pole[X, Y + 1] = " L";
                        pole[X, Y - 1] = " L";
                        pole[X, Y + 2] = " L";
                        pole[X, Y - 2] = " L";
                        pole[X - 1, Y - 1] = " L";
                        pole[X - 1, Y + 1] = " L";
                        UmistiLod(X, Y, i, lod);
                        Vypsat(pole, PC, lod, lod_PC);
                        ConsoleKeyInfo temp;
                        while (true)
                        {
                            temp = Console.ReadKey(true);
                            if (temp.Key == ConsoleKey.UpArrow)
                            {
                                if (X-2 != 0)
                                {
                                    pole[X, Y] = "  ";
                                    pole[X, Y + 1] = "  ";
                                    pole[X, Y - 1] = "  ";
                                    pole[X, Y + 2] = "  ";
                                    pole[X, Y - 2] = "  ";
                                    pole[X - 1, Y - 1] = "  ";
                                    pole[X - 1, Y + 1] = "  ";
                                    if(pole[X - 1, Y] == "  ") pole[X - 1, Y] = " L";
                                    if (pole[X - 1, Y+1] == "  ") pole[X - 1, Y + 1] = " L";
                                    if (pole[X - 1, Y-1] == "  ") pole[X - 1, Y - 1] = " L";
                                    if (pole[X - 1, Y+2] == "  ") pole[X - 1, Y + 2] = " L";
                                    if (pole[X - 1, Y-2] == "  ") pole[X - 1, Y - 2] = " L";
                                    if (pole[X - 2, Y-1] == "  ") pole[X - 2, Y - 1] = " L";
                                    if (pole[X - 2, Y+1] == "  ") pole[X - 2, Y + 1] = " L";
                                    X--;
                                    Console.Clear();
                                    UmistiLod(X, Y, i, lod);
                                    Vypsat(pole, PC, lod, lod_PC);
                                }
                            }
                            else if (temp.Key == ConsoleKey.DownArrow)
                            {
                                if (X + 2 != velikost)
                                {
                                    pole[X, Y] = "  ";
                                    pole[X, Y + 1] = "  ";
                                    pole[X, Y - 1] = "  ";
                                    pole[X, Y + 2] = "  ";
                                    pole[X, Y - 2] = "  ";
                                    pole[X - 1, Y - 1] = "  ";
                                    pole[X - 1, Y + 1] = "  ";
                                    if(pole[X + 1, Y] == "  ") pole[X + 1, Y] = " L";
                                    if (pole[X + 1, Y+1] == "  ") pole[X + 1, Y + 1] = " L";
                                    if (pole[X + 1, Y-1] == "  ") pole[X + 1, Y - 1] = " L";
                                    if (pole[X + 1, Y+2] == "  ") pole[X + 1, Y + 2] = " L";
                                    if (pole[X + 1, Y-2] == "  ") pole[X + 1, Y - 2] = " L";
                                    if (pole[X, Y-1] == "  ") pole[X, Y - 1] = " L";
                                    if (pole[X, Y+1] == "  ") pole[X, Y + 1] = " L";
                                    X++;
                                    Console.Clear();
                                    UmistiLod(X, Y, i, lod);
                                    Vypsat(pole, PC, lod, lod_PC);
                                }
                            }
                            else if (temp.Key == ConsoleKey.LeftArrow)
                            {
                                if (Y - 3 != 0)
                                {
                                    pole[X, Y] = "  ";
                                    pole[X, Y + 1] = "  ";
                                    pole[X, Y - 1] = "  ";
                                    pole[X, Y + 2] = "  ";
                                    pole[X, Y - 2] = "  ";
                                    pole[X - 1, Y - 1] = "  ";
                                    pole[X - 1, Y + 1] = "  ";
                                    if (pole[X, Y - 1] == "  ") pole[X, Y - 1] = " L";
                                    if (pole[X, Y] == "  ") pole[X, Y] = " L";
                                    if (pole[X, Y -2] == "  ") pole[X, Y - 2] = " L";
                                    if (pole[X, Y + 1] == "  ") pole[X, Y + 1] = " L";
                                    if (pole[X, Y -3] == "  ") pole[X, Y - 3] = " L";
                                    if (pole[X-1, Y -2] == "  ") pole[X - 1, Y - 2] = " L";
                                    if (pole[X-1, Y] == "  ") pole[X - 1, Y] = " L";
                                    Y--;
                                    Console.Clear();
                                    UmistiLod(X, Y, i, lod);
                                    Vypsat(pole, PC, lod, lod_PC);
                                }
                            }
                            else if (temp.Key == ConsoleKey.RightArrow)
                            {
                                if (Y + 4 != velikost)
                                {
                                    pole[X, Y] = "  ";
                                    pole[X, Y + 1] = "  ";
                                    pole[X, Y - 1] = "  ";
                                    pole[X, Y + 2] = "  ";
                                    pole[X, Y - 2] = "  ";
                                    pole[X - 1, Y - 1] = "  ";
                                    pole[X - 1, Y + 1] = "  ";
                                    if(pole[X, Y + 1] == "  ") pole[X, Y + 1] = " L";
                                    if (pole[X, Y + 2] == "  ") pole[X, Y + 2] = " L";
                                    if (pole[X, Y] == "  ") pole[X, Y] = " L";
                                    if (pole[X, Y + 3] == "  ") pole[X, Y + 3] = " L";
                                    if (pole[X, Y - 1] == "  ") pole[X, Y - 1] = " L";
                                    if (pole[X - 1, Y] == "  ") pole[X - 1, Y] = " L";
                                    if (pole[X - 1, Y + 2] == "  ") pole[X - 1, Y + 2] = " L";
                                    Y++;
                                    Console.Clear();
                                    UmistiLod(X, Y, i, lod);
                                    Vypsat(pole, PC, lod, lod_PC);
                                }
                            }
                            else if (temp.Key == ConsoleKey.Enter)
                            {
                                UmistiLod(X, Y, i, lod);
                                Console.Clear();
                                break;
                            }
                        }
                    }
                    else
                    {
                        i++;
                        pole[X, Y] = "  ";
                    }
                }
                if (i < 4)
                {
                    int X = random.Next(velikost);
                    int Y = random.Next(velikost);
                    while (X == 0 || X == velikost - 1 || Y == 0 || Y == velikost - 1 || pole[X, Y] != "  " || pole[X - 1, Y] != "  " || pole[X + 1, Y] != "  " || pole[X, Y - 1] != "  " || pole[X, Y + 1] != "  " || pole[X + 1, Y + 1] != "  " || pole[X - 1, Y - 1] != "  " || pole[X + 1, Y - 1] != "  " || pole[X - 1, Y + 1] != "  ")
                    {
                        X = random.Next(velikost);
                        Y = random.Next(velikost);
                    }
                    pole[X, Y] = " L";
                    if (Y != velikost - 1 && Y + 2 != velikost && Y + 1 != velikost - 1 && pole[X, Y + 1] == "  " && pole[X, Y + 2] == "  " && pole[X + 1, Y + 2] == "  " && pole[X - 1, Y + 2] == "  ")
                    {
                        pole[X, Y + 1] = " L";
                        UmistiLod(X, Y, i, lod);
                        Vypsat(pole, PC, lod, lod_PC);
                        ConsoleKeyInfo temp;
                        while (true)
                        {
                            temp = Console.ReadKey(true);
                            if (temp.Key == ConsoleKey.UpArrow)
                            {
                                if (X != 1)
                                {
                                    if (pole[X - 1, Y] == "  " && pole[X - 1, Y + 1] == "  ")
                                    {
                                        pole[X, Y] = "  ";
                                        pole[X, Y + 1] = "  ";
                                        pole[X - 1, Y] = " L";
                                        pole[X - 1, Y + 1] = " L";
                                        X--;
                                    }
                                    Console.Clear();
                                    UmistiLod(X, Y, i, lod);
                                    Vypsat(pole, PC, lod, lod_PC);
                                }
                            }
                            else if (temp.Key == ConsoleKey.DownArrow)
                            {
                                if (X != velikost-2)
                                {
                                    if (pole[X + 1, Y] == "  " && pole[X + 1, Y + 1] == "  ")
                                    {
                                        pole[X, Y] = "  ";
                                        pole[X, Y + 1] = "  ";
                                        pole[X + 1, Y] = " L";
                                        pole[X + 1, Y + 1] = " L";
                                        X++;
                                    }
                                    Console.Clear();
                                    UmistiLod(X, Y, i, lod);
                                    Vypsat(pole, PC, lod, lod_PC);
                                }
                            }
                            else if (temp.Key == ConsoleKey.LeftArrow)
                            {
                                if (Y - 1 != 0)
                                {
                                    if (pole[X, Y-1] == "  ")
                                    {
                                        pole[X, Y] = "  ";
                                        pole[X, Y + 1] = "  ";
                                        pole[X, Y-1] = " L";
                                        pole[X, Y] = " L";
                                        Y--;
                                    }
                                    Console.Clear();
                                    UmistiLod(X, Y, i, lod);
                                    Vypsat(pole, PC, lod, lod_PC);
                                }
                            }
                            else if (temp.Key == ConsoleKey.RightArrow)
                            {
                                if (Y != velikost-3)
                                {
                                    if (pole[X, Y + 2] == "  ")
                                    {
                                        pole[X, Y] = "  ";
                                        pole[X, Y+2] = " L";
                                        Y++;
                                    }
                                    Console.Clear();
                                    UmistiLod(X, Y, i, lod);
                                    Vypsat(pole, PC, lod, lod_PC);
                                }
                            }
                            else if (temp.Key == ConsoleKey.Enter)
                            {
                                if (pole[X - 1, Y] == "  " && pole[X - 1, Y + 1] == "  " && pole[X - 1, Y + 2] == "  " && pole[X - 1, Y - 1] == "  " && pole[X + 1, Y] == "  " && pole[X + 1, Y + 1] == "  " && pole[X + 1, Y + 2] == "  " && pole[X + 1, Y - 1] == "  " && pole[X, Y - 1] == "  " && pole[X, Y +2] == "  ")
                                {
                                    Console.Clear();
                                    break;
                                }
                                else CHYBA();
                            }
                        }
                    }
                    else
                    {
                        pole[X, Y] = "  ";
                        i++;
                    }
                }
                if (i == 4 || i == 5 || i == 6)
                {
                    int X = random.Next(velikost);
                    int Y = random.Next(velikost);
                    while (X == 0 || X == velikost - 1 || Y == 0 || Y == velikost - 1 || pole[X, Y] != "  " || pole[X - 1, Y] != "  " || pole[X + 1, Y] != "  " || pole[X, Y - 1] != "  " || pole[X, Y + 1] != "  " || pole[X + 1, Y + 1] != "  " || pole[X - 1, Y - 1] != "  " || pole[X + 1, Y - 1] != "  " || pole[X - 1, Y + 1] != "  ")
                    {
                        X = random.Next(velikost);
                        Y = random.Next(velikost);
                    }
                    if (Y <= velikost - 3 && Y >= 2 && X != velikost && X != 0 && pole[X, Y + 1] == "  " && pole[X + 1, Y + 1] == "  " && pole[X - 1, Y + 1] == "  " && pole[X, Y - 1] == "  " && pole[X + 1, Y - 1] == "  " && pole[X - 1, Y - 1] == "  " && pole[X, Y + 2] == "  " && pole[X - 1, Y + 2] == "  " && pole[X + 1, Y + 2] == "  " && pole[X, Y - 2] == "  " && pole[X + 1, Y - 2] == "  " && pole[X - 1, Y - 2] == "  ")
                    {
                        pole[X, Y] = " L";
                        pole[X, Y + 1] = " L";
                        pole[X, Y - 1] = " L";
                        UmistiLod(X, Y, i, lod);
                        Vypsat(pole, PC, lod, lod_PC);
                        ConsoleKeyInfo temp;
                        while (true)
                        {
                            temp = Console.ReadKey(true);
                            if (temp.Key == ConsoleKey.UpArrow)
                            {
                                if (X != 1)
                                {
                                    if (pole[X - 1, Y] == "  " && pole[X - 1, Y - 1] == "  " && pole[X - 1, Y + 1] == "  ")
                                    {
                                        pole[X, Y] = "  ";
                                        pole[X, Y - 1] = "  ";
                                        pole[X, Y + 1] = "  ";
                                        pole[X-1, Y] = " L";
                                        pole[X-1, Y - 1] = " L";
                                        pole[X-1, Y + 1] = " L";
                                        X--;
                                    }
                                    Console.Clear();
                                    UmistiLod(X, Y, i, lod);
                                    Vypsat(pole, PC, lod, lod_PC);
                                }
                            }
                            else if (temp.Key == ConsoleKey.DownArrow)
                            {
                                if (X != velikost - 2)
                                {
                                    if (pole[X + 1, Y] == "  " && pole[X + 1, Y - 1] == "  " && pole[X + 1, Y + 1] == "  ")
                                    {
                                        pole[X, Y] = "  ";
                                        pole[X, Y - 1] = "  ";
                                        pole[X, Y + 1] = "  ";
                                        pole[X + 1, Y] = " L";
                                        pole[X + 1, Y - 1] = " L";
                                        pole[X + 1, Y + 1] = " L";
                                        X++;
                                    }
                                    Console.Clear();
                                    UmistiLod(X, Y, i, lod);
                                    Vypsat(pole, PC, lod, lod_PC);
                                }
                            }
                            else if (temp.Key == ConsoleKey.LeftArrow)
                            {
                                if (Y != 2)
                                {
                                    if (pole[X, Y - 2] == "  ")
                                    {
                                        pole[X, Y + 1] = "  ";
                                        pole[X, Y - 2] = " L";
                                        Y--;
                                    }
                                    Console.Clear();
                                    UmistiLod(X, Y, i, lod);
                                    Vypsat(pole, PC, lod, lod_PC);
                                }
                            }
                            else if (temp.Key == ConsoleKey.RightArrow)
                            {
                                if (Y != velikost - 3)
                                {
                                    if (pole[X, Y + 2] == "  ")
                                    {
                                        pole[X, Y - 1] = "  ";
                                        pole[X, Y + 2] = " L";
                                        Y++;
                                    }
                                    Console.Clear();
                                    UmistiLod(X, Y, i, lod);
                                    Vypsat(pole, PC, lod, lod_PC);
                                }
                            }
                            else if (temp.Key == ConsoleKey.Enter)
                            {
                                if (pole[X + 1, Y] == "  " && pole[X + 1, Y + 1] == "  " && pole[X + 1, Y - 1] == "  " && pole[X + 1, Y + 2] == "  " && pole[X + 1, Y - 2] == "  " && pole[X - 1, Y + 1] == "  " && pole[X - 1, Y] == "  " && pole[X - 1, Y - 1] == "  " && pole[X - 1, Y + 2] == "  " && pole[X - 1, Y - 2] == "  " && pole[X, Y + 2] == "  " && pole[X, Y - 2] == "  ")
                                {
                                    Console.Clear();
                                    break;
                                }
                                else CHYBA();
                            }
                        }
                    }
                    else
                    {
                        i++;
                        pole[X, Y] = "  ";
                    }
                }
                if (i == 7 || i == 8)
                {
                    int X = random.Next(velikost);
                    int Y = random.Next(velikost);
                    while (X == 0 || X == velikost - 1 || Y == 0 || Y == velikost - 1 || pole[X, Y] != "  " || pole[X - 1, Y] != "  " || pole[X + 1, Y] != "  " || pole[X, Y - 1] != "  " || pole[X, Y + 1] != "  " || pole[X + 1, Y + 1] != "  " || pole[X - 1, Y - 1] != "  " || pole[X + 1, Y - 1] != "  " || pole[X - 1, Y + 1] != "  ")
                    {
                        X = random.Next(velikost);
                        Y = random.Next(velikost);
                    }
                    pole[X, Y] = " O";
                    if (Y <= velikost - 3 && Y >= 2 && X != velikost && X >= 2 && pole[X, Y + 1] == "  " && pole[X + 1, Y + 1] == "  " && pole[X - 1, Y + 1] == "  " && pole[X, Y - 1] == "  " && pole[X + 1, Y - 1] == "  " && pole[X - 1, Y - 1] == "  " && pole[X, Y + 2] == "  " && pole[X - 1, Y + 2] == "  " && pole[X + 1, Y + 2] == "  " && pole[X, Y - 2] == "  " && pole[X + 1, Y - 2] == "  " && pole[X - 1, Y - 2] == "  " && pole[X - 1, Y] == "  " && pole[X - 2, Y] == "  " && pole[X - 2, Y + 1] == "  " && pole[X - 2, Y - 1] == "  ")
                    {
                        pole[X, Y + 1] = " L";
                        pole[X, Y - 1] = " L";
                        pole[X - 1, Y] = " L";
                        UmistiLod(X, Y, i, lod);
                        Vypsat(pole, PC, lod, lod_PC);
                        ConsoleKeyInfo temp;
                        while (true)
                        {
                            temp = Console.ReadKey(true);
                            if (temp.Key == ConsoleKey.UpArrow)
                            {
                                if (X != 2)
                                {
                                    if (pole[X - 1, Y - 1] == "  " && pole[X - 1, Y + 1] == "  " && pole[X - 2, Y] == "  ")
                                    {
                                        pole[X, Y] = "  ";
                                        pole[X, Y - 1] = "  ";
                                        pole[X, Y + 1] = "  ";
                                        pole[X-1, Y] = "  ";
                                        pole[X - 1, Y] = " L";
                                        pole[X - 1, Y - 1] = " L";
                                        pole[X - 1, Y + 1] = " L";
                                        pole[X - 2, Y] = " L";
                                        X--;
                                    }
                                    Console.Clear();
                                    UmistiLod(X, Y, i, lod);
                                    Vypsat(pole, PC, lod, lod_PC);
                                }
                            }
                            else if (temp.Key == ConsoleKey.DownArrow)
                            {
                                if (X != velikost - 2)
                                {
                                    if (pole[X + 1, Y] == "  " && pole[X + 1, Y - 1] == "  " && pole[X + 1, Y + 1] == "  " && pole[X + 2, Y] == "  ")
                                    {
                                        pole[X, Y - 1] = "  ";
                                        pole[X, Y + 1] = "  ";
                                        pole[X-1, Y] = "  ";
                                        pole[X + 1, Y] = " L";
                                        pole[X + 1, Y - 1] = " L";
                                        pole[X + 1, Y + 1] = " L";
                                        X++;
                                    }
                                    Console.Clear();
                                    UmistiLod(X, Y, i, lod);
                                    Vypsat(pole, PC, lod, lod_PC);
                                }
                            }
                            else if (temp.Key == ConsoleKey.LeftArrow)
                            {
                                if (Y != 2)
                                {
                                    if (pole[X, Y - 2] == "  " && pole[X-1, Y - 1] == "  ")
                                    {
                                        pole[X, Y + 1] = "  ";
                                        pole[X-1, Y] = "  ";
                                        pole[X, Y - 2] = " L";
                                        pole[X - 1, Y - 1] = " L";
                                        Y--;
                                    }
                                    Console.Clear();
                                    UmistiLod(X, Y, i, lod);
                                    Vypsat(pole, PC, lod, lod_PC);
                                }
                            }
                            else if (temp.Key == ConsoleKey.RightArrow)
                            {
                                if (Y != velikost - 3)
                                {
                                    if (pole[X, Y + 2] == "  " && pole[X - 1, Y + 1] == "  ")
                                    {
                                        pole[X, Y - 1] = "  ";
                                        pole[X - 1, Y] = "  ";
                                        pole[X, Y + 2] = " L";
                                        pole[X - 1, Y + 1] = " L";
                                        Y++;
                                    }
                                    Console.Clear();
                                    UmistiLod(X, Y, i, lod);
                                    Vypsat(pole, PC, lod, lod_PC);
                                }
                            }
                            else if (temp.Key == ConsoleKey.Enter)
                            {
                                if (pole[X + 1, Y] == "  " && pole[X + 1, Y + 1] == "  " && pole[X + 1, Y - 1] == "  " && pole[X + 1, Y + 2] == "  " && pole[X + 1, Y - 2] == "  " && pole[X, Y + 2] == "  " && pole[X, Y - 2] == "  " && pole[X - 2, Y] == "  " && pole[X - 1, Y + 2] == "  " && pole[X - 1, Y - 2] == "  " && pole[X - 2, Y - 1] == "  " && pole[X - 2, Y + 1] == "  ")
                                {
                                    Console.Clear();
                                    break;
                                }
                                else CHYBA();
                            }
                        }
                    }
                    else
                    {
                        i++;
                        pole[X, Y] = "  ";
                    }
                }
            }
            for (int i = 0; i < pole.GetLength(0); i++)
            {
                for (int j = 0; j < pole.GetLength(1); j++)
                {
                    pole[i, j] = "  ";
                }
            }
            Console.WriteLine("Hra může začít");
            //Console.WriteLine(Y + "-" + X + "-" + pos.Length);
        }
        static void CHYBA()
        {
            Console.Beep();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Sem nemůže být umístěna loď!");
        }
        static void GEN(lod[] lod_PC, string[,] PC)
        {
            int velikost = PC.GetLength(0);
            Random random = new Random();
            for (int i = 9; i >= 0; i--)
            {
                if (i == 9)
                {
                    int X = random.Next(velikost);
                    int Y = random.Next(velikost);
                    while (X == 0 || X == velikost - 1 || Y == 0 || Y == velikost - 1 || PC[X, Y] != "  " || PC[X - 1, Y] != "  " || PC[X + 1, Y] != "  " || PC[X, Y - 1] != "  " || PC[X, Y + 1] != "  " || PC[X + 1, Y + 1] != "  " || PC[X - 1, Y - 1] != "  " || PC[X + 1, Y - 1] != "  " || PC[X - 1, Y + 1] != "  ")
                    {
                        X = random.Next(velikost);
                        Y = random.Next(velikost);
                    }
                    if (Y <= velikost - 5 && Y >= 4 && X != velikost && X >= 2 && PC[X, Y + 2] == "  " && PC[X, Y + 3] == "  " && PC[X, Y - 2] == "  " && PC[X, Y - 3] == "  " && PC[X - 1, Y + 2] == "  " && PC[X - 1, Y + 3] == "  " && PC[X - 1, Y - 2] == "  " && PC[X - 1, Y - 3] == "  " && PC[X + 1, Y + 2] == "  " && PC[X + 1, Y + 3] == "  " && PC[X + 1, Y - 2] == "  " && PC[X + 1, Y - 3] == "  " && PC[X - 2, Y - 2] == "  " && PC[X - 2, Y - 1] == "  " && PC[X - 2, Y] == "  " && PC[X - 2, Y + 1] == "  " && PC[X - 2, Y + 2] == "  ")
                    {
                        PC[X, Y] = " L";
                        PC[X, Y + 1] = " L";
                        PC[X, Y - 1] = " L";
                        PC[X, Y + 2] = " L";
                        PC[X, Y - 2] = " L";
                        PC[X - 1, Y - 1] = " L";
                        PC[X - 1, Y + 1] = " L";
                        UmistiLod(X, Y, i, lod_PC);
                    }
                    else
                        i++;
                }
                // generování 4 malých lodí
                if (i < 4)
                {
                    int X = random.Next(velikost);
                    int Y = random.Next(velikost);
                    while (X == 0 || X == velikost - 1 || Y == 0 || Y == velikost - 1 || PC[X, Y] != "  " || PC[X - 1, Y] != "  " || PC[X + 1, Y] != "  " || PC[X, Y - 1] != "  " || PC[X, Y + 1] != "  " || PC[X + 1, Y + 1] != "  " || PC[X - 1, Y - 1] != "  " || PC[X + 1, Y - 1] != "  " || PC[X-1, Y+1] != "  ")
                    {
                        X = random.Next(velikost);
                        Y = random.Next(velikost);
                    }
                    PC[X, Y] = " L";
                    if (Y != velikost - 1 && Y + 2 != velikost && Y + 1 != velikost - 1 && PC[X, Y + 1] == "  " && PC[X, Y + 2] == "  " && PC[X + 1, Y + 2] == "  " && PC[X - 1, Y + 2] == "  ")
                    {
                        PC[X, Y + 1] = " L";
                        UmistiLod(X, Y, i, lod_PC);
                    }
                    else
                    {
                        PC[X, Y] = "  ";
                        i++;
                    }
                }
                // generování 3 větších lodí
                if (i == 4 || i == 5 || i == 6)
                {
                    int X = random.Next(velikost);
                    int Y = random.Next(velikost);
                    while (X == 0 || X == velikost - 1 || Y == 0 || Y == velikost - 1 || PC[X, Y] != "  " || PC[X - 1, Y] != "  " || PC[X + 1, Y] != "  " || PC[X, Y - 1] != "  " || PC[X, Y + 1] != "  " || PC[X + 1, Y + 1] != "  " || PC[X - 1, Y - 1] != "  " || PC[X + 1, Y - 1] != "  " || PC[X - 1, Y + 1] != "  ")
                    {
                        X = random.Next(velikost);
                        Y = random.Next(velikost);
                    }
                    PC[X, Y] = " L";
                    if (Y <= velikost - 3 && Y >= 2 && X != velikost && X != 0 && PC[X, Y + 1] == "  " && PC[X + 1, Y + 1] == "  " && PC[X - 1, Y + 1] == "  " && PC[X, Y - 1] == "  " && PC[X + 1, Y - 1] == "  " && PC[X - 1, Y - 1] == "  " && PC[X, Y + 2] == "  " && PC[X - 1, Y + 2] == "  " && PC[X + 1, Y + 2] == "  " && PC[X, Y - 2] == "  " && PC[X + 1, Y - 2] == "  " && PC[X - 1, Y - 2] == "  ")
                    {
                        PC[X, Y + 1] = " L";
                        PC[X, Y - 1] = " L";
                        UmistiLod(X, Y, i, lod_PC);
                    }
                    else
                    {
                        i++;
                        PC[X, Y] = "  ";
                    }
                }
                // generování 2 křižníků
                if (i == 7 || i == 8)
                {
                    int X = random.Next(velikost);
                    int Y = random.Next(velikost);
                    while (X == 0 || X == velikost - 1 || Y == 0 || Y == velikost - 1 || PC[X, Y] != "  " || PC[X - 1, Y] != "  " || PC[X + 1, Y] != "  " || PC[X, Y - 1] != "  " || PC[X, Y + 1] != "  " || PC[X + 1, Y + 1] != "  " || PC[X - 1, Y - 1] != "  " || PC[X + 1, Y - 1] != "  " || PC[X - 1, Y + 1] != "  ")
                    {
                        X = random.Next(velikost);
                        Y = random.Next(velikost);
                    }
                    PC[X, Y] = " L";
                    if (Y <= velikost - 3 && Y >= 2 && X != velikost && X >= 2 && PC[X, Y + 1] == "  " && PC[X + 1, Y + 1] == "  " && PC[X - 1, Y + 1] == "  " && PC[X, Y - 1] == "  " && PC[X + 1, Y - 1] == "  " && PC[X - 1, Y - 1] == "  " && PC[X, Y + 2] == "  " && PC[X - 1, Y + 2] == "  " && PC[X + 1, Y + 2] == "  " && PC[X, Y - 2] == "  " && PC[X + 1, Y - 2] == "  " && PC[X - 1, Y - 2] == "  " && PC[X - 1, Y] == "  " && PC[X - 2, Y] == "  " && PC[X - 2, Y + 1] == "  " && PC[X - 2, Y - 1] == "  ")
                    {
                        PC[X, Y + 1] = " L";
                        PC[X, Y - 1] = " L";
                        PC[X-1, Y] = " L";
                        UmistiLod(X, Y, i, lod_PC);
                    }
                    else
                    {
                        i++;
                        PC[X, Y] = "  ";
                    }
                }
            }
            for (int i = 0; i < PC.GetLength(0); i++)
            {
                for (int j = 0; j < PC.GetLength(1); j++)
                {
                    PC[i, j] = "  ";
                }
            }
        }
        static void Vypsat(string[,] hrac, string[,] PC, lod[] lod_hrac, lod[] lod_PC)
        {
            char[] abc = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t\t\tSTATUS: {0} \t\t\t ", status);
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("\t   HRAC: {0} \t\t\t\t PC: {1}\t\t ",HracScore, PCScore);
            for (int i = 0; i < hrac.GetLength(0); i++)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
                Console.Write(abc[i] + " ");
            }
            Console.Write("     ");
            for (int i = 0; i < hrac.GetLength(0); i++)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
                Console.Write(abc[i] + " ");
            }
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.Blue;
            for (int i = 0; i < hrac.GetLength(0); i++)
            {
                for (int j = 0; j < hrac.GetLength(1); j++)
                {
                    if (hrac[i, j] == " V")
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write("  ");
                        Console.BackgroundColor = ConsoleColor.Blue;
                    }
                    else if (hrac[i, j] == " Z")
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.Write("  ");
                        Console.BackgroundColor = ConsoleColor.Blue;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                        for (int l = 0; l < lod_hrac.Length; l++)
                        {
                            if (i != 0 && j != 0)
                            {
                                if (lod_hrac[l].cast1.X == i && lod_hrac[l].cast1.Y == j) Console.BackgroundColor = ConsoleColor.Green;
                                if (lod_hrac[l].cast2.X == i && lod_hrac[l].cast2.Y == j) Console.BackgroundColor = ConsoleColor.Green;
                                if (lod_hrac[l].cast3.X == i && lod_hrac[l].cast3.Y == j) Console.BackgroundColor = ConsoleColor.Green;
                                if (lod_hrac[l].cast4.X == i && lod_hrac[l].cast4.Y == j) Console.BackgroundColor = ConsoleColor.Green;
                                if (lod_hrac[l].cast5.X == i && lod_hrac[l].cast5.Y == j) Console.BackgroundColor = ConsoleColor.Green;
                                if (lod_hrac[l].cast6.X == i && lod_hrac[l].cast6.Y == j) Console.BackgroundColor = ConsoleColor.Green;
                                if (lod_hrac[l].cast7.X == i && lod_hrac[l].cast7.Y == j) Console.BackgroundColor = ConsoleColor.Green;
                            }
                        }
                        Console.Write("  ");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.BackgroundColor = ConsoleColor.Blue;
                    }
                }
                // Vypsání sloupce s čísly
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                if (i+1 < 10)
                    Console.Write("  {0}  ", i+1);
                else
                    Console.Write("  {0} ", i+1);
                // Vypsání pole Počítače
                for (int j = 0; j < PC.GetLength(1); j++)
                {
                    if (i == zamereni.X && j == zamereni.Y)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write(PC[i, j]);
                    }
                    else if (PC[i, j] == " V")
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write(PC[i, j]);
                    }
                    else if (PC[i, j] == " Z")
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(PC[i, j]);
                    }
                    else if (PC[i, j] == "  ")
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.Write("  ");
                    }
                }
                Console.WriteLine();
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void strileni(string[,] hrac, string[,] PC, lod[] lod_hrac, lod[] lod_PC)
        {
            int velikost = PC.GetLength(0);
            if (zamereni.X == -1 && zamereni.Y == -1)
            {
                zamereni.X = velikost / 2;
                zamereni.Y = zamereni.X;
            }
            Console.Clear();
            Vypsat(hrac, PC, lod_hrac, lod_PC);
            ConsoleKeyInfo temp;
            while (true)
            {
                temp = Console.ReadKey(true);
                if (temp.Key == ConsoleKey.UpArrow)
                {
                    if (zamereni.X >= 2)
                    {
                        zamereni.X--;
                        Console.Clear();
                        Vypsat(hrac, PC, lod_hrac, lod_PC);
                    } 
                }
                if (temp.Key == ConsoleKey.DownArrow)
                {
                    if (zamereni.X < velikost - 2)
                    {
                        zamereni.X++;
                        Console.Clear();
                        Vypsat(hrac, PC, lod_hrac, lod_PC);
                    }
                }
                if (temp.Key == ConsoleKey.LeftArrow)
                {
                    if (zamereni.Y >= 2)
                    {
                        zamereni.Y--;
                        Console.Clear();
                        Vypsat(hrac, PC, lod_hrac, lod_PC);
                    }
                }
                if (temp.Key == ConsoleKey.RightArrow)
                {
                    if (zamereni.Y < velikost - 2)
                    {
                        zamereni.Y++;
                        Console.Clear();
                        Vypsat(hrac, PC, lod_hrac, lod_PC);
                    }
                }
                if (temp.Key == ConsoleKey.Enter)
                {
                    if (PC[zamereni.X, zamereni.Y] == "  ")
                    {
                        if (strelbaXY(zamereni.X, zamereni.Y, lod_PC) == true)
                        {
                            trefilLod(lod_PC, zamereni.X, zamereni.Y);
                            ZkontrolujLode(lod_hrac, lod_PC);
                            PC[zamereni.X, zamereni.Y] = " Z";
                            status = "ZÁSAH";
                        }
                        else
                        {
                            PC[zamereni.X, zamereni.Y] = " V";
                            status = "MINUL";
                        }
                        strelbaPC(hrac, lod_hrac, lod_PC);
                    }
                    break;
                }
            }
        }
        static void strelbaPC(string[,] hrac, lod[] lod_hrac, lod[] lod_PC)
        {
            int velikost = hrac.GetLength(0);
            Random random = new Random();
            int X = 0, Y = 0;
            if (posledni.X != -1 && posledni.Y != -1)
            {
                try
                {
                    int smer = random.Next(8);
                    while (hrac[X, Y] != "  ")
                    {
                        if (hrac[posledni.X + 1, posledni.Y] != "  " && hrac[posledni.X - 1, posledni.Y] != "  " && hrac[posledni.X, posledni.Y + 1] != "  " && hrac[posledni.X, posledni.Y - 1] != "  " && hrac[posledni.X - 1, posledni.Y + 1] != "  " && hrac[posledni.X - 1, posledni.Y - 1] != "  " && hrac[posledni.X + 1, posledni.Y - 1] != "  " && hrac[posledni.X + 1, posledni.Y + 1] != "  ")
                        {
                            posledni.X = -1; posledni.Y = -1; break;
                        }
                        if (smer == 0)
                        {
                            X = posledni.X + 1;
                            Y = posledni.Y;
                        }
                        if (smer == 1)
                        {
                            X = posledni.X - 1;
                            Y = posledni.Y;
                        }
                        if (smer == 2)
                        {
                            X = posledni.X;
                            Y = posledni.Y + 1;
                        }
                        if (smer == 3)
                        {
                            X = posledni.X;
                            Y = posledni.Y - 1;
                        }
                        if (smer == 4)
                        {
                            X = posledni.X + 1;
                            Y = posledni.Y - 1;
                        }
                        if (smer == 5)
                        {
                            X = posledni.X + 1;
                            Y = posledni.Y + 1;
                        }
                        if (smer == 6)
                        {
                            X = posledni.X - 1;
                            Y = posledni.Y - 1;
                        }
                        if (smer == 7)
                        {
                            X = posledni.X - 1;
                            Y = posledni.Y + 1;
                        }
                        smer = random.Next(8);
                    }
                }
                catch (Exception)
                {
                    posledni.X = -1; posledni.Y = -1;
                    strelbaPC(hrac, lod_hrac, lod_PC);
                }
            }
            else
            {
                while (X <= 0 || X == velikost - 1 || Y <= 0 || Y == velikost - 1 || hrac[X, Y] == " Z" || hrac[X, Y] == " V")
                {
                    X = random.Next(velikost);
                    Y = random.Next(velikost);
                }
            }
            if (strelbaXY(X, Y, lod_hrac) == true)
            {
                hrac[X, Y] = " Z";
                posledni.X = X; posledni.Y = Y;
                trefilLod(lod_hrac, X, Y);
                ZkontrolujLode(lod_hrac, lod_PC);
            }
            else
                hrac[X, Y] = " V";
        }
        static bool strelbaXY(int X, int Y, lod[] lod)
        {
            for (int i = 0; i < lod.Length; i++)
            {
                if (lod[i].cast1.X == X && lod[i].cast1.Y == Y) return true;
                if (lod[i].cast2.X == X && lod[i].cast2.Y == Y) return true;
                if (lod[i].cast3.X == X && lod[i].cast3.Y == Y) return true;
                if (lod[i].cast4.X == X && lod[i].cast4.Y == Y) return true;
                if (lod[i].cast5.X == X && lod[i].cast5.Y == Y) return true;
                if (lod[i].cast6.X == X && lod[i].cast6.Y == Y) return true;
                if (lod[i].cast7.X == X && lod[i].cast7.Y == Y) return true;
            }
            return false;
        }
        static void trefilLod(lod[] lod, int X, int Y)
        {
            for (int i = 0; i < lod.Length; i++)
            {
                if (lod[i].cast1.X == X && lod[i].cast1.Y == Y) { lod[i].cast1.X = -1; lod[i].cast1.Y = -1; }
                else if (lod[i].cast2.X == X && lod[i].cast2.Y == Y) { lod[i].cast2.X = -1; lod[i].cast2.Y = -1; }
                else if (lod[i].cast3.X == X && lod[i].cast3.Y == Y) { lod[i].cast3.X = -1; lod[i].cast3.Y = -1; }
                else if (lod[i].cast4.X == X && lod[i].cast4.Y == Y) { lod[i].cast4.X = -1; lod[i].cast4.Y = -1; }
                else if (lod[i].cast5.X == X && lod[i].cast5.Y == Y) { lod[i].cast5.X = -1; lod[i].cast5.Y = -1; }
                else if (lod[i].cast6.X == X && lod[i].cast6.Y == Y) { lod[i].cast6.X = -1; lod[i].cast6.Y = -1; }
                else if (lod[i].cast7.X == X && lod[i].cast7.Y == Y) { lod[i].cast7.X = -1; lod[i].cast7.Y = -1; }
            }
        }
        static void ZkontrolujLode(lod[] lod_hrac, lod[] lod_PC)
        {
            for (int i = 0; i < lod_hrac.Length; i++)
            {
                if (lod_hrac[i].cast1.X == -1 && lod_hrac[i].cast1.Y == -1 && lod_hrac[i].cast2.X == -1 && lod_hrac[i].cast2.Y == -1 && lod_hrac[i].cast3.X == -1 && lod_hrac[i].cast3.Y == -1 && lod_hrac[i].cast4.X == -1 && lod_hrac[i].cast4.Y == -1 && lod_hrac[i].cast5.X == -1 && lod_hrac[i].cast5.Y == -1 && lod_hrac[i].cast6.X == -1 && lod_hrac[i].cast6.Y == -1 && lod_hrac[i].cast7.X == -1 && lod_hrac[i].cast7.Y == -1 && lod_hrac[i].potopena == false)
                {
                    PCScore++;
                    if(PCScore != 0) posledni.X = -1; posledni.Y = -1;
                    lod_hrac[i].potopena = true;
                    if (PCScore == 10)
                        KonecHry();
                    break;
                }
            }
            for (int i = 0; i < lod_PC.Length; i++)
            {
                if (lod_PC[i].potopena == false && lod_PC[i].cast1.X == -1 && lod_PC[i].cast1.Y == -1 && lod_PC[i].cast2.X == -1 && lod_PC[i].cast2.Y == -1 && lod_PC[i].cast3.X == -1 && lod_PC[i].cast3.Y == -1 && lod_PC[i].cast4.X == -1 && lod_PC[i].cast4.Y == -1 && lod_PC[i].cast5.X == -1 && lod_PC[i].cast5.Y == -1 && lod_PC[i].cast6.X == -1 && lod_PC[i].cast6.Y == -1 && lod_PC[i].cast7.X == -1 && lod_PC[i].cast7.Y == -1)
                {
                    HracScore++;
                    lod_PC[i].potopena = true;
                    status = "POTOPIL";
                    if (HracScore == 10)
                        KonecHry();
                    break;
                }
            }
        }
        static void KonecHry()
        {
            if (PCScore > HracScore) status = "VYHRÁVÁ Počítač";
            else status = "VYHRÁVÁ Hráč";
            try
            {
                try
                { // ověří pokud soubor existuje tím, že se z něj pokusí číst
                    StreamReader log = new StreamReader(@"C:\LODE.txt");
                    string obsah = log.ReadToEnd();
                    log.Close();
                    // zapíše do logu
                    StreamWriter logW = new StreamWriter(@"C:\LODE.txt");
                    logW.Write(obsah + "\n HRAC: {0} \t\tPC: {1}", HracScore, PCScore);
                    log.Close();
                }
                catch (Exception)
                { // vytvoří nový soubor a zapíše
                    FileStream fileStream = new FileStream(@"C:\LODE.txt", FileMode.CreateNew);
                    StreamWriter logW = new StreamWriter(@"C:\LODE.txt");
                    logW.Write("\n HRAC: {0} \t\tPC: {1}", HracScore, PCScore);
                    logW.Close();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Přístup k souboru byl odepřen");
            }
        }
        static void Main(string[] args)
        {
            int V = 0;
            // kontrola vstupu
            do
            {
                try
                {
                    Console.Write("Zadejte velikost hrací plochy (15-26): ");
                    V = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Zadejte prosím číslo v rozmezí 15-26");
                }
            } while (V < 15 || V > 26);
            lod[] lod_hrac = new lod[10];
            lod[] lod_PC = new lod[10];
            Console.BufferHeight = V * 6;
            Console.BufferWidth = V * 6;
            zamereni.X = -1; zamereni.Y = -1;
            posledni.X = -1; posledni.Y = -1;
            PosledniVystrel.X = -1; PosledniVystrel.Y = -1;
            zamereni.X = -1; zamereni.Y = zamereni.X;
            string[,] hrac = new string[V, V];
            string[,] PC = new string[V, V];
            while (true)
            {
                Console.Clear();
                Novy(hrac, PC, lod_hrac, lod_PC);
                GEN(lod_PC, PC);
                UMISTI(lod_hrac, hrac, PC, lod_PC);
                Vypsat(hrac, PC, lod_hrac, lod_PC);
                while (HracScore < 10 && PCScore < 10)
                {
                    strileni(hrac, PC, lod_hrac, lod_PC);
                }
                Console.ReadLine();
            }
        }
    }
}
