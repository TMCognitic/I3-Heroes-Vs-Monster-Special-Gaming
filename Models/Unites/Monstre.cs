using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Unites
{
    public class Monstre : Personnage
    {
        public bool HasLoot
        {
            get { return Butin.Any(); }
        }
        // public bool HasLoot => Butin.Any();


        public Dictionary<string, int> Butin = new();
    }
}
