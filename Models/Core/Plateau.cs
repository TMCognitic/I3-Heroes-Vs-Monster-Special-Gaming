using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Core
{
    public class Plateau
    {
       
        //Transformation de la const TAILLE en prop Taille
        public int Taille { get; private set; }


        /* RAPEL TABLEAU */
        //private int[] tabUneDimension = new int[TAILLE];
        // [0,0,0,0,0,0...]

        // Matrice
        /*  x:0 x:1 x:2
         [  ['0;0', '0;1', '0;2'], y: 0
            ['1;0', '1;1', '1;2'], y: 1
            ['2;0', '2;1', '2;2'] ]y: 2
        
        mat[y, x]
         */
        private string[,] _Grille; 

        // Ajout d'un constructeur où on initialise la taille du plateau avec donnée reçue lors de la construction et initialisation de la grille avec la taille
        public Plateau(int taille)
        {
            Taille = taille;
            _Grille = new string[Taille, Taille];
        }
        public string this[int y, int x]
        {
            get
            {
                if(x < 0 || y < 0 || x > Taille || y > Taille)
                {
                    // todo error
                }

                return _Grille[y, x];
            }

            set
            {
                if (x < 0 || y < 0 || x > Taille || y > Taille)
                {
                    // todo error
                }

                _Grille[y, x] = value;
            }
        }
    }
}
