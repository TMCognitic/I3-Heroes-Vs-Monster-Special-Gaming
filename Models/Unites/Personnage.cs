using Models.Interfaces;
using Models.Outils;
using Models.Unites.Monstres;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Unites
{
    /*
     * public -> tout le monde peut y accéder
     * internal -> dans le même projet
     * protected -> uniquement la classe (ou ses enfants cf. héritage)
     * privated -> uniquement la classe
     */


    public abstract class Personnage : IPositionnable
    {
        // Virtual sert à indiquer que cette propriété peut être réécrite dans les classes enfant
        public virtual int Force { get; private set; }
        public virtual int Endurance { get; private set; }

        // TODO : Refactoring → Limiter la valeur des pdv à la valeur max.
        public int PointDeVie { get; protected set; }

        // Point de vie maximum calculé dynamiquement (Minimum 6)
        public int PointDeVieMax => Math.Max((Endurance * 2) - 5, 6);

        // Proprieté calculer sur base de PointDeVie
        public bool EstEnVie
        {
            get
            {
                return PointDeVie > 0;
            }
        }

        // Propriété abstraite
        public abstract string NomAfficher { get; }


        // Set de dé du personnage
        // - Le « private protected » permet d'utiliser la classe "De" qui internal dans l'heritage
        private protected De De3 { get; init; }
        private protected De De4 { get; init; }
        private protected De De6 { get; init; }
        private protected De De100 { get; init; }

        public int PositionX { get; protected set; }

        public int PositionY { get; protected set; }

        public char Symbol {  get; protected set; }


        // Constructeur qui initialise les stats
        public Personnage()
        {
            // Comme il n'y pas de conflit de nom de variable, le mot clef "this" est optionnel ;)
            Force = StatsGenerator.GenerateStatistique();
            Endurance = StatsGenerator.GenerateStatistique();

            // Comme "PointDeVieMax" se base endurance, celui-ci doit être initialiser après "Endurance"
            PointDeVie = PointDeVieMax;

            // Initialisation des dés
            De3 = new De(3);
            De4 = new De(4);
            De6 = new De(6);
            De100 = new De(100);
        }


        public void Frappe(Personnage cible)
        {
            // Les dégats sont égal au lancer + le bonus basé sur la force de celui qui tape
            int degats = De4.Lancer() + CalculBonus(Force);

            cible.SubitDegats(degats);
        }

        public virtual void SubitDegats(int degats)
        {
            int bonus = CalculBonus(Endurance);
            // On vérifie si les dégats sont positifs et si les dégats - le bonus sont positifs pour ne pas rajouter des PV à notre personnage
            if (degats >= 0 && degats - bonus >= 0)
            {
                // Le personnage qui reçoit des dégats, recevra les dégats - le bonus en endurance
                PointDeVie -= degats - bonus;
            }

            // TODO error
        }



        protected int CalculBonus(int stat)
        {
            if(stat < 10)
            {
                return -1;
            }
            else if(stat == 10)
            {
                return 0;
            }
            else if(stat > 10 && stat < 13)
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }
    }
}
