using System.Collections.Generic;
abstract public class Categorie
{
    public abstract int Num
    {
        get; 
        set; 
    }
    public abstract List<Membre> membres
    {
        get;
        set;
    }

    public abstract void AddMembre(Membre membre);
    public abstract void RemoveMembre(Membre membre);
    
   
}
