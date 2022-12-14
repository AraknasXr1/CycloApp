using System.Collections.Generic;
using System.Windows.Documents;

public class Balade
{
    private int num =0;
    private string lieuDepart = "";
    private string dateDepart = "";
    private int forfait = 0;
    private int max = 0;
    private List<Vehicule> vehicules = new List<Vehicule>();
    private List<Inscription> inscriptions = new List<Inscription>();

    public override string ToString()
    {
        return "Id:" + num + " Dep:" + lieuDepart + " Date:" + dateDepart + " Price:" + forfait ;
    }


    public Balade(int num, string lieuDepart, string dateDepart, int forfait)
    {
        this.num = num;
        this.lieuDepart = lieuDepart;
        this.dateDepart = dateDepart;
        this.forfait = forfait;
    }

    public Balade(int num, string lieuDepart, string dateDepart, int forfait,int max)
    {
        this.num = num;
        this.lieuDepart = lieuDepart;
        this.dateDepart = dateDepart;
        this.forfait = forfait;
        this.max = max;
    }


    public Balade() { }

    public int Num
    {
        get;
        set;
    }
    public int Max
    {
        get;
        set;
    }
    public string LieuDepart
    {
        get;
        set;
    }
    public string DateDepart
    {
        get;
        set;
    }
    public int Forfait
    {
        get;
        set;
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
