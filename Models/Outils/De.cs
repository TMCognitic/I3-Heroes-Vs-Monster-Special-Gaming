using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Outils
{
    internal class De
    {
        public int Maximum {  get; set; }

        public int Lancer()
        {
            //Pour lancer un dé : retourne une valeur comprise entre 1 et max inclut
            return Random.Shared.Next(this.Maximum) + 1;
            // le mot clé "this" représente l'instance de la class
            // il n'est pas obligatoire pour utiliser les attributs ou méthode de cette class
        }
    }
}
