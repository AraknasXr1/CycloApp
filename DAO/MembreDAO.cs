using ProjectCyclistsWPF;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Windows;

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

    public bool Updatebyid(int id)
    {
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CyclingDB"].ConnectionString))
        {
            String updatembr = $"UPDATE dbo.CLIENTS SET WALLET = '0' WHERE IdClient = @id";
            SqlCommand sqlupdate = new SqlCommand(updatembr, connection);
            sqlupdate.CommandType = CommandType.Text;
            sqlupdate.Parameters.AddWithValue("@id", id);
            connection.Open();
            sqlupdate.ExecuteNonQuery();
            connection.Close();
        }
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
                    connection.Close();
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
    public List<Membre> FindListMembre(int id, List<Membre> Membres)
    {
        using (SqlConnection connection = new SqlConnection(this.connectionString))
        {
            try
            {
                SqlCommand cmd = new SqlCommand("select * from dbo.Clients", connection);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Membre mbr = new Membre(reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetInt32(0), reader.GetString(5), reader.GetInt32(6));
                        Membres.Add(mbr);
                    }
                }
            }
            catch (SqlException)
            {
                throw new System.Exception("Une erreur sql s'est produite!");
            }
            connection.Close();
        }
        return Membres;
    }
    public List<string> Findcat(int id)
    {
        List<string> cat = new List<string>();
        using (SqlConnection connection = new SqlConnection(this.connectionString))
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT cli.IdClient, Catname,IdCategory from Clients as cli left join LinkCat on Cli.IdClient = LinkCat.IdClient inner join Category on Category.IdCat = LinkCat.IdCategory where cli.IdClient = @id", connection);
                cmd.Parameters.AddWithValue("id", id);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cat.Add("Id:" + reader.GetInt32(2)+" "+reader.GetString(1));
                    }
                }
            }
            catch (SqlException)
            {
                throw new System.Exception("Une erreur sql s'est produite!");
            }
            connection.Close();
        }
        return cat;
    }
    public List<string> Findallcat()
    {
        List<string> cat = new List<string>();
        using (SqlConnection connection = new SqlConnection(this.connectionString))
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT Catname, IdCat from Category ", connection);

                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cat.Add("Id:" + reader.GetInt32(1) +" "+ reader.GetString(0));
                    }
                }
            }
            catch (SqlException)
            {
                throw new System.Exception("Une erreur sql s'est produite!");
            }
            connection.Close();
        }
        return cat;
    }
    public bool addcat(int idmembre, int idADD)
    {
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CyclingDB"].ConnectionString))
        {
            String insertcat = $"INSERT INTO LinkCat(IdClient,IdCategory) VALUES (@idmembre,@idADD)";
            SqlCommand sqlinsert = new SqlCommand(insertcat, connection);
            sqlinsert.CommandType = CommandType.Text;
            sqlinsert.Parameters.AddWithValue("@idmembre", idmembre);
            sqlinsert.Parameters.AddWithValue("@idADD", idADD);
            connection.Open();
            sqlinsert.ExecuteNonQuery();
            connection.Close();
        }
        MessageBox.Show("This Category is added");
        //update Clients set Clients.Wallet = Clients.Wallet + 20 where Clients.IdClient = 6
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CyclingDB"].ConnectionString))
        {
            connection.Open();
            String querymodifyclient = $"update Clients set Clients.Wallet = Clients.Wallet + 5 where Clients.IdClient = @idmembre";
            using (SqlCommand sqlcmdupdate = new SqlCommand(querymodifyclient, connection))
            {
                sqlcmdupdate.Parameters.AddWithValue("@idmembre", idmembre);
                int rows = sqlcmdupdate.ExecuteNonQuery();
                connection.Close();
            }
        }
        return true;
    }

    public bool delcat(int idmembre, int iddelete)
    {
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CyclingDB"].ConnectionString))
        {
            try
            {
                String deletebike = $"DELETE FROM LinkCat WHERE IdClient=@idmembre and IdCategory=@iddelete";
                SqlCommand sqldelete = new SqlCommand(deletebike, connection);
                connection.Open();
                sqldelete.Parameters.AddWithValue("@idmembre", idmembre);
                sqldelete.Parameters.AddWithValue("@iddelete", iddelete);
                sqldelete.ExecuteNonQuery();
                MessageBox.Show("Deleted your Cat with id number " + iddelete);
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return true;
        }

        
    }
}
