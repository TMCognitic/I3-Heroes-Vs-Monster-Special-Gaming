# Heroes Vs Monsters

## Présentation

Bienvenue dans la forêt de « Shorewood », forêt enchantée du pays de « Stormwall ».
Dans cette forêt, se livre un combat acharné entre les héros d’une part et les monstres d’autre part.

Notre rôle est de donner vie à cette forêt au travers d’un programme écrit en console reprenant les concepts orientés objets vu au cours.

## Exercices à faire en .Net 10

### Assembly & Namespace

Commençons par structurer un peu notre monde :

- Créer un projet type « Console » nommé « HeroesVsMonster »
- Créer un projet type « Bibliothèque de classes » nommé « Models »

Dans le projet « Models », créer les répertoires :

- Commun
- Unites
- Core
- Structures
- Outils

Créer deux classes :

Personnage (répertoire Unites) :

- Attributs :
  - Nom : string,
  - Force : int,
  - Endurance : int,
  - PV (PointDeVie) : int

- Méthodes :
  - Frappe (void Frappe(Personnage cible)).\_
    Cette méthode lance un dé 4 faces (1 à 4) et retire les points de vie à la cible.

De (Répertoire Outils) :

- Attributs :
  - Maximum (int)
- Méthodes :
  - Lancer (int Lancer())

```c#
//Pour lancer un dé : retourne une valeur comprise entre 1 et max inclut
Random.Shared.Next(max) + 1
```

Dans la classe Program.cs :

- Créez deux instances de la classe personnage appelée source et cible.
- Mettez 20 points de vie (PV) à la cible
- Et faite en sorte que la source frappe la cible.
- Assurez vous que la cible ait bien perdu des points de vie.

---

### Encapsulation & Propriétés

Dans la classe Personnage :

- Limitez l'accès à l'attribut `PointDeVie` en lecture seule
- Créez un propriété `EstEnVie` qui est vrai lorsque "PointDeVie > 0"

Dans le Program.cs :

- Ajoutez un ligne `Console.WriteLine("Un arbre tombe !!!");`
- Retirez 5 points de vie à un personnage

---

### Indexeurs

- Créez une classe `Plateau` qui contiendra un tableau de chaîne de caractères à 2 dimensions, nommé grille (qui sera un carré).
- La taille du tableau est définie par une constante dans la classe Plateau
- Dans `program.cs` créer une variable "monde" qui est une instance du plateau et ajouter des éléments sur la carte (ex: "d" pour dragon, "l" pour loup...) _(N'en mettez pas trop pour le moment! Attendez la fin du projet 😅)_
- Afficher le tableau à 2 dimensions dans la console
- BONUS: Changer le tableau de chaîne de caractères en énumération

---

### Surcharges d'opérateurs

---

### Héritage

---

### Polymorphisme

---

### Interfaces

---

### Construction et Destruction d'objets

---

### Exceptions

---

### Génériques

---

### Délégués

---

### Evénements

---
