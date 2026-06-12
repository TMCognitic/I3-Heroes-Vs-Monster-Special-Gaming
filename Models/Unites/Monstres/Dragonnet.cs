using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Unites.Monstres
{
    public class Dragonnet : Monstre
    {
        public override int Endurance => base.Endurance + 5;
        public override int Force => base.Force + 1;

        public Dragonnet()
        {
            this.AjouterButin("Peau", De3.Lancer());
            this.AjouterButin("Or", De100.Lancer());

            if(De6.Lancer() >= 5)
            {
                this.AjouterButin("Ailes", 2);
            }
        }
    }
}
