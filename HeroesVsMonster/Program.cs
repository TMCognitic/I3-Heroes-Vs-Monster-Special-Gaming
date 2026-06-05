using Models.Core;
using Models.Unites;

namespace HeroesVsMonster
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region TEST PERSONNAGES
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("   [TESTS] Création de personnages ");
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

            Console.WriteLine("\n\n Appuyez sur n'importe quelle touche pour voir le test suivant");
            Console.ReadLine();
            Console.Clear();
            #endregion

            #region TEST PLATEAU DE JEU
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("   [TESTS] Plateau ");
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
        
            
        }
    }
}
