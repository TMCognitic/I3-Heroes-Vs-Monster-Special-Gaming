using Models.Outils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Unites
{
    /*
     * public -> tout le monde peut y accèder
     * internal -> dans le même projet
     * protected -> uniquement la classe (ou ses enfants cf. héritage)
     * privated -> uniquement la classe
     */


    public class Personnage
    {
        public string Name { get; set; }
        public int Force { get; private set; } = 10;
        public int Endurance { get; private set; } = 10;
        public int PointDeVie { get; private set; } = 20;

        public bool EstEnVie
        {
            get
            {
                return PointDeVie > 0;
            }
        }

        public void Frappe(Personnage cible)
        {
            // lancer un dé à 4 faces (1 à 4) et retirer les PVs
            De de = new De();
            de.Maximum = 4;

            int degats = de.Lancer();
            cible.PointDeVie -= degats;
        }

        public void SubitDegats(int degats)
        {
            if (degats >= 0)
            {
                PointDeVie -= degats;
            }

            // TODO error
        }
    }
}
