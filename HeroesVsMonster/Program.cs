using Models.Core;
using Models.Unites;

namespace HeroesVsMonster
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Personnage bob = new Personnage();
            //bob.PointDeVie = 20; valeur par défaut dans le personnage + encapsulaton pour empècher "set"

            Personnage dave = new();
            //dave.PointDeVie = 20; valeur par défaut dans le personnage + encapsulaton pour empècher "set"

            bob.Frappe(dave);

            Console.WriteLine("Bob pv: "+bob.PointDeVie);
            Console.WriteLine("Dave pv: "+dave.PointDeVie);

            Console.WriteLine("Un arbre tombe sur Dave!!!");
            dave.SubitDegats(5);
            dave.SubitDegats(-5); // génera une erreur quand on aura vu les erreurs ;D

            if (!dave.EstEnVie)
            {
                Console.WriteLine("Dave mort :'( ");
            }

            Plateau monde = new();
            monde[5, 5] = "d";
            monde[0, monde.Taille-1] = "l";

            // Affichage du monde
            for(int y = 0; y < monde.Taille; y++)
            {
                for(int x = 0; x < monde.Taille; x++)
                {
                    Console.Write((monde[y,x] ?? "_") + '\t');
                }
                Console.Write("\n");
            }
        }
    }
}
