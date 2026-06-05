

namespace Models.Unites
{
    public class Heros : Personnage
    {
        // On va déplacer Name qui était dans Personnage dans Heros : il n'y a que nos héros qui auront un petit nom
        public string Nom { get; set; }

        // On va créer un dictionnaire pour les Butins avec comme clef le type de butin et comme valeur 0 pour le héro, puisqu'il commence avec aucun butin
        public Dictionary<string, int> Butin { get; set; } = new()
        {
            { "Or", 0},
            { "Peau", 0},
            { "Griffes", 0},
            { "Crocs", 0},
            { "Viande", 0},
            { "Aile", 0},
            { "Repas", 0}
        };

    }
}
