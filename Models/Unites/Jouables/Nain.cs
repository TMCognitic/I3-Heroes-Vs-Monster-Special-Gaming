using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Unites.Jouables
{
    public class Nain : Heros
    {
        public override int Endurance => base.Endurance + 2;

        public Nain(string nom) : base(nom) 
        {
            Symbol = 'N';
        }
    }
}
