using Models.Core;
using Models.Unites;
using Models.Unites.Jouables;
using Models.Unites.Monstres;

namespace HeroesVsMonster
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // Fait en sorte que la console sache afficher de l'UTF-8 (pour afficher les émojis et caractères spéciaux)
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            #region TEST PERSONNAGES
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("  [TESTS] Création de personnages 💁🏻‍♀️");
            Console.WriteLine("--------------------------------------");

            Console.WriteLine("\n > Création de Bob");

            Personnage bob = new Personnage();
            //bob.PointDeVie = 20; valeur par défaut dans le personnage + encapsulation pour empécher "set"

            Console.WriteLine("\n > Création de Dave");
            Personnage dave = new();
            //dave.PointDeVie = 20; valeur par défaut dans le personnage + encapsulation pour empécher "set"

            Console.WriteLine("\n > Visualisation points de vie ");
            Console.WriteLine("Bob PV: " + bob.PointDeVie);
            Console.WriteLine("Dave PV: " + dave.PointDeVie);

            Console.WriteLine("\n > Test Combat : Bob Frappe Dave");
            bob.Frappe(dave);
            Console.WriteLine("\n > Visualisation points de vie ");
            Console.WriteLine("Bob pv: " + bob.PointDeVie);
            Console.WriteLine("Dave pv: " + dave.PointDeVie);

            Console.WriteLine("\n > Test Subir dégâts : Dave se prend un arbre");
            Console.WriteLine("Un arbre tombe sur Dave!!!");
            dave.SubitDegats(5);
            dave.SubitDegats(-5); // générera une erreur quand on aura vu les erreurs ;D

            Console.WriteLine("\n > Test pour savoir si un personnage est encore en vie ou pas");
            if (!dave.EstEnVie)
            {
                Console.WriteLine("Dave mort :'( ");
            }
            else
            {
                Console.WriteLine("Dave est encore en vie \\o/");
            }

            #endregion
           
            Console.WriteLine("\n\n Appuyez sur n'importe quelle touche pour voir le test suivant");
            Console.ReadKey();
            Console.Clear();


            #region TEST PLATEAU DE JEU
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("   [TESTS] Plateau 🌳🌲");
            Console.WriteLine("--------------------------------------");

            Plateau monde = new();
            monde[5, 5] = "d";
            monde[0, monde.Taille - 1] = "l";

            // Affichage du monde
            for (int y = 0; y < monde.Taille; y++)
            {
                for (int x = 0; x < monde.Taille; x++)
                {
                    Console.Write((monde[y, x] ?? "_") + '\t');
                }
                Console.Write("\n");
            }
            #endregion

            Console.WriteLine("\n\n Appuyez sur n'importe quelle touche pour voir le test suivant");
            Console.ReadKey();
            Console.Clear();

            #region TEST HEROS ET MONSTRES
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine(" [TEST] Création de héros et de monstres");
            Console.WriteLine("--------------------------------------------");

            Console.WriteLine(" > Création de 3 héros");
            Humain humain = new();
            humain.Nom = "JeanMi";

            Elfe elfe = new();
            elfe.Nom = "Legless Legolas";

            Nain nain = new();
            nain.Nom = "Stoemp";

            Console.WriteLine("1er Héros :");
            Console.WriteLine($"{humain.Nom} l'humain");
            Console.WriteLine($"  Force : {humain.Force}");
            Console.WriteLine($"  Endurance : {humain.Endurance}");
            Console.WriteLine($"  PV : {humain.PointDeVie}");

            Console.WriteLine("\n2ème Héros :");
            Console.WriteLine($"{elfe.Nom} l'elfe");
            Console.WriteLine($"  Force : {elfe.Force}");
            Console.WriteLine($"  Endurance : {elfe.Endurance}");
            Console.WriteLine($"  PV : {elfe.PointDeVie}");

            Console.WriteLine("\n3ème Héros :");
            Console.WriteLine($"{nain.Nom} le nain");
            Console.WriteLine($"  Force : {nain.Force}");
            Console.WriteLine($"  Endurance : {nain.Endurance}");
            Console.WriteLine($"  PV : {nain.PointDeVie}");


            Console.WriteLine("\n > Création de 4 monstres");

            Loup loup = new();
            loup.Butin.Add("Peau",2);
            loup.Butin.Add("Croc", 2);
            loup.Butin.Add("Viande", 1);

            Ours ours = new();
            ours.Butin.Add("Peau", 4);
            ours.Butin.Add("Viande", 2);
            ours.Butin.Add("Griffe", 4);

            Dragonnet dragonnet = new();
            dragonnet.Butin.Add("Peau", 8);
            dragonnet.Butin.Add("Aile", 2);
            dragonnet.Butin.Add("Or", 100);

            Bandit bandit = new();
            bandit.Butin.Add("Or", 50);
            bandit.Butin.Add("Repas", 2);
            bandit.Butin.Add("Viande", 2);
            bandit.Butin.Add("Aile", 1);
            bandit.Butin.Add("Peau", 2);
            bandit.Butin.Add("Griffe", 2);
            bandit.Butin.Add("Croc", 2);

            Console.WriteLine("\n1er monstre :");
            Console.WriteLine("Le Loup");
            Console.WriteLine($"  Force : {loup.Force}");
            Console.WriteLine($"  Endurance : {loup.Endurance}");
            Console.WriteLine($"  PV : {loup.PointDeVie}");

            Console.WriteLine("\n2ème monstre :");
            Console.WriteLine("L'Ours");
            Console.WriteLine($"  Force : {ours.Force}");
            Console.WriteLine($"  Endurance : {ours.Endurance}");
            Console.WriteLine($"  PV : {ours.PointDeVie}");

            Console.WriteLine("\n3ème monstre :");
            Console.WriteLine("Le Dragonnet");
            Console.WriteLine($"  Force : {dragonnet.Force}");
            Console.WriteLine($"  Endurance : {dragonnet.Endurance}");
            Console.WriteLine($"  PV : {dragonnet.PointDeVie}");

            Console.WriteLine("\n4ème monstre :");
            Console.WriteLine("Le Bandit");
            Console.WriteLine($"  Force : {bandit.Force}");
            Console.WriteLine($"  Endurance : {bandit.Endurance}");
            Console.WriteLine($"  PV : {bandit.PointDeVie}");

            Console.WriteLine("\n > TEST BAGARRE ⚔️ ");
            Console.WriteLine("L'humain frappe le loup");
            humain.Frappe(loup);

            Console.WriteLine("Le Loup");           
            Console.WriteLine($"  PV : {loup.PointDeVie}");

            Console.WriteLine("\nL'ours frappe l'humain");
            ours.Frappe(humain);
            Console.WriteLine("L'humain");
            Console.WriteLine($"  PV : {humain.PointDeVie}");

            humain.SeReposer();
            Console.WriteLine("L'humain");
            Console.WriteLine($"  PV : {humain.PointDeVie}");

            Console.WriteLine("\n > Test cuisine 👨🏻‍🍳");
            humain.Cuisiner(); // ne va pas marcher, pas de viande
            nain.Butin["Viande"] = 2;
            nain.Cuisiner(); // va fonctionner, le nain possède 2 viandes

            Console.WriteLine("\n > Test manger (🍔 ou 🥩)");
            humain.SubitDegats(10);
            Console.WriteLine("L'humain");
            Console.WriteLine($"  PV : {humain.PointDeVie}");
            humain.Manger(); // pas de repas donc va manger de la viande crue
            Console.WriteLine("L'humain");
            Console.WriteLine($"  PV : {humain.PointDeVie}");

            nain.SubitDegats(10);
            Console.WriteLine("Le nain");
            Console.WriteLine($"  PV : {nain.PointDeVie}");
            nain.Manger(); // possède un repas cuisiné juste avant
            Console.WriteLine("Le nain");
            Console.WriteLine($"  PV : {nain.PointDeVie}");

            Console.WriteLine("\n > Test Potion Bandit");
            Console.WriteLine($"PV Bandit : { bandit.PointDeVie }");
            nain.Frappe(bandit);
            Console.WriteLine($"PV Bandit : {bandit.PointDeVie}");
            nain.Frappe(bandit);
            Console.WriteLine($"PV Bandit : {bandit.PointDeVie}");
            nain.Frappe(bandit);
            Console.WriteLine($"PV Bandit : {bandit.PointDeVie}");
            nain.Frappe(bandit);
            Console.WriteLine($"PV Bandit : {bandit.PointDeVie}");
            nain.Frappe(bandit);
            Console.WriteLine($"PV Bandit : {bandit.PointDeVie}");
            #endregion


            // TODO : Polymorphisme
            // C'est le concept de se dire qu'un Elfe est à la fois du Type Elfe, mais aussi du type Hero, mais aussi du Type Personnage
            List<Personnage> listePerso = new List<Personnage>();
            listePerso.Add(humain);
            listePerso.Add(dragonnet);
            Personnage persoHumain = new Humain();
            // > Ceci s'appelle le casting "implicite" (Un humain est implicitement un personnage

            //persoHumain.SeReposer(); //impossible, persoHumain est une variable de Type Personnage et SeReposer() c'est que pour les Heros
            ((Heros)persoHumain).SeReposer();
            // > Ceci s'appelle le casting "explicite" (Vous indiquez explicitement que c'est un héro dans la variable persoHumain
            // Vous aurez aussi accès à ce genre de comparaisons
            if(persoHumain is Heros)
            {
                
            }
        }
    }
}
