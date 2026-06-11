using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Unites.Jouables
{
    public class Elfe : Heros
    {
        public override int Endurance => base.Endurance + 3;
        public override int Force
        {
            get
            {
                int tempForce = base.Force - 2;

                if (tempForce > 1)
                {
                    return tempForce;
                }
                else
                {
                    return 1;
                }

                // Ecriture alternative avec un ternaire
                return (tempForce > 1) ? tempForce : 1;
                return Math.Max(tempForce, 1);
            }
        }
    }
}
