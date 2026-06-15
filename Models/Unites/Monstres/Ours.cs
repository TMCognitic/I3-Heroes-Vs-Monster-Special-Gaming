using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Unites.Monstres
{
    public class Ours : Monstre
    {
        public override int Force => base.Force + 2;

        public override string NomAfficher
        {
            get { return "Un gigantesque ours"; }
        }

        public Ours()
        {
            this.AjouterButin("Peau", De3.Lancer());
            this.AjouterButin("Griffes", De4.Lancer() + 1);
            this.AjouterButin("Viande", De6.Lancer());
        }

        

        public override string ObtenirTexteIntro()
        {
            return "Un grondement titanesque résonne tandis que l’ours domine l’arène";
        }
    }
}
