using System.Collections.Generic;
using System.Data.SqlClient;


public class TresorierDAO : DAO<Tresorier>
{
    public TresorierDAO() { }
    public override bool Create(Tresorier obj)
    {
        return false;
    }
    public override bool Delete(Tresorier obj)
    {
        return false;
    }
    public override bool Update(Tresorier obj)
    {
        return false;
    }
    public override Tresorier Find(int id)
    {
        Tresorier Tresorier = null;
        try
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Tresorier WHERE Tre_id = @id", connection);
                cmd.Parameters.AddWithValue("id", id);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Tresorier = new Tresorier
                        {
                            /*num = reader.GetInt32("bld_id"),
                            lieuDepart = reader.GetString("bld_DeparturePlace"),
                            dateDepart = reader.GetString("bld_DepartureDate")
                            forfait = reader.GetFloat("bld_RidePrice")*/
                            /* Utiliser un createur d'objet a implementer dans Balade*/
                        };
                    }
                }
            }
        }
        catch (SqlException)
        {
            throw new System.Exception("Une erreur sql s'est produite!");
        }
        return Tresorier;
    }
    /*Un seul trésorier*/
}

