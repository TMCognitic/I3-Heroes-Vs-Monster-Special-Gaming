using Models.Outils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Unites.Monstres
{
    public class Bandit : Monstre
    {
        private readonly List<string> _Insultes = [
            "Hé toi, tas de bravoure mal recyclée !",
            "Prépare-toi, héros de pacotille !",
            "Viens donc, légende en carton humide !",
            "Je vais te renvoyer à ton tutoriel, champion !",
            "Regarde-moi ce héros à peine texturé !",
            "Tu pues la quête secondaire ratée !",
            "Approche, avatar sous-cuit !",
            "On dirait que le destin t’a généré au hasard !",
            "Allez, viens, glitch ambulant !",
            "Je vais te plier comme un parchemin mouillé !",
            "T’as la grâce d’un sanglier enrhumé !",
            "On t’a sculpté avec une cuillère, ou quoi ?",
            "Héros ? T’es juste un bug avec une épée !",
            "Je vais te renvoyer à l’écran de chargement !",
            "Regarde-moi ce champion en mousse !",
            "On dirait que t’as raté ton arbre de talents !",
            "T’es aussi menaçant qu’un lapin en chaussons !",
            "Je vais t’écraser comme un dialogue mal écrit !",
            "Ton destin ? Être mon entraînement !",
            "Viens donc, héros discount !",
            "Hé, le héros ! Et toi aussi, derrière l’écran… oui, toi ! Tu crois vraiment que tu vas gagner avec ces stats-là ?",
            "Par ma barbe, tu n’es qu’un écuyer mal repassé !",
            "Chevalier ? On dirait un page perdu dans les latrines !",
            "Je vais te renvoyer au château des incapables !",
            "Ton courage est plus mince qu’un parchemin mouillé !",
            "Tu combats comme un troubadour enrhumé !",
            "Héros ? Tu n’es qu’un souffle de destin raté !",
            "Je sens la magie… et elle se moque de toi !",
            "Ton aura est aussi brillante qu’une chandelle mourante !",
            "Je vais graver ton échec dans les étoiles !",
            "Tu n’es qu’un murmure perdu dans la grande légende !",
            "Ton âme tremble déjà, petite braise vacillante.",
            "Je sens la peur couler en toi comme une encre froide.",
            "Tu n’es qu’un souffle fragile dans la nuit éternelle.",
            "Je vais éteindre ta lumière comme on écrase une cendre.",
            "Ton destin ? Se perdre dans l’ombre que je porte."
        ];

        public override int Force => base.Force + 3;

        public override int Endurance
        {
            get
            {
                int tempEndurance = base.Endurance - 2;
                return (tempEndurance > 1) ? tempEndurance : 1;
            }
        }

        public override string NomAfficher => "Un bandit !";

        public Bandit()
        {
            this.AjouterButin("Or", De100.Lancer());
            this.AjouterButin("Repas", De3.Lancer());
            this.AjouterButin("Viande", De6.Lancer());

            if (De100.Lancer() <= 50)
            {
                // Le bandit a loot un loup
                this.AjouterButin("Peau", De3.Lancer());
                this.AjouterButin("Crocs", De3.Lancer() - 1);
            }

            if (De100.Lancer() <= 25)
            {
                // Le bandit a loot un ours
                this.AjouterButin("Peau", De3.Lancer());
                this.AjouterButin("Griffes", De4.Lancer() + 1);
            }

            if (De100.Lancer() <= 5)
            {
                // Le bandit a loot un dragonnet
                this.AjouterButin("Ailes", 2);
            }
        }

        public override void SubitDegats(int degats)
        {
            base.SubitDegats(degats); //on déclenche la méthode du parent pour que les dégats s'appliquent

            if (PointDeVie < 5)
            {
                Console.WriteLine("🧪 Le bandit tente de prendre une potion...");
                De De100 = new(100);

                if (De100.Lancer() >= 33)
                {
                    Console.WriteLine("... et récupère 5 PV");
                    PointDeVie += 5;

                }
                else
                {
                    Console.WriteLine("... et la fait tomber au sol.");
                }
            }
        }


        public override string ObtenirTexteIntro()
        {
            int indiceInsulte = Random.Shared.Next(_Insultes.Count);
            return _Insultes[indiceInsulte];
        }

    }
}
