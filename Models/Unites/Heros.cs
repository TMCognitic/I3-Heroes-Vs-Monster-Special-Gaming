

using Models.Interfaces;

namespace Models.Unites
{
    public abstract class Heros : Personnage, IDeplacable
    {
        // On va déplacer Name qui était dans Personnage dans Heros : il n'y a que nos héros qui auront un petit nom
        public string Nom { get; init; }

        public override string NomAfficher => $"{this.GetType().Name} {Nom}";

        // On va créer un dictionnaire pour les Butins avec comme clef le type de butin et comme valeur 0 pour le héro, puisqu'il commence avec aucun butin
        // - Initialisation avec uniquement les clefs "obligatoire" (or, repas)
        // - Les autres clefs seront ajouter dynamiquement lors du loot
        public Dictionary<string, int> Butin { get; private set; }

        public int MaxDeplacement => 1;


        // Le constructeur "Hero" n'a pas besoin de faire « : base() » pour faire référence au ctor de "Personnage"
        // Car les constructeurs appelent automatique le constructeur parent sans parametre (constructeur par defaut)
        public Heros(string nom)
        {
            this.Nom = nom;
            this.Butin = new()
            {
                { "Or", 0 },
                { "Repas", 3 },
                { "Viande", 0 }
            };

            // On initialise les positions des Hero à 0
            PositionX = 0;
            PositionY = 0;
        }

        public void Loot(Monstre cible)
        {
            // Test de garde
            if (cible.EstEnVie)
            {
                // TODO Erreur : la créature doit être mouru
                return;
            }

            // Rappel : Vous ne pouvez pas modifier la collection dans une boucle "foreach"
            // On parcours les butins
            while (cible.HasLoot)
            {
                // Le butin qu'on récupere
                KeyValuePair<string, int> butin = cible.Butin.First();
                string typeButin = butin.Key;
                int valeurButin = butin.Value;

                // Rappel : le mot clef "this" represente l'instance actuelle
                if (this.Butin.ContainsKey(typeButin))
                {
                    // Si on possede deja le type de butin, on augemente sa valeur
                    this.Butin[typeButin] += valeurButin;
                }
                else
                {
                    // Si on ne l'a pas, on l'ajoute
                    this.Butin.Add(typeButin, valeurButin);
                }

                // Suppression du butin sur la cible
                cible.SupprimerButin(typeButin);
            }
        }

        public void SeReposer()
        {
            // TODO : Peut-être envisager des PV Max au dessus desquels on ne peut pas remonter, ici on va mettre 20 en dur

            Console.WriteLine("🛌🏻 Votre héros se repose...");
            // Si en récupérent 10, je passe au dessus des 20... Bah t'as le max :o
            if (PointDeVie + 10 > PointDeVieMax)
            {
                PointDeVie = PointDeVieMax;
            }
            // Sinon, on peut rajouter 10
            else
            {
                PointDeVie += 10;
            }

        }

        public void Cuisiner()
        {
            // Vérifier s'il possède des viandes à cuisiner
            if (Butin["Viande"] > 0)
            {
                Console.WriteLine("[Insérer musique de Monster Hunter] Vous avez fabriqué 1 x Repas !");
                Butin["Viande"]--; //on retire une viande
                Butin["Repas"]++; //on rajoute un repas
            }
            else
            {
                Console.WriteLine("❌ Vous n'avez pas de viande dans votre inventaire");
            }
        }

        public void Manger()
        {
            // On va vérifier si le héro possède des repas
            if (Butin["Repas"] > 0)
            {
                Console.WriteLine("Votre héro se délecte d'un délicieux repas 🍖");
                Butin["Repas"]--; //on retire le repas qu'il vient de manger

                // TODO Peut être voir pour valeur MaxPV
                // Il regagne le max qu'il peut ou 5 pv
                PointDeVie = Math.Min(PointDeVie + 5, PointDeVieMax);
            }
            else
            {
                Console.WriteLine("Votre héro ne possède pas de repas préparé avec amour... il va devoir manger de la viande crue à ses risques et périls 🥩");
                Butin["Viande"]--; //on enlève une viande de l'inventaire

                // On génère une valeur entre -3 et 3 pour voir s'il s'intoxique avec la viande ou pas
                int recuperation = Random.Shared.Next(-3, 4);
                if (recuperation < 0)
                {
                    Console.WriteLine("Votre héro s'est intoxiqué, vous avez perdu des points de vie 🤢");
                    PointDeVie += recuperation;
                }
                else
                {
                    // On regagne des points de vie limité à notre maximum
                    Console.WriteLine("Votre héro a trouvé se viande exceptionnel 🤩");
                    PointDeVie = Math.Min(PointDeVie + recuperation, PointDeVieMax);
                }
            }
        }

        public void SeDeplacer(int tailleMaxPlateau)
        {
            ConsoleKeyInfo keyPressed = Console.ReadKey();
            switch(keyPressed.Key) 
            {
                case ConsoleKey.UpArrow:
                    if(PositionY > 0)
                    {
                        PositionY-= MaxDeplacement;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if(PositionY < tailleMaxPlateau - 1)
                    {
                        PositionY+= MaxDeplacement;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if(PositionX > 0)
                    {
                        PositionX-=MaxDeplacement;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if(PositionX < tailleMaxPlateau - 1)
                    {
                        PositionX+=MaxDeplacement;
                    }
                    break;

                //TODO rajouter les autres touches pour manger/cuisiner/récupérer etc
        
        }
    }
    }
}
