using System;
using System.Collections.Generic;
using System.Text;

namespace HarcosProject
{
    class Harcos
    {
        string nev;
        int szint;
        int tapasztalat;
        int eltero;
        int alapeletero;
        int alapsebzes;

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
            if (masikHaros.eltero == 0 || this.eltero == 0)
            {
                Console.WriteLine("Hiba");
                l = false;
            }
            if (l == true)
            {
                masikHaros.Eltero -= this.Sebzes;
                if (masikHaros.eltero > this.Sebzes)
                {
                    this.Eltero -= masikHaros.Sebzes;
                }
                if (this.Eltero > 0)
                {
                    Tapasztalat += 5;

                }
                if (masikHaros.eltero > 0)
                {
                    masikHaros.Tapasztalat += 5;
                }
                if (this.Eltero < masikHaros.Sebzes)
                {
                    masikHaros.Tapasztalat += 10;

                }
                else if (masikHaros.Eltero < this.Sebzes)
                {
                    this.Tapasztalat += 10;
                }

            }

        }


        public void Gyogyulas()
        {
            if (this.eltero == 0)
            {
                this.eltero = MaxEletero;
            }
            else
            {
                this.Eltero += 3 + szint;
            }

        }








        public override string ToString()
        {
            return string.Format("{0}--LVL:{1}--EXP:{2}/{3}--HP{4}/{5}--DMG:{6}",
                                this.nev, szint, tapasztalat, SzintLEpeshez, eltero, MaxEletero, Sebzes);
        }



    }
}
