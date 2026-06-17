using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Unites.Monstres
{
    public class Ours : Monstre, IDeplacable
    {
        public override int Force => base.Force + 2;

        public override string NomAfficher
        {
            get { return "Un gigantesque ours"; }
        }

        public int MaxDeplacement => 1;

        public Ours(int taille) : base(taille)
        {
            Symbol = 'O';

            this.AjouterButin("Peau", De3.Lancer());
            this.AjouterButin("Griffes", De4.Lancer() + 1);
            this.AjouterButin("Viande", De6.Lancer());
        }

        

        public override string ObtenirTexteIntro()
        {
            return "Un grondement titanesque résonne tandis que l’ours domine l’arène";
        }

        public void SeDeplacer(int tailleMaxPlateau)
        {
            int deplacementX = Random.Shared.Next(-MaxDeplacement, MaxDeplacement + 1);
            int deplacementY = Random.Shared.Next(-MaxDeplacement, MaxDeplacement + 1);

            // Si avec le déplacement (s'il est négatif) on arrive en dessous de 0)
            if (PositionX + deplacementX < 0)
            {
                // On enlève que ce qui est possible d'enlever
                PositionX -= deplacementX + PositionX;
            }
            // Sinon si avec le déplacement (positif) on arrive à la taille max du plateau
            else if (PositionX + deplacementX > tailleMaxPlateau - 1)
            {
                // On ajoute que ce qui est possible d'ajouter
                PositionX += tailleMaxPlateau - PositionX;
            }
            else
            {
                // Sinon c'est bon, on peut ajouter/enlever ce qu'on veut
                PositionX += deplacementX;
            }

            // Même logique d'au dessus mais pour les Y
            if (PositionY + deplacementY < 0)
            {
                PositionY -= deplacementY + PositionY;
            }
            else if (PositionY + deplacementY > tailleMaxPlateau - 1)
            {
                PositionY += (tailleMaxPlateau - 1) - PositionY;
            }
            else
            {
                PositionY += deplacementY;
            }


        }
    }
}
