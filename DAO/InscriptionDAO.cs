using System.Collections.Generic;
using System.Data.SqlClient;


public class InscriptionDAO : DAO<Inscription>
{
    public InscriptionDAO() { }
    public override bool Create(Inscription obj)
    {
        return false;
    }
    public override bool Delete(Inscription obj)
    {
        return false;
    }
    public override bool Update(Inscription obj)
    {
        return false;
    }
    public override Inscription Find(int id)
    {
        Inscription Inscription = null;
        try
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Inscription WHERE inscrip_id = @id", connection);
                cmd.Parameters.AddWithValue("id", id);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Inscription = new Inscription
                        {
                            /*num = reader.GetInt32("bld_id"),
                            lieuDepart = reader.GetString("bld_DeparturePlace"),
                            dateDepart = reader.GetString("bld_DepartureDate")
                            forfait = reader.GetFloat("bld_RidePrice")*/
                            /* Utiliser un createur d'objet a implementer dans Balade*/
                        };
                    }
                }
                connection.Close();
            }
        }
        catch (SqlException)
        {
            throw new System.Exception("Une erreur sql s'est produite!");
        }
        return Inscription;
    }
    public List<Inscription> FindAll(Inscription Inscription)
    {
        List<Inscription> Inscriptions = new List<Inscription>();
        try
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Clients WHERE inscrip_cls_id =  @id", connection);
                cmd.Parameters.AddWithValue("id", Inscription.Velo);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Inscription inscrip = new Inscription
                        {
                            /*num = reader.GetInt32("bld_id"),
                            lieuDepart = reader.GetString("bld_DeparturePlace"),
                            dateDepart = reader.GetString("bld_DepartureDate")
                            forfait = reader.GetFloat("bld_RidePrice")*/
                        };
                        Inscriptions.Add(inscrip);
                    }
                }
            }
        }
        catch (SqlException)
        {
            throw new System.Exception("Une erreur sql s'est produite!");
        }
        return Inscriptions;
    }
}
