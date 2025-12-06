

public class Livre : Document
{
    public int NombrePages { get; set; }

    public Livre(string titre, string auteur, int annee, int pages)
        : base(titre, auteur, annee)
    {
        NombrePages = pages;
    }

    public override void AfficherDetails()
    {
        Console.WriteLine($"[LIVRE] {Titre} - {Auteur}, {Annee}, Pages: {NombrePages}");
    }
}
