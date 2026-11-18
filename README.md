# 🕹️ Retro Arcade — Borne de Jeux Console en C#

Une borne d'arcade rétro interactive développée en **C# (.NET)** en mode console. Le joueur choisit son pseudo, navigue dans un menu interactif et cumule des points à travers 5 mini-jeux aux logiques algorithmiques distinctes.

Projet d'algorithmique et de programmation structurée réalisé dans le cadre de ma formation en développement logiciel (BTS SIO).

---

## 🎮 Les 5 Mini-Jeux Disponibles

1. **Le Nombre Mystère** :
   - Trouver un nombre aléatoire entre 1 et 100 en maximum 7 essais.
   - Système de points dégressif : 70 points au 1er coup, perte de 10 points par essai supplémentaire.
2. **La Station Spatiale** :
   - Rejoindre la station spatiale (100 unités de distance) avec 50 unités de carburant.
   - Choix de 3 types de poussées (Économique, Normal, Turbo) et gestion d'aléas spatiaux (attraction gravitationnelle, pluie d'astéroïdes, trou noir fatal).
3. **Le Tir de Précision** :
   - 5 tirs pour atteindre au plus près une cible mobile aléatoire située entre 1 et 100 mètres.
   - Barème officiel de points calculé selon l'écart absolu avec la cible (du « Dans le mille » au « Complètement raté »).
4. **Survival Quest (La Quête)** :
   - Traversée de 10 étapes hostiles pour atteindre le refuge.
   - Gestion de ressources critiques : Points de Vie (PV), Nourriture, Pièces d'or et Potions.
   - Événements aléatoires (coffre piégé, tempête, rencontre avec un marchand ambulant, prise de raccourci) et fin de tour avec consommation de rations / famine.
5. **La Machine à Sous** :
   - Démarrage avec un capital de 100 pièces et mise au choix.
   - Tirage de 3 chiffres aléatoires : 3 identiques (mise x4), 2 identiques (mise x2), aucun identique (perte de la mise).
   - Conversion des pièces restantes en score final lors de la sortie.

---

## 🧠 Notions Algorithmiques & Compétences Mises en Œuvre

* **Génération aléatoire contrôlée** : Utilisation de la classe `System.Random`.
* **Contrôle et validation des entrées utilisateur** : Blindage des saisies avec `int.TryParse` et gestion des boucles `while` et `do...while`.
* **Structures conditionnelles** : Arborescences `if / else if / else` et aiguillage `switch / case`.
* **Modularité et architecture du code** : Découpage clair en sous-programmes et méthodes indépendantes.
* **Interface Console soignée** : Utilisation des couleurs (`ConsoleColor`), encadrés ASCII, en-têtes dynamiques et pauses interactives (`Console.ReadKey`).

---

## 💻 Exécution du Projet

### Prérequis
* Le SDK .NET (version 6.0, 7.0 ou 8.0).
* Visual Studio, Visual Studio Code ou tout terminal compatible.

### Lancement en ligne de commande
```bash
# Cloner le dépôt
git clone https://github.com/TomVernierFetu/retro-arcade-csharp.git

# Accéder au dossier
cd retro-arcade-csharp

# Compiler et lancer
dotnet run
```

---

## 👤 Auteur

* **Tom Vernier-Fétu** — Développeur junior en recherche d'alternance.
