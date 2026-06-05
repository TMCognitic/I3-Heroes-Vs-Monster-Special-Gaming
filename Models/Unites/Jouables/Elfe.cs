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
                // On vérifie si en enlevant 2, on ne descend pas en dessous de 1
                if(base.Force - 2 >= 1)
                {
                    // Si c'est ok, on enlève 2 en endurance
                    return base.Force - 2;
                }
                // Sinon, on va vérifier si en enlevant un, on ne descend pas en dessous de 1
                else if(base.Force - 1 >= 1)
                {
                    return base.Force - 1;
                }
                // Sinon, il n'a que 1 en Force, il est déjà assez nul comme ça
                else
                {
                    return base.Force;
                }
            }
        }
    }
}
