using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Xml.Linq;

public class Membre : Personne
{
    private int ID;
    private int solde = 0;
    private List<Vehicule> vehicules = new List<Vehicule>();
    private List<Categorie> categories = new List<Categorie>();
    private List<Velo> velos = new List<Velo>();
    private List<Inscription> inscriptions = new List<Inscription>();
    private int notification=0;

    public Membre(string nom, string prenom, string tel, int id, string motdepasse, int solde)
    {
        this.nom = nom;
        this.prenom = prenom;
        this.tel = tel;
        this.id = id;
        motDePasse = motdepasse;
        this.solde = solde;
    }
    public override string ToString()
    {
        return "Membre: " + nom + " " + prenom +" "+ tel + " " + id + " " + motDePasse + " " + solde;
    }
    public Membre()
    {
    }
    public int Solde
    {
        get;
        set;
    }
    public int Notification
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

    public int Id { get; internal set; }

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