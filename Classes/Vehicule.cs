using System.Collections.Generic;
public class Vehicule
{
    private int nbrePlacesMembre  = 0;
    private int nbrePlacesVelo = 0;
    private List<Velo> velos = new List<Velo>();
    private List<Membre> membres = new List<Membre>();
    public Vehicule(int nbrePlacesMembre, int nbrePlacesVelo)
    {
        this.nbrePlacesMembre = nbrePlacesMembre;
        this.nbrePlacesVelo = nbrePlacesVelo;

    }
    public Vehicule() { }

    public int NbrePlacesMembre
    {
        get { return nbrePlacesMembre; }
        set { nbrePlacesMembre = value; }
    }
    public int NbrePlacesVelo
    {
        get { return nbrePlacesVelo; }
        set { nbrePlacesVelo = value; }
    }

    public List<Velo> Velos
    {
        get { return velos; }
        set { velos = value; }
    }

    public void AddVelo(Velo velo)
    {
        this.velos.Add(velo);
    }

    public void RemoveVelo(Velo velo)
    {
        this.velos.Remove(velo);
    }
    public List<Membre> Membres
    {
        get { return membres; }
        set { membres = value; }
    }

    public void AddMembre(Membre membre)
    {
        this.membres.Add(membre);
    }

    public void RemoveMembre(Membre membre)
    {
        this.membres.Remove(membre);
    }
    public void ajouterPassager()
    {

    }
    public void ajouterVelo()
    {

    }

    

}
