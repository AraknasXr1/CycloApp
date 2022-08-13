using System.Collections.Generic;

public class Balade
{
    private int num =0;
    private string lieuDepart = "";
    private string dateDepart = "";
    private float forfait = 0;
    private List<Vehicule> vehicules = new List<Vehicule>();
    private List<Inscription> inscriptions = new List<Inscription>();

    public Balade(int num, string lieuDepart, string dateDepart, float forfait)
    {
        this.num = num;
        this.lieuDepart = lieuDepart;
        this.dateDepart = dateDepart;
        this.forfait = forfait;
    }

    public Balade() { }

    public int Num
    {
        get { return num; }
        set { num = value; }
    }
    public string LieuDepart
    {
        get { return lieuDepart; }
        set { lieuDepart = value; }
    }
    public string DateDepart
    {
        get { return dateDepart; }
        set { dateDepart = value; }
    }
    public float Forfait
    {
        get { return forfait; }
        set { forfait = value; }
    }
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

    public List<Vehicule> Vehicules
    {
        get { return vehicules; }
        set { vehicules = value; }

    }
    public void AddVehicule(Vehicule vehicule)
    {
        this.vehicules.Add(vehicule);
    }
    public void RemoveVehicule(Vehicule vehicule)
    {
        this.vehicules.Remove(vehicule);
    }

    public void obtenirPlaceMembreTotal()
    {

    }

    public void obtenirPlaceMembreRestante()
    {

    }

    public void obtenirPlaceVeloTotal()
    {

    }

    public void obtenirPlaceVeloRestante()
    {

    }

    public void obtenirPlaceMembreBesoin()
    {

    }

    public void obtenirPlaceVeloBesoin()
    {

    }

    public void ajouterVehicule()
    {

    }
}
