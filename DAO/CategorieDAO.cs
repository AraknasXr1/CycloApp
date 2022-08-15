using System.Collections.Generic;
using System.Data.SqlClient;


public class CategorieDAO : DAO<Categorie>
{
    public CategorieDAO() { }
    public override bool Create(Categorie obj)
    {
        return false;
    }
    public override bool Delete(Categorie obj)
    {
        return false;
    }
    public override bool Update(Categorie obj)
    {
        return false;
    }
    public override Categorie Find(int id)
    {
        Categorie Categorie = null;
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
                        Categorie = new Categorie
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
        return Categorie;
    }
    public List<Categorie> FindAll(Categorie Categorie)
    {
        List<Categorie> Categories = new List<Categorie>();
        try
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Clients WHERE cat_cls_id =  @id", connection);
                cmd.Parameters.AddWithValue("id", Categorie.Num);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Categorie categorie = new Categorie
                        {
                            /*num = reader.GetInt32("bld_id"),
                            lieuDepart = reader.GetString("bld_DeparturePlace"),
                            dateDepart = reader.GetString("bld_DepartureDate")
                            forfait = reader.GetFloat("bld_RidePrice")*/
                        };
                        Categorie cat = categorie;
                        Categories.Add(cat);
                    }
                }
            }
        }
        catch (SqlException)
        {
            throw new System.Exception("Une erreur sql s'est produite!");
        }
        return Categories;
    }
}
