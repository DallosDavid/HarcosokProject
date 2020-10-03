using System;
using System.Collections.Generic;
using System.Text;

namespace HarcosProject
{
    class Harcos
    {
       public string nev;
        public int szint;
        public int tapasztalat;
        public int eltero;
        public int alapeletero;
        public int alapsebzes;

        public Harcos(string nev, int statuszSablon)
        {
            this.nev = nev;
            this.szint = 1;
            this.tapasztalat = 0;
            if (statuszSablon == 1)
            {
                alapeletero = 15;
                alapsebzes = 3;
            }
            else if (statuszSablon == 2)
            {
                alapeletero = 12;
                alapsebzes = 4;

            }
            else if (statuszSablon == 3)
            {

                alapeletero = 18;
                alapsebzes = 4;
            }
            else if (statuszSablon == 0)
            {
                alapeletero = 0;
                alapeletero = 0;
            }
            else {
                Console.WriteLine("Kérem csak 1-3 adjon meg szamot.");
            }
            eltero = MaxEletero;

        }

        public string Nev { get => nev; set => nev = value; }
        public int Szint { get => szint; set => szint = value; }
        public int Tapasztalat
        {
            get => tapasztalat; set
            {

                if (tapasztalat == szint)
                {
                    szint += 1;
                    tapasztalat = 0;
                    eltero = MaxEletero;
                }

            }
        }
        public int Eltero
        {
            get => eltero; set
            {
                if (eltero == 0)
                {
                    tapasztalat = 0;
                }
                if (eltero == MaxEletero)
                {
                    eltero = MaxEletero;
                }

            }
        }
        public int Alapeletero { get => alapeletero; }
        public int Alapsebzes { get => alapsebzes; }

        public int Sebzes
        {
            get => alapsebzes + szint;
        }

        public int SzintLEpeshez
        {
            get => 10 + szint * 5;
        }

        public int MaxEletero
        {
            get => alapeletero + szint * 3;

        }


        public void Megkuzd(Harcos masikHaros)
        {
            bool l = true;
            if (masikHaros == this)
            {
                Console.WriteLine("Saját magát nem tudja sebezni .");
                l = false;
            }
            if (masikHaros.eltero <= 0)
            {
                Console.WriteLine("Hiba!\nA támadod ellenfel halot igy nem tudja meg tamadni ujra.");
               masikHaros.tapasztalat = 0;
                l = false;
            }
            if ( this.eltero <= 0)
            {
                Console.WriteLine("Meg haltál.");
                this.eltero = MaxEletero;
                tapasztalat = 0;
            }
            if (l == true)
            {

                masikHaros.eltero -= this.Sebzes;
                if (masikHaros.eltero > 0)
                {
                    this.eltero -= masikHaros.Sebzes;
                }
                if (this.eltero > 0)
                {
                    tapasztalat += 5;

                }
                if (masikHaros.eltero > 0)
                {
                    masikHaros.tapasztalat += 5;
                }
                if (this.eltero < masikHaros.Sebzes)
                {
                    masikHaros.tapasztalat += 10;

                }
                else if (masikHaros.eltero < this.Sebzes)
                {
                    this.tapasztalat += 10;
                }

            }

        }


        public void Gyogyulas()
        {
            Console.WriteLine("Gyogyitotal.");
            int elle = this.eltero +=3 + szint;
            Console.WriteLine(elle);
            if (this.eltero == 0)
            {
                this.eltero = MaxEletero;
            }
            else if (elle > this.eltero)
            {
                Console.WriteLine("PLus hp nem adhatsz magadnak.");
            }
            else {
                this.Eltero += 3 + szint;
            }

        }


        public override string ToString ()
        {
            return string.Format("{0}--LVL:{1}--EXP:{2}/{3}--HP{4}/{5}--DMG:{6}",
                                this.nev, szint, tapasztalat, SzintLEpeshez, eltero, MaxEletero, Sebzes);
        }



    }
}
