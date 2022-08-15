using ProjectCyclistsWPF;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


public class MembreDAO : DAO<Membre>
{
    public MembreDAO() { }
    public override bool Create(Membre obj)
    {
        return false;
    }
    public override bool Delete(Membre obj)
    {
        return false;
    }
    public override bool Update(Membre obj)
    {
        return false;
    }
    public override Membre Find(int id)
    {
        Membre Membre = null;
        try
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Clients WHERE bld_id = @id", connection);
                cmd.Parameters.AddWithValue("id", id);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Membre = new Membre
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
        return Membre;
    }

    public int Login(string login, string password)
    {
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CyclingDB"].ConnectionString))
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                String querylogin = "SELECT * FROM dbo.Clients WHERE ClientLogin like @ClientLogin AND Password like @Password";
                SqlCommand sqlcmdlogin = new SqlCommand(querylogin, connection);
                sqlcmdlogin.CommandType = CommandType.Text;
                sqlcmdlogin.Parameters.AddWithValue("@ClientLogin", login);
                sqlcmdlogin.Parameters.AddWithValue("@Password", password);
                int idclient = Convert.ToInt32(sqlcmdlogin.ExecuteScalar());
                if (idclient > 0)
                {
                    using (SqlDataReader reader = sqlcmdlogin.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            return idclient;                        
                        }
                    }
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                
            }
            finally
            {
                connection.Close();
            }
        }
        return 0;
    }
    public List<Membre> FindAll(Membre Membre)
    {
        List<Membre> Membres = new List<Membre>();
        try
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Clients WHERE bld_cls_id =  @id", connection);
                cmd.Parameters.AddWithValue("id", Membre.nom);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Membre bld = new Membre
                        {
                            /*num = reader.GetInt32("bld_id"),
                            lieuDepart = reader.GetString("bld_DeparturePlace"),
                            dateDepart = reader.GetString("bld_DepartureDate")
                            forfait = reader.GetFloat("bld_RidePrice")*/
                        };
                        Membres.Add(bld);
                    }
                }
            }
        }
        catch (SqlException)
        {
            throw new System.Exception("Une erreur sql s'est produite!");
        }
        return Membres;
    }
}
