using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace ConsoleApplication1
{
    class Uzel
    {
        string znak;
        int cetnost;
        string kod;
        Uzel Rodic;
        Uzel Levy;
        Uzel Pravy;
        public Uzel(string znak, int cetnost, string kod, Uzel Rodic, Uzel Levy, Uzel Pravy)
        {
            this.znak = znak;
            this.cetnost = cetnost;
            this.kod = kod;
            this.Rodic = Rodic;
            this.Levy = Levy;
            this.Pravy = Pravy;
        }
        public string GetZnak()
        {
            return string.Format(znak);
        }
        public int GetCetnost()
        {
            return cetnost;
        }
        public string GetKod()
        {
            return string.Format(kod);
        }
        public void SetKod(string kod)
        {
            this.kod = kod;
        }
        public void IncrCetnost()
        {
            this.cetnost++;
        }
    }
    class Program
    {
        static int ObrHod(ArrayList V, int I)
        {
            Uzel pom;
            pom = V[I] as Uzel;
            return pom.GetCetnost();
        }
        static void QSserad(ArrayList A, int zac, int kon)
        {
            if (zac < kon)
            {
                int P = zac; Uzel pom;
                for (int i = zac + 1; i <= kon; i++)
                {
                    if (ObrHod(A, i) < ObrHod(A, zac))
                    {
                        P++;
                        pom = A[P] as Uzel;
                        A[P] = A[i];
                        A[i] = pom;
                    }
                }
                pom = A[zac] as Uzel;
                A[zac] = A[P];
                A[P] = pom;

                for (int i = zac; i <= kon; i++)
                    Console.Write(ObrHod(A, i) + ", ");

                Console.WriteLine();
                QSserad(A, zac, P - 1);
                QSserad(A, P + 1, kon);
            }
        }
        static void Main(string[] args)
        {
            Console.Write("Zadej řetězec: ");
            string retezec = Console.ReadLine();
            ArrayList uzly = new ArrayList();
            ArrayList spoje = new ArrayList();
            for (int i = 0; i < retezec.Length; i++)
            {
                bool zmen = false;
                for (int j = 0; j < uzly.Count; j++)
                {
                    if (((Uzel)uzly[j]).GetZnak() == retezec[i].ToString())
                    {
                        ((Uzel)uzly[j]).IncrCetnost();
                        zmen = true;
                        Console.WriteLine("Cetnost {0} prenastavena na {1}.", ((Uzel)uzly[j]).GetZnak(), ((Uzel)uzly[j]).GetCetnost()); break;
                    }
                }
                if (zmen == false)
                {
                    uzly.Add(new Uzel(retezec[i].ToString(), 1, null, null, null, null));
                    Console.WriteLine("Pridan znak {0}.", retezec[i]);
                }
            }
            QSserad(uzly, 0, uzly.Count - 1);
            foreach (Uzel x in uzly)
            {
                Console.WriteLine("{0} - {1}", x.GetZnak(), x.GetCetnost());
            }
            for (int j = 1; j < uzly.Count; j+=2)
            {
                spoje.Add(new Uzel(((Uzel)uzly[j]).GetZnak() + ((Uzel)uzly[j - 1]).GetZnak(), ((Uzel)uzly[j]).GetCetnost() + ((Uzel)uzly[j - 1]).GetCetnost(), null, null, ((Uzel)uzly[j]), ((Uzel)uzly[j-1])));
            }
            foreach (Uzel x in spoje)
            {
                Console.WriteLine("{0} - {1}", x.GetZnak(), x.GetCetnost());
            }

            Console.ReadLine();
        }
    }
}
