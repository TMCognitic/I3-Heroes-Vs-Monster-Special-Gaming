# Heroes Vs Monsters

## Présentation

Bienvenue dans la forêt de « Shorewood », forêt enchantée du pays de « Stormwall ».
Dans cette forêt, se livre un combat acharné entre les héros d’une part et les monstres d’autre part.

Notre rôle est de donner vie à cette forêt au travers d’un programme écrit en console reprenant les concepts orientés objets vus au cours.

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
//Pour lancer un dé : retourne une valeur comprise entre 1 et max inclus
Random.Shared.Next(max) + 1
```

Dans la classe Program.cs :

- Créez deux instances de la classe personnage appelées source et cible.
- Mettez 20 points de vie (PV) à la cible
- Faites en sorte que la source frappe la cible.
- Assurez vous que la cible ait bien perdu des points de vie.

---

### Encapsulation & Propriétés

Dans la classe Personnage :

- Limitez l'accès à l'attribut `PointDeVie` en lecture seule
- Créez une propriété `EstEnVie` qui est vraie lorsque "PointDeVie > 0"

Dans le Program.cs :

- Ajoutez un ligne `Console.WriteLine("Un arbre tombe !!!");`
- Retirez 5 points de vie à un personnage

---

### Indexeurs

- Créez une classe `Plateau` qui contiendra un tableau de chaînes de caractères à 2 dimensions, nommé grille (qui sera un carré).
- La taille du tableau est définie par une constante dans la classe Plateau
- Dans `program.cs` créez une variable "monde" qui est une instance du plateau et ajoutez des éléments sur la carte (ex: "d" pour dragonnet, "l" pour loup...) _(N'en mettez pas trop pour le moment! Attendez la fin du projet 😅)_
- Affichez le tableau à 2 dimensions dans la console
- BONUS: Changez le tableau de chaînes de caractères en énumération

---

### ~~Surcharges d'opérateurs~~

---

### Héritage

#### Dans le projet « Models » : 
Créez des classes de personnages spécialisées : 
- Jouable : les humains, les elfes, les nains
- Monstre : les loups, les dragonnets, les bandits, les ours

Le personnage jouable possède de l'or et du butin.  
Chaque classe de personnage a ses bonus et malus : 
- Humain : Un bonus +1 en force et +1 en endurance
- Nain : Un bonus +2 en endurance
- Elfe : Un bonus +3 en endurance et malus de -2 en force (minimum 1)

Les montres peuvent posséder du butin _(A initialiser dans dans programme.cs)_ :
- Loup : Peau, Crocs, Viande.
- Ours : Peau, Griffes, Viande.
- Dragonnet : Peau, Ailes, Or.
- Bandit : Or, Repas, tout le butin des autres monstres.

Les monstres possèdent également des bonus et malus : 
- Loup : Pas de bonus, ni de malus.
- Ours : Bonus de +2 en force
- Dragonnet : Bonus de protection (Armure) de 5 et bonus de force de -3
- Bandit : Bonus +3 force et malus -2 en endurance

BONUS : Modification de la classe « Personnage »
- La statistique "endurance" permet d'obtenir un bonus de résistance
- La statistique "force" permet d'obtenir un bonus de dégats lors d'une attaque
- Calcul du bonus : 
  - Inférieure à 10 : -1
  - Égale à 10 : 0
  - Supérieure à 10 : +1
  - À partir de 13 : +2


#### Dans la classe Program.cs
Dans un premier temps, tester les interactions entre les personnages :
- Créez des héros et des monstres
- Les héros doivent savoir : 
  - Attaquer un monstre
  - Se reposer (Gain de 10 pdv)
  - Cuisiner (Transforme la viande en repas)
  - Manger (Gain de 5 pdv pour un repas. Gain de -3 à 3 pour de la viande crue)
  - Récuperer le butin d'un monstre
- Les monstres peuvent : 
  - Attaquer le héro
  - Boire une potion de soin (Bandit uniquement : 11 chance sur 100 quand il a moins de 5 pdv)
---

### Construction d'objet (Intro)
Définir sur toutes les classes (Sauf « Plateau ») du projet « Models » des constructeurs :
- De \
  _Le nombre de face doit être fourni via le constructeur et la propriété passe en lecture seul._

- Les classes personnages (Nain, Humain, Elfe, Loup, Dragonnet, Bandit, Ours) \
  _La valeur des stats (force / endurance) seront defini aleatoirement à la création._

  - Les personnages jouables \
    _Le nom du personnage doit être fourni via le constructeur._

  - Les monstres \
    _Le nombre de chaque butin est généré aleatoirement._

Régle de génération des statistiques 
- Définir la force et l'endurance à la valeur 13 (Dans le ctor)
- Version final : Simuler un lancer de 4 Dé 6, et prendre les 3 meilleurs

Regle pour la gestion des point de vie
- Le nombre de pdv maximum d'un personnage est calculé via la formule suivante `(Endurance * 2) - 5`.
- Le nombre de pdv maximum sera toujours au minimum de 6 _(Exemple: une efle de endurance de 4 → Pdv max 6 quand meme)_.

Régle de génération du nombre de butin
- Peau : Dé 3
- Crocs : Dé 3 - 1
- Griffes : Dé 4 + 1
- Ailes : 0 ou 2
- Viande : Dé 6
- Repas : Dé 3
- Or : Dé 100 

NB : Adapté ou commenté le code de test des classes dans program.cs

---

### Polymorphisme
Dans une nouvelle app console : 
- Mise en place une liste de Monstre (avec une 15e de monstre aleatoire)
- Mise en place d'un "arene de combat"
  - Combat avec un monstre
  - Tous les 3 combats, il cuisine
  - Tous les 5 combats, il se repose
  - Apres un combat, si moins de 15pdv, le hero mange
- L'arene se termine : 
  - Le hero a vaincu les monstres (Affiche un résumé)
  - Le héro est mouru. Affiche le monstre qui l'a achevé

---

### Les classes abstraites
Definir les classes qui seront abstraite ?

Modifier le code pour
- Chaque personnage à un nom afficher
  _La modification doit être futur proof (Exemple : Arrivé de marchant)_
  - Hero : <Type_Hero> <Nom> 
  - Monstre : <Type_monstre>
 
- Les monstres ont un texte d'introduction
  - Le loup et l'ours ont un crie
  - La dragonnet essais de craché du feu
  - Le bandit insulte (gentillement) le hero

---

### Les classes statiques
Rendre les statistiques des personnes aleatoire.

Outil de génération des statistiques 
- Simuler un lancer de 4 Dé 6, et prendre les 3 meilleurs.
- Cette outil doit être une classe statique.

---

### Interfaces
Dans un nouveau projet console (HeroesVSMonsters_V3) 

#### Plateau de jeu
Créer un plateau de 20 x 20 rempli de "_"

#### Personnages
Créer les interfaces suivantes :

* **IPositionnable** qui permet d'indiquer qu'un personnage est positionnable sur un plateau (ils le sont tous). Un personnage positionnable possède une **coordonnée en X**, **une coordonnée en Y**, un **symbole** à afficher (H, N, E, L etc...).
  > Il faudra modifier le constructeur des monstres pour génèrer aléatoirement les positions 

  > Il faudra modifier le constructeur des héros pour mettre les positions en 0,0 

  > [! Warning]
  > (Attention à ne pas créer en dehors du plateau)

  > [! Info]
  > Plusieurs monstres peuvent se retrouver avec les mêmes coordonnées. On ne gèrera pas ça pour l'instant, on ne les verra juste pas sur la carte.

* **IDeplacable** qui permet d'indiquer si un personnage peut se déplacer sur la carte. Il possède alors une valeur de **déplacement max** (ex : MaxDeplacement qui vaut 1 ou 2) et une **fonction SeDeplacer**(int tailleMaxPlateau) pour modifier les coordonnées X et Y du personnage.
  - Pour les héros, ils se déplacent tous de 1 case à la fois.
  - Pour les monstres : Le loup se déplace de 2 cases max, le bandit et l'ours d'1 case max et le dragonnet ne peut pas se déplacer.

> Pour le **déplacement des monstres**, on fera une valeur aléatoire entre -maxDeplacement et le maxDeplacement autorisé (ex: si maxDeplacement = 1, valeurs possibles sont -1 0 1).\
> (Attention, il faudra vérifier si le déplacement est autorisé (si on n'a pas atteint le bord du plateau))

> Pour le **déplacement du joueur**, on demande à l'utilisateur dans quelle direction il souhaite aller (Gauche, Droite, Haut, Bas) et on change ses positions en fonction du choix.\
> (Attention à ne pas sortir du plateau)

### Mise en place jeu
* Créer un héro (en demandant à l'utiliseur lequel il souhaite jouer)

* Créer une liste aléatoire de 10 monstres.

* Placer le tout sur le plateau (H pour Humain, N pour Nain, E pour Elfe, L pour Loup, B pour Bandit, O pour Ours et D pour Dragonnet) 

À chaque tour de jeu :
- On **déplace le héro** (hint : Console.ReadKey())
- On fait se **déplacer les monstres**
- On met à jour l'**affichage** du plateau

> [! Tips]
> Vous pouvez, entre chaque tour, effectuer un Console.Clear() pour réactualiser le plateau.

---

### Construction et Destruction d'objets

---

### Exceptions

#### Declancher une erreur si
- Un personnage subit des degats negatifs
- Le hero loot un monstre encore vivant
- Création d'un dé impossible (- de 2 face)

Remarque : 
- Version initial : Envoyer une erreur « Exception » avec un message
- Version final   : _A voir avec Aude :p_

#### Traiter une erreur (try...catch)
Encapsuler le code « HereosVsMonster_v2 » pour traiter les erreurs.
Si une erreur à lieu, afficher : « Erreur : <message> !!! » 



---

### Génériques

---

### Délégués

---

### Evénements

---

<hr style="height:50px">

# Liens vers les Démos
## Namespace, Encaplusations, Indexeurs
[Demo Phil](https://github.com/phil-bstorm/C_sharp_POO-i3-gamedev6)

## Héritage, Indexeurs, Polymorphisme, Constructeur, Classes Abstraites, Classes Statiques, Errors
[Demo Aurélien](https://github.com/FormCours/I3_Game__POO__Demo)

## Interfaces
[Demo Aude](https://gitlab.com/audebstorm/i3_2026_game_csharpoo_demo_interface)