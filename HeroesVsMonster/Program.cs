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
        }
    }
}
