using Models.Outils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Unites.Monstres
{
    public class Bandit : Monstre
    {
        public override int Force => base.Force + 3;

        public override int Endurance {
            get
            {
                int tempEndurance = base.Endurance - 2;
                return (tempEndurance > 1) ? tempEndurance : 1; 
            }
        }

        public override void SubitDegats(int degats)
        {
            base.SubitDegats(degats); //on déclenche la méthode du parent pour que les dégats s'appliquent

            if(PointDeVie < 5)
            {
                Console.WriteLine("🧪 Le bandit tente de prendre une potion...");
                De De100 = new(100);

                if(De100.Lancer() == 11)
                {
                    Console.WriteLine("... et récupère 5 PV");
                    PointDeVie += 5;

                }
                else
                {
                    Console.WriteLine("... et la fait tomber au sol.");
                }
            }
        }
    }
}
