using HarcosProject;
using System;
using System.Collections.Generic;
using System.IO;

namespace HarcosokProject
{
    class Program
    {
        public static Random r =new Random();
        public static Harcos s;
        public static List<Harcos> Harcosok = new List<Harcos>();
        public static void Fajjlbe()
        {
            try
            {
                StreamReader r = new StreamReader("harcosok.csv");
                string sor;
                while ((sor = r.ReadLine()) != null)
                {
                    string[] sorok = sor.Split(';');
                    Harcosok.Add(new Harcos(sorok[0], int.Parse(sorok[1])));

                }
                r.Close();
            }
            catch (IOException e) { Console.WriteLine(e); }


        }
        public static void Kor()
        {
            for (int i = 0; i < Harcosok.Count; i++)
            {              
                Console.WriteLine((i + 1) + "." + Harcosok[i]);
                if (Harcosok[i].Tapasztalat>=Harcosok[i].SzintLEpeshez )
                {
                    Harcosok[i].szint += 1;
                    Harcosok[i].tapasztalat = 0;
                    Harcosok[i].eltero = Harcosok[i].MaxEletero;
                }
            }
        }

        public static bool Meghalt(Harcos a) 
        {
            bool l = false;
          
                if (a.Eltero==0)
                {
                    l = true;
                }          
            return l;
        }

        public static void Harcok()
        {
           
            char a;
            int szamol = 0;

            do
            {
                int hszam;
                Kor();
                Console.WriteLine();
                Console.WriteLine("MIt szeretne csinálni a Harcorsával: \n a.) Megküzdeni egy harcossal\n" +
                   " b.) Gyógyulni\n" +
                   " c.) Kilépn");
                a = Convert.ToChar(Console.ReadLine());
                if (a == 'a')
                {

                    Console.WriteLine();
                    do
                    {
                        Console.WriteLine("Melyik harcosal akkarsz meg kuzedeni?");
                        hszam = int.Parse(Console.ReadLine());
                        if (hszam <= 0 || hszam > Harcosok.Count)
                        {
                            Console.WriteLine("Hiba!\nKérem jó szamit adjojn meg.");
                        }

                    } while (hszam <= 0 || hszam > Harcosok.Count);

                    if (hszam < Harcosok.Count && hszam > 0)
                    {
                        Console.WriteLine("Ezta a Harcost választotad  ellenfelnek:\n{0}", Harcosok[hszam - 1]);
                        s.Megkuzd(Harcosok[hszam - 1]);
                        Console.WriteLine();
                    }
                    szamol++;
                    Console.WriteLine("Kor szama:"+szamol);
                    if (szamol % 3 == 0)
                    {
                        s.Megkuzd(Harcosok[r.Next(1, Harcosok.Count)]);
                        Console.WriteLine("Meg tamadot:{0}", Harcosok[r.Next(1, Harcosok.Count)]);
                        for (int i = 0; i < Harcosok.Count; i++)
                        {
                            Harcosok[i].Gyogyulas();
                        }

                    }

                }
                else if (a == 'b')
                {
                    Console.WriteLine();
                    Console.WriteLine("Gyogyitotál");
                    s.Gyogyulas();
                    Console.WriteLine();

                }
                else if (a == 'c')                   
                {
                    Console.WriteLine("Kileptel.");
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Kérem kisbetuvel adja meg és csak a lehetosogek kotul valaszon.");
                    Console.WriteLine();
                }

            } while (a != 'c');
        }


        static void Main(string[] args)
        {

            Console.WriteLine("Harcosneve");
            string nev = Console.ReadLine();
            Console.WriteLine("Harocs staus");
            int satus = int.Parse(Console.ReadLine());
            s = new Harcos(nev, satus);
            Harcosok.Add(s);
            Fajjlbe();            
            Harcok();

            Console.ReadLine();
        }
    }
}
