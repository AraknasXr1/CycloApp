using System.Collections.Generic;
using System.Data.SqlClient;


public class CycloDAO : DAO<Cyclo>
{
    public CycloDAO() { }
    public override bool Create(Cyclo obj)
    {
        return false;
    }
    public override bool Delete(Cyclo obj)
    {
        return false;
    }
    public override bool Update(Cyclo obj)
    {
        return false;
    }
    public override Cyclo Find(int id)
    {
        Cyclo Cyclo = null;
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
                        Cyclo = new Cyclo
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
        return Cyclo;
    }
    public List<Cyclo> FindAll(Cyclo Cyclo)
    {
        List<Cyclo> Cyclos = new List<Cyclo>();
        try
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Category WHERE cat_cls_id =  @id", connection);
                cmd.Parameters.AddWithValue("id", Cyclo.Num);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Cyclo cyc = new Cyclo
                        {
                            /*num = reader.GetInt32("bld_id"),
                            lieuDepart = reader.GetString("bld_DeparturePlace"),
                            dateDepart = reader.GetString("bld_DepartureDate")
                            forfait = reader.GetFloat("bld_RidePrice")*/
                        };
                        Cyclos.Add(cyc);
                    }
                }
                connection.Close();
            }
        }
        catch (SqlException)
        {
            throw new System.Exception("Une erreur sql s'est produite!");
        }
        return Cyclos;
    }
}



