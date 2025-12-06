using System.Text;



public class Bibliotheque
{
    public List<Document> Documents { get; set; } = new();

    public void AjouterDocument(Document d)
    {
        Documents.Add(d);
    }

    public void SupprimerDocument(Guid id)
    {
        var doc = Documents.FirstOrDefault(d => d.Id == id);
        if (doc == null)
            throw new DocumentNonTrouveException("Document introuvable !");
        
        Documents.Remove(doc);
    }

    public List<Document> Rechercher(string motCle)
    {
        var result = Documents
            .Where(d =>
                d.Titre.Contains(motCle, StringComparison.OrdinalIgnoreCase) ||
                d.Auteur.Contains(motCle, StringComparison.OrdinalIgnoreCase))
            .ToList();

        if (result.Count == 0)
            throw new DocumentNonTrouveException("Aucun document trouvé !");
        
        return result;
    }

    public void AfficherTous()
    {
        if (Documents.Count == 0)
        {
            Console.WriteLine("Aucun document dans la bibliothèque.");
            return;
        }

        foreach (var doc in Documents)
            doc.AfficherDetails();
    }

    // ---------------------
    // SAUVEGARDE (CSV)
    // ---------------------
    public void Sauvegarder(string chemin)
    {
        try
        {
            using FileStream fs = new FileStream(chemin, FileMode.Create);
            using StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);

            foreach (var d in Documents)
            {
                if (d is Livre l)
                    sw.WriteLine($"LIVRE;{l.Id};{l.Titre};{l.Auteur};{l.Annee};{l.NombrePages}");

                else if (d is Magazine m)
                    sw.WriteLine($"MAGAZINE;{m.Id};{m.Titre};{m.Auteur};{m.Annee};{m.Numero}");

                else if (d is DocumentPDF p)
                    sw.WriteLine($"PDF;{p.Id};{p.Titre};{p.Auteur};{p.Annee};{p.TailleEnMo}");
            }
        }
        catch (IOException ex)
        {
            Console.WriteLine("Erreur d'accès au fichier : " + ex.Message);
        }
    }

    // ---------------------
    // CHARGEMENT (CSV)
    // ---------------------
    public void Charger(string chemin)
    {
        try
        {
            if (!File.Exists(chemin))
                throw new FileNotFoundException("Fichier introuvable.");

            Documents.Clear();

            using FileStream fs = new FileStream(chemin, FileMode.Open);
            using StreamReader sr = new StreamReader(fs, Encoding.UTF8);

            string? line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] t = line.Split(';');
                string type = t[0];
                Guid id = Guid.Parse(t[1]);
                string titre = t[2];
                string auteur = t[3];
                int annee = int.Parse(t[4]);

                Document doc;

                switch (type)
                {
                    case "LIVRE":
                        doc = new Livre(titre, auteur, annee, int.Parse(t[5])) { Id = id };
                        break;

                    case "MAGAZINE":
                        doc = new Magazine(titre, auteur, annee, int.Parse(t[5])) { Id = id };
                        break;

                    case "PDF":
                        doc = new DocumentPDF(titre, auteur, annee, double.Parse(t[5])) { Id = id };
                        break;

                    default:
                        throw new FormatException("Type de document inconnu : " + type);
                }

                Documents.Add(doc);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erreur lors du chargement : " + ex.Message);
        }
    }
}
