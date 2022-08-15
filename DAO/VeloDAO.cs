using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

public class VeloDAO :  DAO<Velo>
    {
    public VeloDAO(){ }
    public override bool Create(Velo obj)
        {
            return false;
        }
    public override bool Delete(Velo obj)
        {
        int id = obj.Id;
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CyclingDB"].ConnectionString))
        {
            try
            {
                String deletebike = $"DELETE FROM Velo WHERE idvelo=@idvelo";
                SqlCommand sqldelete = new SqlCommand(deletebike, connection);
                connection.Open();
                sqldelete.Parameters.AddWithValue("@idvelo", id);
                sqldelete.ExecuteNonQuery();
                MessageBox.Show("Deleted your Bike with id number " + id);
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return false;
        }
    }

    public bool Create2(int idclient, int poids, string type, int longueur)
    {
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CyclingDB"].ConnectionString))
        {
            String insertcar = $"INSERT INTO Velo(poids,type,longueur,idclientref) VALUES (@poids,@type,@longueur,@idclientref)";
            SqlCommand sqlinsert = new SqlCommand(insertcar, connection);
            sqlinsert.CommandType = CommandType.Text;
            sqlinsert.Parameters.AddWithValue("@poids", poids);
            sqlinsert.Parameters.AddWithValue("@type", type);
            sqlinsert.Parameters.AddWithValue("@longueur", longueur);
            sqlinsert.Parameters.AddWithValue("@idclientref", idclient);
            connection.Open();
            sqlinsert.ExecuteNonQuery();
            connection.Close();
        }
        MessageBox.Show("This Bike was created");
        return false;
    }

    public override bool Update(Velo obj)
        {
        return false;
        }
    public override Velo Find(int id)
        {
            Velo Velo = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(this.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Bike WHERE bik_id = @id", connection);
                    cmd.Parameters.AddWithValue("id", id);
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Velo = new Velo
                            {
                                /*ID = reader.GetInt32("bik_idbike"),
                                bikSeat = reader.GetInt32("bik_poids"),
                                bikBike = reader.GetInt32("bik_longueur"),
                                Type = reader.GetString("bik_type")*/
                            };
                        }
                    }
                connection.Close();
            }
            }
            catch(SqlException)
            {
                throw new System.Exception("Une erreur sql s'est produite!");
            }
            return Velo;
        }
        public List<Velo> FindAll(Velo Velo)
        {
            List<Velo> Velos = new List<Velo>();
            try
            {
                using (SqlConnection connection = new SqlConnection(this.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.bik WHERE bik_cls_id =  @id", connection);
                    cmd.Parameters.AddWithValue("id", Velo.Longueur);
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Velo bik = new Velo
                            {
                                /*ID = reader.GetInt32("bik_idbike"),
                                bikSeat = reader.GetInt32("bik_poids"),
                                bikBike = reader.GetInt32("bik_longueur"),
                                Type = reader.GetString("bik_type")*/
                            };
                            Velos.Add(bik);
                        }
                    }
                connection.Close();
            }
            }
            catch (SqlException)
            {
                throw new System.Exception("Une erreur sql s'est produite!");
            }
            return Velos;
        }
    public List<Velo> FindListVelo(int id)
    {
        List<Velo> Velos= new List<Velo>();
        using (SqlConnection connection = new SqlConnection(this.connectionString))
        {
            try
            {
                SqlCommand cmd = new SqlCommand("select * from dbo.Velo WHERE idclientref = @id", connection);
                cmd.Parameters.AddWithValue("id", id);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //0(idvelo) , 1(poids) , 2(type), 3(longueur), 4(idclientref)
                        Velo vlo = new Velo(reader.GetInt32(0),reader.GetString(2), reader.GetInt32(1), reader.GetInt32(3));
                        Velos.Add(vlo);
                    }
                }
            }
            catch (SqlException)
            {
                throw new System.Exception("Une erreur sql s'est produite!");
            }
            connection.Close();
        }
        return Velos;
    }
}
