using ProjectCyclistsWPF;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


public class MembreDAO : DAO<Membre>
{
    public Membre membre;
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
        Membre logmembre = new Membre();
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CyclingDB"].ConnectionString))
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                String queryretrieveinfo = "SELECT * FROM dbo.Clients WHERE IdClient = @id";
                SqlCommand sql = new SqlCommand(queryretrieveinfo, connection);
                sql.CommandType = CommandType.Text;
                sql.Parameters.AddWithValue("@id", id);
                int idclient = Convert.ToInt32(sql.ExecuteScalar());
                if (idclient > 0)
                {
                    using (SqlDataReader readclientinfo = sql.ExecuteReader())
                    {
                        while (readclientinfo.Read())
                        {
                          //0 = Id du membre , 1 = ClientLogin, 2 = Prenom, 3 = Nom , 4 = Telephone, 5 = Mot de Passe, 6 = Wallet(solde)
                           Membre logmembre2 = new Membre(readclientinfo.GetString(2), readclientinfo.GetString(3), readclientinfo.GetString(4),readclientinfo.GetInt32(0),readclientinfo.GetString(5), readclientinfo.GetInt32(6));
                            logmembre = logmembre2;
                        }
                    }
                }
                else
                {

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
        
        return logmembre;
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
