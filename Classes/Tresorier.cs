using System.Windows.Documents;

public class Tresorier : Personne
{
    public Tresorier(string nom, string prenom, string tel, int id, string motdepasse)
    {
        this.nom = nom;
        this.prenom = prenom;
        this.tel = tel;
        this.id = id;
        motDePasse = motdepasse;
    }
    public override string ToString()
    {
        return "Tresorier: " + nom + " " + prenom + " " + tel + " " + id + " " + motDePasse;
    }
    public Tresorier()
    {
    }
    public Tresorier(int id)
    {
        this.id = id;
    }
    public override string nom
    {
        get;
        set;
    }
    public override string prenom
    {
        get;
        set;
    }
    public override string tel
    {
        get;
        set;
    }
    public override int id
    {
        get;
        set;
    }
    public override string motDePasse
    {
        get;
        set;
    }

    public void envoiLettreRappel()
    {

    }
    public void payerConducteur()
    {

    }
    public void reclamerForfait()
    {

    }

}