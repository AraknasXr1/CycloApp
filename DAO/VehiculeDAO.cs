using System.Collections.Generic;
using System.Data.SqlClient;
public class VehiculeDAO :  DAO<Vehicule>
    {
    public VehiculeDAO(){ }
        public override bool Create(Vehicule obj)
        {
            return false;
        }
public override bool Delete(Vehicule obj)
        {
        return false;
        }
public override bool Update(Vehicule obj)
        {
        return false;
        }
public override Vehicule Find(int id)
        {
            Vehicule Vehicule = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(this.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Car WHERE car_id = @id", connection);
                    cmd.Parameters.AddWithValue("id", id);
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Vehicule = new Vehicule
                            {
                                /*nbrePlacesMembre = reader.GetInt32("car_idcarclient"),
                                brePlacesVelo = reader.GetInt32("car_seat")*/
                            };
                        }
                    }
                }
            }
            catch (SqlException)
            {
                throw new System.Exception("Une erreur sql s'est produite!");
            }
            return Vehicule;
        }
    public List<Vehicule> FindAll(Vehicule Vehicule)
        {
            List<Vehicule> Vehicules = new List<Vehicule>();
            try
            {
                using (SqlConnection connection = new SqlConnection(this.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Car WHERE car_cls_id =  @id", connection);
                    cmd.Parameters.AddWithValue("id", Vehicule.NbrePlacesMembre);
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Vehicule car = new Vehicule
                            {
                                /*ID = reader.GetInt32("car_idcarclient"),
                                CarSeat = reader.GetInt32("car_seat"),
                                CarBike = reader.GetInt32("car_bike"),
                                CarBrand = reader.GetString("car_brand")*/
                            };
                            Vehicules.Add(car);
                        }
                    }
                }
            }
            catch (SqlException)
            {
                throw new System.Exception("Une erreur sql s'est produite!");
            }
            return Vehicules;
        }
    }
