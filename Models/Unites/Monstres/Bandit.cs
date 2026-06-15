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

        public Bandit()
        {
            this.AjouterButin("Or", De100.Lancer());
            this.AjouterButin("Repas", De3.Lancer());
            this.AjouterButin("Viande", De6.Lancer());

            if(De100.Lancer() <= 50)
            {
                // Le bandit a loot un loup
                this.AjouterButin("Peau", De3.Lancer());
                this.AjouterButin("Crocs", De3.Lancer() - 1);
            }

            if (De100.Lancer() <= 25)
            {
                // Le bandit a loot un ours
                this.AjouterButin("Peau", De3.Lancer());
                this.AjouterButin("Griffes", De4.Lancer() + 1);
            }

            if (De100.Lancer() <= 5)
            {
                // Le bandit a loot un dragonnet
                this.AjouterButin("Ailes", 2);
            }
        }

        public override void SubitDegats(int degats)
        {
            base.SubitDegats(degats); //on déclenche la méthode du parent pour que les dégats s'appliquent

            if(PointDeVie < 5)
            {
                Console.WriteLine("🧪 Le bandit tente de prendre une potion...");
                De De100 = new(100);

                if(De100.Lancer() >= 33)
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
