// Template "Top-level"
// - Vous êtes dans la méthode "Main" de la classe "program" directement
// - Il faut minimum une ligne de code ;)
//------------------------------------------------------------------------
using Models.Unites;
using Models.Unites.Jouables;
using Models.Unites.Monstres;

Console.OutputEncoding = System.Text.Encoding.UTF8;
const int NB_MONSTRE = 15;

#region Initialisation du jeu
Console.WriteLine("Préparation des monstres...");
List<Monstre> monstres = [];
Random rng = new Random();
for (int i = 0; i < NB_MONSTRE; i++)
{
    int choixMonstre = rng.Next(6);

    Monstre m = (choixMonstre < 2) ? new Loup()
        : (choixMonstre < 4) ? new Ours()
        : (choixMonstre < 5) ? new Bandit()
        : new Dragonnet();

    monstres.Add(m);
    Console.WriteLine($" - {m.NomAfficher}");
}
Console.WriteLine("Les monstres vous attendent 🐺");
Console.ReadLine();

Console.WriteLine();
Console.WriteLine("Quel types de héro voulez vous être ?");
Console.WriteLine(" 1) L'humaine normale");
Console.WriteLine(" 2) L'elfe majestueuse");
Console.WriteLine(" 3) La naine bourrine");
Console.Write("> ");
int choixHero = int.Parse(Console.ReadLine()!); // Monde des bisounours ♥

Console.WriteLine("Quel sera votre nom ?");
Console.Write("> ");
string nomHero = Console.ReadLine()!;

bool choixValidation;
Heros hero;
do
{
    hero = (choixHero == 1) ? new Humain(nomHero)
        : (choixHero == 2) ? new Elfe(nomHero)
        : new Nain(nomHero);

    Console.WriteLine($"Stats du personnage : {hero.Force} Force, {hero.Endurance} End, {hero.PointDeVieMax} Pdv");
    Console.WriteLine("Pret pour l'aventure (y / N)");
    Console.Write("> ");
    choixValidation = Console.ReadLine()?.ToLower() == "y";
}
while (!choixValidation);
#endregion

#region Arene de combat !
List < Personnage > cimetiere = [];
Monstre? attaquant = null;
Console.Clear();
for(int tour = 1; hero.EstEnVie && monstres.Any(); tour++)
{
    // On selectionne le monstre
    attaquant = monstres.First();

    // Combat
    Console.WriteLine($"Un combat commence contre {attaquant.NomAfficher} !");
    Console.WriteLine($" « {attaquant.ObtenirTexteIntro()} » ");
    bool initiativeHero = true;
    while(hero.EstEnVie && attaquant.EstEnVie)
    {
        if(initiativeHero) {
            hero.Frappe(attaquant);
        }
        else
        {
            attaquant.Frappe(hero);
        }

        initiativeHero = !initiativeHero;
    }

    // Action de fin de tour
    if(hero.EstEnVie)
    {
        Console.WriteLine($"{hero.NomAfficher} fête sa victiore !");
        hero.Loot(attaquant);

        if(tour % 5 == 0)
        {
            hero.Cuisiner();
        }
        if (hero.PointDeVie <= (hero.PointDeVieMax / 2))
        {
            hero.Manger();
        }
        if ((tour / 2) * 2 == tour)
        {
            hero.SeReposer();
        }

        // On retire le monstre
        cimetiere.Add(attaquant);
        monstres.Remove(attaquant);
    }

    Console.ReadLine();
}

if(hero.EstEnVie)
{
    Console.WriteLine("Vous avez vaincu l'arene de combat 🥳");
    Console.WriteLine("Votre butin est : ");
    foreach (KeyValuePair<string, int> item in hero.Butin)
    {
        Console.WriteLine($" - {item.Key} : {item.Value}");
    }
}
else
{
    Console.WriteLine("Bouhou ! Vous etes mouru 👻");
    Console.WriteLine($"{attaquant!.GetType().Name} a été plus fort !");
}
#endregion