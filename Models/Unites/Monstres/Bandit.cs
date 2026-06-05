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
                if (base.Endurance - 2 >= 1)
                {
                    return base.Endurance - 2;
                }
                else if (base.Endurance - 1 >= 1)
                {
                    return base.Endurance - 1;
                }
                else
                {
                    return base.Endurance;
                }
            }
        }

        public override void SubitDegats(int degats)
        {
            base.SubitDegats(degats); //on déclenche la méthode du parent pour que les dégats s'appliquent

            if(PointDeVie < 5)
            {
                Console.WriteLine("🧪 Le bandit tente de prendre une potion...");
                De De100 = new();
                De100.Maximum = 100;

                if(De100.Lancer() == 50)
                {
                    Console.WriteLine("... et récupère 10 PV");
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
