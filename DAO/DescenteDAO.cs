using System.Collections.Generic;
using System.Data.SqlClient;


public class DescenteDAO : DAO<Descente>
{
    public DescenteDAO() { }
    public override bool Create(Descente obj)
    {
        return false;
    }
    public override bool Delete(Descente obj)
    {
        return false;
    }
    public override bool Update(Descente obj)
    {
        return false;
    }
    public override Descente Find(int id)
    {
        Descente Descente = null;
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
                        Descente = new Descente
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
        return Descente;
    }
    public List<Descente> FindAll(Descente Descente)
    {
        List<Descente> Descentes = new List<Descente>();
        try
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Category WHERE cat_cls_id =  @id", connection);
                cmd.Parameters.AddWithValue("id", Descente.Num);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Descente dsc = new Descente
                        {
                            /*num = reader.GetInt32("bld_id"),
                            lieuDepart = reader.GetString("bld_DeparturePlace"),
                            dateDepart = reader.GetString("bld_DepartureDate")
                            forfait = reader.GetFloat("bld_RidePrice")*/
                        };
                        Descentes.Add(dsc);
                    }
                }
            }
        }
        catch (SqlException)
        {
            throw new System.Exception("Une erreur sql s'est produite!");
        }
        return Descentes;
    }
}

