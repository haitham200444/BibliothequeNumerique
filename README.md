Bibliothèque Numérique – Application Console en C#
📌 Présentation du projet

Ce projet consiste à développer une application console permettant de gérer une bibliothèque numérique.
Il offre un ensemble de fonctionnalités pour manipuler différents types de documents (livres, magazines, PDF) en utilisant les principes de la programmation orientée objet en C#.

Le système est conçu pour être simple, extensible et pédagogique, tout en respectant les bonnes pratiques (héritage, classes abstraites, exceptions personnalisées, sérialisation, etc.).

🎯 Objectifs pédagogiques

Manipuler les classes abstraites et l’héritage en C#.

Implémenter des exceptions personnalisées.

Gérer des collections génériques (List<T>).

Organiser le code selon une architecture claire et modulaire.

Lire et écrire des données depuis/vers un fichier texte.

Structurer une application console interactive.

🧱 Architecture du projet

BibliothequeNumerique/

│

├── Document.cs                     # Classe abstraite de base

├── Livre.cs                        # Classe Livre (hérite de Document)

├── Magazine.cs                     # Classe Magazine (hérite de Document)

├── DocumentPDF.cs                  # Classe DocumentPDF (hérite de Document)

├── DocumentNonTrouveException.cs   # Exception personnalisée

├── Bibliotheque.cs                 # Gestion des documents

├── Program.cs                      # Point d’entrée de l’application

│
└── BibliothequeNumerique.csproj    # Fichier de configuration du projet



⚙️ Fonctionnalités principales
Gestion des documents

Ajouter un document

Supprimer un document

Afficher tous les documents

Rechercher par mot-clé

Gestion des fichiers

Sauvegarder la bibliothèque dans un fichier

Charger la bibliothèque depuis un fichier

Interface utilisateur (console)

Menu interactif

Entrée utilisateur sécurisée

Gestion des exceptions

🏗️ Concepts techniques utilisés

Programmation orientée objet

Classe abstraite Document

Héritage : Livre, Magazine, DocumentPDF

Polymorphisme via AfficherDetails()

Exceptions personnalisées

DocumentNonTrouveException

Collections génériques

List<Document>

Sérialisation simple

Lecture/écriture dans un fichier texte

Architecture modulaire

Fichiers séparés pour chaque responsabilité

▶️ Exécution du projet
1. Restaurer les dépendances
dotnet restore

2. Compiler le projet
dotnet build

3. Lancer l’application
dotnet run

📝 Exemple de menu affiché
=== MENU BIBLIOTHÈQUE NUMÉRIQUE ===

1. Ajouter un document
2. Afficher tous les documents
3. Rechercher par mot-clé
4. Supprimer un document
5. Sauvegarder dans un fichier
6. Charger depuis un fichier
7. Quitter

Votre choix :

👤 Auteur

Haitham Azemmour
Projet réalisé dans un cadre académique pour l’apprentissage de la programmation orientée objet en C#.
