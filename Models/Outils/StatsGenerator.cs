namespace Models.Outils
{
    // ↓ Généralement, une classe static est une boite à outils avec des méthodes et propriété
    //   Idéalement, les méthodes static sont indépendentes !
    //   Regles des classes statiques
    //   - Héritage impossible (la classes est scelé)
    //   - Elle ne peut pas être instancié
    //   - Elle ne peut contenir que des éléments statiques (props, méthode)
    public static class StatsGenerator
    {

        public static int GenerateStatistique()
        {
            // → Simuler un lancer de 4 Dé 6, et on prend la somme des 3 meilleurs.
            De d6 = new De(6);
            int nbLancer = 4;
            int nbConcerver = 3;

            // Lancer de dé
            List<int> results = [];
            for (int i = 0; i < nbLancer; i++)
            {
                results.Add(d6.Lancer());
            }

            // Trie les resutlats
            // → Intro au méthode de LinQ (Méthode des collection : IEnumerable)
            //int stats = results.Order().Skip(nbLancer - nbConcerver).Sum();
            int stats = results.OrderDescending().Take(nbConcerver).Sum();
            return stats;
        }

    }
}
