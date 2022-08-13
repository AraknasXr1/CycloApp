public class Inscription
{
    private bool passager;
    private bool velo;

    public Inscription() { }

    public Inscription(bool Passager, bool velo)
    {
        this.passager = Passager;
        this.velo = velo;
    }
    public bool Passager
    {
        get { return passager; }
        set { passager = value; }
    }
    public bool Velo
    {
        get { return velo; }
        set { velo = value; }
    }

}
