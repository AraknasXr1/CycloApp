using System.Collections.Generic;
using System.Data.SqlClient;
public class VeloDAO :  DAO<Velo>
    {
    public VeloDAO(){ }
    public override bool Create(Velo obj)
        {
            return false;
        }
    public override bool Delete(Velo obj)
        {
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
                }
            }
            catch (SqlException)
            {
                throw new System.Exception("Une erreur sql s'est produite!");
            }
            return Velos;
        }
    }
