using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Unites.Monstres
{
    public class Loup : Monstre
    {
        public override string NomAfficher => "Un loup féroce";

        public Loup()
        {
            this.AjouterButin("Peau", De3.Lancer());
            this.AjouterButin("Crocs", De3.Lancer() - 1);
            this.AjouterButin("Viande", De6.Lancer());
        }


        public override string ObtenirTexteIntro()
        {
            return "Un loup surgit de la nuit, ses yeux seuls annonçant la tempête";
        }
    }
}
