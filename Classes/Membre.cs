using System.Collections.Generic;
public class Membre : Personne
{
    private float solde = 0;
    private List<Vehicule> vehicules = new List<Vehicule>();
    private List<Categorie> categories = new List<Categorie>();
    private List<Velo> velos = new List<Velo>();
    private List<Inscription> inscriptions = new List<Inscription>();
   
    public float Solde
    {
        get { return solde; }
        set { solde = value; }
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
    public List<Categorie> Categories
    {
        get { return categories; }
        set { categories = value; }
    }
    public void AddCategorie(Categorie categorie)
    {
        this.categories.Add(categorie);
    }
    public void RemoveCategorie(Categorie categorie)
    {
        this.categories.Remove(categorie);
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
    public List<Velo> Velos
    {
        get { return velos; }
        set { velos = value; }
    }

    public override string nom { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    protected override string prenom { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    protected override string tel { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    protected override string id { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    protected override string motDePasse { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public void AddVelo(Velo velo)
    {
        this.velos.Add(velo);
    }
    public void RemoveVelo(Velo velo)
    {
        this.velos.Remove(velo);
    }
    public void calculSolde()
    {

    }
    public void verifierSolde()
    {
    }
}