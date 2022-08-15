using System.Collections.Generic;

public class Velo
{
    private int id = 0;
    private int poids = 0;
    private string type = "";
    private int longueur = 0;
    private List<Inscription> inscriptions = new List<Inscription>();
    public Velo(string type, int poids, int longueur)
    {
        this.type = type;
        this.poids = poids;
        this.longueur = longueur;
    }
    public Velo(int id,string type, int poids, int longueur)
    {
        this.id = id;
        this.type = type;
        this.poids = poids;
        this.longueur = longueur;
    }
    public override string ToString()
    {
        return "Velo: Id:"+id+" Type:" + type + " P:" + poids + " L:" + longueur;
    }
    public int Poids
    {
        get;
        set;
    }
    public string Type
    {
        get;
        set;
    }
    public int Id
    {
        get;
        set;
    }
    public int Longueur
    {
        get;
        set;
    }
    public Velo() { }
    public List<Inscription> Inscriptions
    {
        get { return inscriptions; }
        set { inscriptions = value; }
    }

    public void AddInscription(Inscription inscription)
    {
        this.inscriptions.Add(inscription);
    }
    public void RemoveInscription(Inscription inscription)
    {
        this.inscriptions.Remove(inscription);
    }
    
   
}
