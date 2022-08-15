using System.Collections.Generic;
using System.Data.SqlClient;


public class TrialisteDAO : DAO<Trialiste>
{
    public TrialisteDAO() { }
    public override bool Create(Trialiste obj)
    {
        return false;
    }
    public override bool Delete(Trialiste obj)
    {
        return false;
    }
    public override bool Update(Trialiste obj)
    {
        return false;
    }
    public override Trialiste Find(int id)
    {
        Trialiste Trialiste = null;
        try
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Category WHERE cat_id = @id", connection);
                cmd.Parameters.AddWithValue("id", id);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Trialiste = new Trialiste
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
        return Trialiste;
    }
    public List<Trialiste> FindAll(Trialiste Trialiste)
    {
        List<Trialiste> Trialistes = new List<Trialiste>();
        try
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Category WHERE cat_cls_id =  @id", connection);
                cmd.Parameters.AddWithValue("id", Trialiste.Num);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Trialiste tri = new Trialiste
                        {
                            /*num = reader.GetInt32("bld_id"),
                            lieuDepart = reader.GetString("bld_DeparturePlace"),
                            dateDepart = reader.GetString("bld_DepartureDate")
                            forfait = reader.GetFloat("bld_RidePrice")*/
                        };
                        Trialistes.Add(tri);
                    }
                }
            }
        }
        catch (SqlException)
        {
            throw new System.Exception("Une erreur sql s'est produite!");
        }
        return Trialistes;
    }
}




