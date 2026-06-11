using Models.Outils;
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


    public class Personnage
    {
        // Virtual sert à indiquer que cette propriété peut être réécrite dans les classes enfant
        public virtual int Force { get; private set; } = 10;
        public virtual int Endurance { get; private set; } = 10;
        public int PointDeVie { get; protected set; } = 20;

        public bool EstEnVie
        {
            get
            {
                return PointDeVie > 0;
            }
        }

        public void Frappe(Personnage cible)
        {
            // lancer un dé à 4 faces (1 à 4) et retirer les PVs
            De de = new De();
            de.Maximum = 4;

            // Les dégats sont égal au lancer + le bonus basé sur la force de celui qui tape
            int degats = de.Lancer() + CalculBonus(Force);

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
