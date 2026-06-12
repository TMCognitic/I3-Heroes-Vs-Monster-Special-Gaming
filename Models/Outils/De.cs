using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Outils
{
    internal class De
    {
        // Le mot clef "init" permet uniquement d'acceder en ecriture lors de l'initialisation de l'objet
        public int Maximum { get; init; }

        public int Lancer()
        {
            //Pour lancer un dé : retourne une valeur comprise entre 1 et max inclus
            return Random.Shared.Next(this.Maximum) + 1;
            // le mot clé "this" représente l'instance de la classe
            // il n'est pas obligatoire pour utiliser les attributs ou méthodes de cette classs
        }

        public De(int maximum)
        {
            // Le constructeur de la classe Dé qui prend le nombre de face de celui-ci
            this.Maximum = maximum;
        }
    }
}
