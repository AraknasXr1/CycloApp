using System.Collections.Generic;
using System.Data.SqlClient;


public class RandonneurDAO : DAO<Randonneur>
{
    public RandonneurDAO() { }
    public override bool Create(Randonneur obj)
    {
        return false;
    }
    public override bool Delete(Randonneur obj)
    {
        return false;
    }
    public override bool Update(Randonneur obj)
    {
        return false;
    }
    public override Randonneur Find(int id)
    {
        Randonneur Randonneur = null;
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
                        Randonneur = new Randonneur
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
        return Randonneur;
    }
    public List<Randonneur> FindAll(Randonneur Randonneur)
    {
        List<Randonneur> Randonneurs = new List<Randonneur>();
        try
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Category WHERE cat_cls_id =  @id", connection);
                cmd.Parameters.AddWithValue("id", Randonneur.Num);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Randonneur rdn = new Randonneur
                        {
                            /*num = reader.GetInt32("bld_id"),
                            lieuDepart = reader.GetString("bld_DeparturePlace"),
                            dateDepart = reader.GetString("bld_DepartureDate")
                            forfait = reader.GetFloat("bld_RidePrice")*/
                        };
                        Randonneurs.Add(rdn);
                    }
                }
            }
        }
        catch (SqlException)
        {
            throw new System.Exception("Une erreur sql s'est produite!");
        }
        return Randonneurs;
    }
}


