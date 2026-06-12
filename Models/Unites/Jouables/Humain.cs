
namespace Models.Unites.Jouables
{
    public class Humain : Heros
    {
        // override signifie qu'on redéfinit (on écrit par dessus) la proprité déjà présente dans une classe Parent
        public override int Force 
        { 
            get
            {
                // Le mot clef "base" permet d'aller chercher une propriété/méthode présente dans un parent
                return base.Force + 1;
            }
        }
        // 👇🏻 Équivalent en écriture raccourcie de ce qu'on a fait au dessus 👆🏻
        public override int Endurance => base.Endurance + 1;


        public Humain(string nom) : base(nom) { }
    }
}
