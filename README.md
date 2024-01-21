# Rapport du projet de session
Par équipe yyds 
## Phase2

## Démonstration des applications des trois patrons de conception GoF
### 1. Command Pattern
![text](https://github.com/Baymax9/image/blob/main/3333.png)

Nous créons d'abord l'interface` ICommande `en tant que commande, puis la classe` CommandeInvoke`r en tant que requête. La classe de commande de l'entité` CommandLogger`, qui met en œuvre l'interface` ICommande`, effectuera le traitement réel de la commande. La classe` MainWindow` est créée comme objet appelant, qui instancie l'objet et effectue l'appel.
La classe `MainWindow` utilise les classes` ICommande` et `CommandLogger` pour démontrer le mode de commande, en se basant sur le type de commande pour déterminer quel objet exécute quelle commande.Tout ce qui précède montre une mise en œuvre du modèle de conception `Command Pattern`.


### 2. Factory Pattern  
![text](https://github.com/Baymax9/image/blob/main/1639028629(1).png)
L'interface ` ICommandeFactory` est implémentée par la classe ` CommandeLoggerFactory` ,de sorte que` ICommandeFactory` et ` CommandeLoggerFactory` dans leur ensemble forment une **patten factory**, et la méthode` MainWindow ` est utilisée pour obtenir des objets de la classe entité en les instanciant. Ceci constitue le modèle de conception `patten factory`.

### 3. Prototype Pattern  

![text](https://github.com/Baymax9/image/blob/main/1639034898(1).png)
Nous créons une classe `JudgeTable `qui implémente l'interface `IJudge `et clonons ensuite les entités implémentées par la classe `JudgeTable` et l'interface `IJuge` via la méthode `UpdateTable` de la classe `MainWindow` lorsque la condition de jugement est remplie. La création d'objets dupliqués de cette manière garantit les performances et évite les tracas liés à l'instanciation manuelle.La démonstration du modèle de conception`Prototype Pattern` est complétée ici.





## Tableau des tâches
| Tâche                              | Responsable |
| ---                                | ---         |
| Interface graphique (phase 1)      |   xuyao hu         |
| Notation spéciales (phase 1)       |   jiadong jin      |
| Système de vérification (phase 1)  |   jiadong jin          |
| Sauvegarde et chargement (phase 1) |   jiadong jin \guanting he          |
| Tests unitaires (phase 1)          |   jiadong jin          |
| Rapport (phase 1)                  |   xunxun wang \guanting he          |
| Undo/Redo (phase 2)                |   guanting he          |
| Couleurs (phase 2)                 |   jiadong jin        |
| Sélection multiple (phase 2)       |   jiadong jin       |
| Tests unitaires (phase 2)          |   guanting he         |
| Rapport (phase 2)                  |   xunxun wang \ xuyao hu   |

## Phase1
## Démonstration de principe SOLID
#### 1.Single Responsibility Principle (Principe de responsabilité unique)
Nous allons présenter la préoccupation unique de chaque classe dans le programme:

![text](https://github.com/Hegt1379/PicsINF1035/blob/main/judge1.png)

Cette méthode implémente l'interface 'IJudge'. La responsabilité de cette classe est de juger les valeurs dans la table de jeu.
La méthode `IsLegal()` judge la validité de la valeur dans chaque `SubBox`. Et la méthode `GetLegalTable()` retourne un tableau de deux dimension de type boolean, qui correspond à la validité de tous les valeurs dans cette table de jeu: si les valeurs sont valides, retourne 'true', sinon, retourne 'false'.


![text](https://github.com/Hegt1379/PicsINF1035/blob/main/subbox.png)

La classe `Subbox` va initialiser les 'Subboxes' dans la boîte de 3*3.

![text](https://github.com/Hegt1379/PicsINF1035/blob/main/import.png)

![text](https://github.com/Hegt1379/PicsINF1035/blob/main/export.png)

Les deux classes dessus:`Import` et `Export` font le chargement et l'enregistrement des donnée sous un fichier de type .csv.
#### 2.Open/Closed Principle (Principe ouvert/fermé)
Si l'utilisateur souhaite étendre le moyen juger la validité de la table du jeu Sudoku, il lui suffit d'ajouter la nouvelle méthode dans l'interface et 'overrider' cette méthode dans la nouvelle classe qui implémente l'interface `IJudge` pour réaliser l'extension.
#### 3.Liskov Substitution Principle (Principe de subtitution de Liskov)
Selon la conception de notre programme, l'utilisation d'héritage n'est pas obligatoire, donc il n'y a pas de réflexion correspond à l'héritage dans notre programme. 
#### 4.Interface Segregation Principle (Principe de ségrégation des interfaces)
Comme nous l'avons mentionné ci-dessus, le programme actuel n'a besoin qu'une petite interface (suivant le principe de responsabilité unique) qui contient des méthodes abstraites de juger les valeurs dans la table. Si l'utilisateur souhaite étendre la fonction ou les règles du jeu, le programmeur peut implémenter l'extension en écrivant d'autres méthodes dans `IJudge` ou d'autres petites interfaces selon les besions, à condition de suivre le principe de ségrégation des interfaces.
#### 5.Dependency Injection Principle (Principe d'injection de dépendances)
![text](https://github.com/Baymax9/image/blob/main/555.PNG)

Dans cette relation, `jugeTable` ne dépend plus de types concrets `Subbox` mais d'interface `IJuge` qui peuvent être implémentées de différentes manières et offrent plus de possibilités pour étendre la fonctionnalité de `Subbox`.
## Démonstration des patrons GRASP
#### 1.Spécialiste de l'information et Forte cohésion
Dans le jeu, lorsqu'il est nécessaire de déterminer si la valeur de la petite `Subbox` est légale, un objet de la classe `JudgeTable` sera instancié, en ce moment, la classe `JudgeTable` sera la spécialiste de l'information. De plus, dans cette classe, la méthode `IsLegal()` est chargée de juger la validité de la valeur dans chaque petite `Subbox`, et dans le precessus du parcours de la table dans la méthode `GetLegalTable()`, la méthode `IsLegal()` est appelée pour déterminer la validité de la valeur dans chaque `Subbox`. Les deux méthodes qui ont des fonctions étroitement liées sont écrites dans une classe `JudgeTable` et travaillent ensemble pour accomplir une responsabilité unifiée, qui reflète la forte cohésion. 

#### 2.Créateur, Faible couplage, et Indirection
Étant donné que le `JudgeTable` est composé de `Subbox`, la responsabilité de créer `Subbox` devrait aller à `JudgeTable`, selon le patron Créateur. Le patron propose d'affecter à la classe `JudgeTable` une responsabilité de créations des instances concernant `Subbox` si soit :
>`JudgeTable` est composée d'instance de `Subbox`;
>
>`JudgeTable` possède des données permettant d'initialiser les instances de `Subbox`.

En raison de l'existence de l'interface `IJudge`, nous avons réduit autant que possible la connexion directe entre les deux classes internes(`JudgeTable` et `Subbox`), et réduit autant que possible le couplage élevé qui aurait pu se produire, de sorte que les deux classes sont devenues plus concises et plus cohérentes. 

#### 3.Contrôleur et Pure invention
Dans le programme, tous les événements de routage sont liés à la classe `MainWindow`.Et autrement, en raison de l'existence de la classe `MainWindow`, tous les responsabilités des traitement des événements peuvent être attribués par `MainWindow`, sans ajouter trop de couplage ni réduire la cohésion d'origine. Le patron Pure Invention est reflété ici.

Les responsabilités de réception et de traitement des événements du système(dans ce programme, les événements sont l'input et le output) doivent généralement être attribuées à une classe pouvant représenter l'ensemble du système, et cette classe est `MainWindow`. Par exemple, chaque fois que l'utilisateur entrez, la méthode `InputButtonClick()` est appelée pour relayer ces entrées vers les objets interne(type `Subbox`), ensuite, la méthode `UpdateTable()` est appelée, un objet de la classe `JudgeTable` est instancié, avec les méthodes dans la classe `JudgeTable`, l'utilisateur va savoir si l'entrée soit valide.  Et le traitement de l'input est terminé. 
C'est la même principe de traiter les demandes de l'enregistrement et le chargement. 
Ce processus reflète le patron Contrôleur.
 
