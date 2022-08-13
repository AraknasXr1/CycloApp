using System.Collections.Generic;
public class Calendrier
{
    private List<Balade> balades = new List<Balade>();

    public Calendrier(List <Balade> balade)
    {
        this.Balades = balade;
    }

    public List<Balade> Balades
    {
        get { return balades; }
        set { balades = value; }
    }
    public void AddBalade(Balade balade)
    {
        this.balades.Add(balade);
    }
    public void RemoveBalade(Balade balade)
    {
        this.balades.Remove(balade);
    }

    public void ajouterBalade()
    {

    }
}