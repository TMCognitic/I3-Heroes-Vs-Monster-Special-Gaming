using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Unites.Monstres
{
    public class Dragonnet : Monstre
    {
        public override int Endurance => base.Endurance;
        public override int Force => base.Force - 3;
        public int Armure { get; private set; }

        public override string NomAfficher => "Un dragonnet tout mignon 🐲";

        public Dragonnet()
        {
            this.Armure = 5;
            this.AjouterButin("Peau", De3.Lancer());
            this.AjouterButin("Or", De100.Lancer());

            if(De6.Lancer() >= 5)
            {
                this.AjouterButin("Ailes", 2);
            }
        }

        public override void SubitDegats(int degats)
        {
            int degatsReel = degats;
            if(Armure > 0) 
            {
                int degatEviter = Math.Min(Armure, degats);
                degatsReel = degats - degatEviter;
                Armure = Armure - degatEviter;
            }

            base.SubitDegats(degatsReel);
        }

        public override string ObtenirTexteIntro()
        {
            return "Le dragonnet glisse sur sa propre queue et rugit… en couinant";
        }
    }
}
