using HarcosProject;
using System;
using System.Collections.Generic;
using System.IO;

namespace HarcosokProject
{
    class Program
    {
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
            }
        }

        public static void Harcok()
        {
            char a;
            do
            {
                int hszam;
               
                Console.WriteLine("MIt szeretne csinálni a Harcorsával: \n a.) Megküzdeni egy harcossal\n" +
                   " b.) Gyógyulni\n" +
                   " c.) Kilépn");
                a = Convert.ToChar(Console.ReadLine());

                if (a == 'a')
                {
                    do
                    {
                        Console.WriteLine("Melyik harcosal akkar meg kuzedeni?");
                        hszam = int.Parse(Console.ReadLine());
                        if (hszam <= 0 || hszam > Harcosok.Count)
                        {
                            Console.WriteLine("Hiba!\nKérem jó szamit adjojn meg.");
                        }

                    } while (hszam<=0 || hszam>Harcosok.Count);

                    if (hszam<Harcosok.Count &&hszam>0)
                    {
                        Console.WriteLine("Ezta a Harcost választotad  ellenfelnek:\n{0}",Harcosok[hszam-1]);
                        s.Megkuzd(Harcosok[hszam-1]);
                        Console.WriteLine();
                        foreach (Harcos h in Harcosok)
                        {
                            Console.WriteLine(h);
                        }
                    }


                }


            } while (a != 'c');
        }


        static void Main(string[] args)
        {

            Console.WriteLine("HArcosneve");
            string nev = Console.ReadLine();
            Console.WriteLine("gharocs staus");
            int satus = int.Parse(Console.ReadLine());
            s = new Harcos(nev, satus);
            Harcosok.Add(s);
            Fajjlbe();
            Kor();
            Harcok();

            Console.ReadLine();
        }
    }
}
