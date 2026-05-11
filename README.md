# Heroes Vs Monsters

Bienvenue dans la forêt de « Shorewood », forêt enchantée du pays de « Stormwall ».
Dans cette forêt, se livre un combat acharné entre les héros d’une part et les monstres d’autre part.

Notre rôle est de donner vie à cette forêt au travers d’un programme écrit en console reprenant les concepts orientés objets vu au cours.

Commençons par structurer un peu notre monde :

+ Créer un projet type « Console » nommé « HeroesVsMonster »
+ Créer un projet type « Bibliothèque de classes » nommé « Models »

Dans le projet « Models », créer les répertoires :

+ Commun
+ Unites
+ Core
+ Structures
+ Outils

Créer deux classes :

Personnage (répertoire Unites) :

+ Attributs :
  + Nom : string,
  + Force : int,
  + Endurance : int,
  + PV (PointDeVie) : int

+ Méthodes :
  + Frappe (void Frappe(Personnage cible)).
  Cette méthode lance un dé 4 faces (1 à 4) et retire les points de vie à la cible.

De (Répertoire Outils) :

+ Attributs :
  + Maximum (int)
+ Méthodes :
  + Lancer (int Lancer())

Dans la classe Program.cs :

+ Créez deux instances de la classe personnage appelée source et cible.
+ Mettez 20 points de vie (PV) à la cible
+ Et faite en sorte que la source frappe la cible.
+ Assurez vous que la cible ait bien perdu des points de vie.
