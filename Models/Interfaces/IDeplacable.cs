using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Interfaces
{
    public interface IDeplacable
    {
        public int MaxDeplacement { get; }
        public void SeDeplacer(int tailleMaxPlateau);
    }
}
