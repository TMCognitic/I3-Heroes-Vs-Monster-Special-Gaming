// -------------- PLATEAU --------------
using Models.Core;
using Models.Interfaces;
using Models.Unites;
using Models.Unites.Jouables;
using Models.Unites.Monstres;

Console.OutputEncoding = System.Text.Encoding.UTF8;
ConsoleColor initialColor = Console.ForegroundColor;

// --------- SETUP PARTIE ------------
// Création plateau
Plateau plateau = new(20);

Console.WriteLine("------------------------");
Console.WriteLine("       Bienvenue        ");
Console.WriteLine("------------------------");
Console.WriteLine("\nBienvenue dans la forêt de Shorewood aventurier·e !");
Console.WriteLine("\nChoisissez votre héro·ine :");
Console.WriteLine("1) 🙆🏻 Humain·e (le choix des normies)");
Console.WriteLine("2) 🧝🏻 Elfe (le choix des gens classes)");
Console.WriteLine("3) 🧔🏻‍♀️ Nain·e (le choix des bourrin·e·s\n");
Console.Write(">   ");
int choix = int.Parse(Console.ReadLine()); //On trust l'utilisateur, c'est le monde des bisounours

Console.WriteLine("\nQuel est son petit nom ?");
Console.Write(">   ");
string nom = Console.ReadLine();

Heros hero = choix == 1 ? new Humain(nom) : choix == 2 ? new Elfe(nom) : new Nain(nom);

List<Monstre> monstres = new List<Monstre>();
for (int i = 0; i < 20; i++)
{
    int rand = Random.Shared.Next(0, 6);
    Monstre m = rand < 2 ? new Loup(plateau.Taille) : rand < 4 ? new Ours(plateau.Taille) : rand < 5 ? new Bandit(plateau.Taille) : new Dragonnet(plateau.Taille);
    monstres.Add(m);

}

Console.Clear();
Console.WriteLine("Votre personnage et les monstres ont été créés avec succès ! Appuyez sur n'importe quelle touche pour entrer dans la forêt.");
Console.ReadKey();
Console.Clear();


// --------- FIN SETUP PARTIE ------------

// --------- AFFICHAGE ----------

