using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Unites.Monstres
{
    public class Ours : Monstre
    {
        public override int Force => base.Force + 2;

        public Ours()
        {
            this.AjouterButin("Peau", De3.Lancer());
            this.AjouterButin("Griffes", De4.Lancer() + 1);
            this.AjouterButin("Viande", De6.Lancer());
        }
    }
}
