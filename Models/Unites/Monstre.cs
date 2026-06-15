using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Models.Unites
{
    public abstract class Monstre : Personnage
    {
        // Propriété qui permet de savoir si le monstre possede du butin
        public bool HasLoot
        {
            get { return Butin.Any(); }
        }
        // public bool HasLoot => Butin.Any();


        // Constructeur qui initialise le butin des monstres
        public Monstre()
        {
            _InternalButin = new();
        }


        // Gestion du butin
        // - (Privé) Dico avec les méthodes de mutations (Add, Remove, ...)
        private Dictionary<string, int> _InternalButin { get; set; }

        // - (Public) Acces au donnée du dico en lecture
        public ReadOnlyDictionary<string, int> Butin
        {
            get { return _InternalButin.AsReadOnly(); }
        }

        // - (Public) Méthode pour supprimé une valeur de butin et elle renvoi la quantité de celui-ci
        public int SupprimerButin(string nomDuButin)
        {
            if(_InternalButin.ContainsKey(nomDuButin))
            {
                // Récupere la valeur du butin pour cette clef
                int quantite = _InternalButin[nomDuButin];

                // Suppression de la ligne du butin
                _InternalButin.Remove(nomDuButin);

                // Renvoi la quantité de butin
                return quantite;
            }

            return 0;
        }

        // - (Protected) 
        protected void AjouterButin(string nomDuButin, int quantite)
        {
            // Test de garde pour eviter d'avoir 0 d'un butin
            if(quantite <=0) return;

            if(_InternalButin.ContainsKey(nomDuButin))
            {
                // Modifie la valeur si la clef est présente
                _InternalButin[nomDuButin] += quantite;
            }
            else
            {
                // Ajoute une nouvelle clef avec la valeur
                _InternalButin.Add(nomDuButin, quantite);
            }
        }

        protected void DiminuerButin(string nomDuButin, int quantite)
        {
            if(quantite <=0) return;

            if (this.Butin[nomDuButin] > 1)
            {
                this._InternalButin[nomDuButin]--;
            }
            else
            {
                this.SupprimerButin(nomDuButin);
            }
        }  


        // Méthode abstraite pour obtenir le text d'introduction
        public abstract string ObtenirTexteIntro();

    }
}
