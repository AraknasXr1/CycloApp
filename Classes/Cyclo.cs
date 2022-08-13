using System.Collections.Generic;

public class Cyclo : Categorie
{
    /*Pourquoi l'heritage de la classe Categorie*/
    public override int Num { get; set; }
    public override List<Membre> membres { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public override void AddMembre(Membre membre)
    {
        this.membres.Add(membre);
    }

    public override void RemoveMembre(Membre membre)
    {
        this.membres.Remove(membre);
    }
}