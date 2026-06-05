using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Unites.Monstres
{
    public class Dragonnet : Monstre
    {
        public override int Endurance => base.Endurance + 5;
        public override int Force => base.Force + 1;
    }
}
