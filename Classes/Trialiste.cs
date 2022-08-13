using System.Collections.Generic;

public class Trialiste : VTT
{



    public override List<Membre> membres { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public override int Num { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public override void AddMembre(Membre membre)
    {
        this.membres.Add(membre);
    }

    public override void RemoveMembre(Membre membre)
    {
        this.membres.Remove(membre);
    }
}