while (hero.EstEnVie)
{
    Console.Clear();
    // Affichage du plateau
    for (int y = 0; y < plateau.Taille; y++)
    {
        for (int x = 0; x < plateau.Taille; x++)
        {
            // FindAll fait un foreach est selectionne tous les éléments (m) qui correspondent à la condition m.PositionX == x && m.PositionY == y
            // monstresTrouves est une liste contenant les monstres trouvés à la position actuelle
            List<Monstre> monstresTrouves = monstres.FindAll(m => m.PositionX == x && m.PositionY == y);

            // Si j'ai au moins un monstré trouvé à la case x,y ET qu'un héro se trouve aussi dans cette case
            if (monstresTrouves.Any() && hero.PositionX == x && hero.PositionY == y)
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" X ");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = initialColor;

            }
            // Si j'ai plus que 1 monstre sur la case x,y
            else if (monstresTrouves.Count > 1)
            {
                Console.BackgroundColor = ConsoleColor.DarkCyan;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" # ");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = initialColor;


            }
            // Si j'ai pile 1 monstre sur la case
            else if (monstresTrouves.Count == 1)
            {
                if(monstresTrouves[0] is Loup)
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                if(monstresTrouves[0] is Ours)
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                if(monstresTrouves[0] is Bandit)
                    Console.BackgroundColor = ConsoleColor.DarkMagenta;
                if (monstresTrouves[0] is Dragonnet)
                    Console.BackgroundColor = ConsoleColor.DarkGreen;

                Console.ForegroundColor = ConsoleColor.White;

                Console.Write($" {monstresTrouves[0].Symbol} ");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = initialColor;

            }

            else
            {
                if (hero.PositionX == x && hero.PositionY == y)
                {
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.Write($" {hero.Symbol} ");
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                else
                {
                    Console.Write(" _ ");
                }

            }

        }
        Console.Write("\n");
    }



    #region Affichage des stats du perso 
    int i = 65; int j = 0;
    Console.SetCursorPosition(i, j++);
    Console.WriteLine("╔══════════════════╦════════════════╗");
    Console.SetCursorPosition(i, j++);
    Console.WriteLine($"║ Type             ║ {hero.GetType().Name,-15}║");
    Console.SetCursorPosition(i, j++);
    Console.WriteLine("╠══════════════════╬════════════════╣");
    Console.SetCursorPosition(i, j++);
    Console.WriteLine($"║ Nom              ║ {hero.Nom,-15}║");
    Console.SetCursorPosition(i, j++);
    Console.WriteLine("╠══════════════════╬════════════════╣");
    Console.SetCursorPosition(i, j++);
    Console.WriteLine($"║ Endurance        ║ {hero.Endurance,-15}║");
    Console.SetCursorPosition(i, j++);
    Console.WriteLine("╠══════════════════╬════════════════╣");
    Console.SetCursorPosition(i, j++);
    Console.WriteLine($"║ Force            ║ {hero.Force,-15}║");
    Console.SetCursorPosition(i, j++);
    Console.WriteLine("╠══════════════════╬════════════════╣");
    Console.SetCursorPosition(i, j++);
    Console.WriteLine($"║ PV               ║ {hero.PointDeVie,-15}║");
    Console.SetCursorPosition(i, j++);

    Console.WriteLine("╚══════════════════╩════════════════╝");
    #endregion

    #region Affichage légende
    i = 65; j = 12;
    Console.SetCursorPosition(i, j++);
    Console.WriteLine("Légende :");

    Console.SetCursorPosition(i, j);
    Console.BackgroundColor = ConsoleColor.DarkRed;
    Console.ForegroundColor = ConsoleColor.White;
    Console.Write("X");
    Console.BackgroundColor = ConsoleColor.Black;
    Console.ForegroundColor = initialColor;
    Console.SetCursorPosition(i+5, j++);
    Console.WriteLine(": Bagarre entre héro·ine et monstre(s)");

    Console.SetCursorPosition(i, j);
    Console.BackgroundColor = ConsoleColor.DarkYellow;
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("H-E-N");
    Console.BackgroundColor = ConsoleColor.Black;
    Console.ForegroundColor = initialColor;
    Console.SetCursorPosition(i + 5, j++);
    Console.Write(": Votre héro·ine (Humain·e, Elfe, Nain·e)");

    Console.SetCursorPosition(i, j);
    Console.BackgroundColor = ConsoleColor.DarkCyan;
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("#");
    Console.BackgroundColor = ConsoleColor.Black;
    Console.ForegroundColor = initialColor;
    Console.SetCursorPosition(i + 5, j++);
    Console.Write(": Plusieurs monstres sur la case");

    Console.SetCursorPosition(i, j);
    Console.BackgroundColor = ConsoleColor.DarkBlue;
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("L");
    Console.BackgroundColor = ConsoleColor.Black;
    Console.ForegroundColor = initialColor;
    Console.SetCursorPosition(i + 5, j++);
    Console.Write(": Monstre Loup");

    Console.SetCursorPosition(i, j);
    Console.BackgroundColor = ConsoleColor.DarkGray;
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("O");
    Console.BackgroundColor = ConsoleColor.Black;
    Console.ForegroundColor = initialColor;
    Console.SetCursorPosition(i + 5, j++);
    Console.Write(": Monstre Ours");

    Console.SetCursorPosition(i, j);
    Console.BackgroundColor = ConsoleColor.DarkMagenta;
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("B");
    Console.BackgroundColor = ConsoleColor.Black;
    Console.ForegroundColor = initialColor;
    Console.SetCursorPosition(i + 5, j++);
    Console.Write(": Monstre Bandit");

    Console.SetCursorPosition(i, j);
    Console.BackgroundColor = ConsoleColor.DarkGreen;
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("D");
    Console.BackgroundColor = ConsoleColor.Black;
    Console.ForegroundColor = initialColor;
    Console.SetCursorPosition(i + 5, j++);
    Console.Write(": Monstre Dragonnet");
    #endregion

    hero.SeDeplacer(plateau.Taille);

    foreach (Monstre m in monstres)
    {
        if (m is IDeplacable move)
        {
            move.SeDeplacer(plateau.Taille);
        }
    }

}


