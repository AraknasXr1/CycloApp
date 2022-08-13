using System.Collections.Generic;

public class Velo
{
    private float poids = 0;
    private string type = "";
    private float longueur = 0;
    private List<Inscription> inscriptions = new List<Inscription>();
    public Velo(string type, float poids, float longueur)
    {
        this.type = type;
        this.poids = poids;
        this.longueur = longueur;
    }
    public float Poids
    {
        get { return poids; }
        set { poids = value; }
    }
    public string Type
    {
        get { return type; }
        set { type = value; }
    }
    public float Longueur
    {
        get { return longueur; }
        set { longueur = value; }
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
