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
                if (base.Endurance - 2 >= 1)
                {
                    return base.Endurance - 2;
                }
                else if (base.Endurance - 1 >= 1)
                {
                    return base.Endurance - 1;
                }
                else
                {
                    return base.Endurance;
                }
            }
        }
    }
}
