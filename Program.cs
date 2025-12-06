Bibliotheque b = new Bibliotheque();
int choix = 0;

do
{
    Console.WriteLine("\n=== MENU BIBLIOTHÈQUE NUMÉRIQUE ===");
    Console.WriteLine("1. Ajouter un document");
    Console.WriteLine("2. Afficher tous les documents");
    Console.WriteLine("3. Rechercher par mot-clé");
    Console.WriteLine("4. Supprimer un document");
    Console.WriteLine("5. Sauvegarder dans un fichier");
    Console.WriteLine("6. Charger depuis un fichier");
    Console.WriteLine("7. Quitter");
    Console.Write("Votre choix : ");

    string? input = Console.ReadLine();
    int.TryParse(input, out choix);

    try
    {
        switch (choix)
        {
            case 1:
                AjouterMenu(b);
                break;

            case 2:
                b.AfficherTous();
                break;

            case 3:
                Console.Write("Mot-clé : ");
                string? mot = Console.ReadLine();
                var resultats = b.Rechercher(mot ?? "");
                foreach (var doc in resultats)
                    doc.AfficherDetails();
                break;

            case 4:
                Console.Write("Id du document à supprimer : ");
                string? idStr = Console.ReadLine();
                if (Guid.TryParse(idStr, out Guid id))
                {
                    b.SupprimerDocument(id);
                    Console.WriteLine("✅ Document supprimé.");
                }
                else
                {
                    Console.WriteLine("❌ Id invalide.");
                }
                break;

            case 5:
                b.Sauvegarder("bibliotheque_sauvegarde.txt");
                Console.WriteLine("✅ Sauvegarde effectuée.");
                break;

            case 6:
                b.Charger("bibliotheque_sauvegarde.txt");
                Console.WriteLine("✅ Chargement effectué.");
                break;

            case 7:
                Console.WriteLine("👋 Au revoir !");
                break;

            default:
                Console.WriteLine("❌ Choix invalide.");
                break;
        }
    }
    catch (DocumentNonTrouveException ex)
    {
        Console.WriteLine("⚠ Erreur : " + ex.Message);
    }
    catch (Exception ex)
    {
        Console.WriteLine("⚠ Erreur inattendue : " + ex.Message);
    }

} while (choix != 7);

static void AjouterMenu(Bibliotheque b)
{
    Console.WriteLine("\nType de document à ajouter :");
    Console.WriteLine("1. Livre");
    Console.WriteLine("2. Magazine");
    Console.WriteLine("3. Document PDF");
    Console.Write("Votre choix : ");
    int.TryParse(Console.ReadLine(), out int type);

    Console.Write("Titre : ");
    string? titre = Console.ReadLine();
    Console.Write("Auteur : ");
    string? auteur = Console.ReadLine();
    Console.Write("Année : ");
    int.TryParse(Console.ReadLine(), out int annee);

    switch (type)
    {
        case 1:
            Console.Write("Nombre de pages : ");
            int.TryParse(Console.ReadLine(), out int pages);
            b.AjouterDocument(new Livre(titre ?? "", auteur ?? "", annee, pages));
            break;

        case 2:
            Console.Write("Numéro du magazine : ");
            int.TryParse(Console.ReadLine(), out int numero);
            b.AjouterDocument(new Magazine(titre ?? "", auteur ?? "", annee, numero));
            break;

        case 3:
            Console.Write("Taille en Mo : ");
            double.TryParse(Console.ReadLine(), out double taille);
            b.AjouterDocument(new DocumentPDF(titre ?? "", auteur ?? "", annee, taille));
            break;

        default:
            Console.WriteLine("❌ Type invalide.");
            break;
    }

    Console.WriteLine("✅ Document ajouté !");
}
