using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Unites.Monstres
{
    public class Loup : Monstre
    {

        public Loup()
        {
            this.AjouterButin("Peau", De3.Lancer());
            this.AjouterButin("Crocs", De3.Lancer() - 1);
            this.AjouterButin("Viande", De6.Lancer());
        }
    }
}
