using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

public class VehiculeDAO :  DAO<Vehicule>
    {
    public VehiculeDAO(){ }
        public override bool Create(Vehicule obj)
        {
            return false;
        }
public override bool Delete(Vehicule obj)
        {
        int id = obj.Idvoiture;
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CyclingDB"].ConnectionString))
        {
            try
            {
                String deletebike = $"DELETE FROM Car WHERE idCar=@idvelo";
                SqlCommand sqldelete = new SqlCommand(deletebike, connection);
                connection.Open();
                sqldelete.Parameters.AddWithValue("@idvelo", id);
                sqldelete.ExecuteNonQuery();
                MessageBox.Show("Deleted your Car with id number " + id);
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
                connection.Close();
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
    public bool Create2(int idclient, int carseat, int carbike, string CarBrand)
    {
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CyclingDB"].ConnectionString))
        {
            String insertcar = $"INSERT INTO Car(IdCarClient,CarSeat,CarBike,CarBrand) VALUES (@poids,@type,@longueur,@idclientref)";
            SqlCommand sqlinsert = new SqlCommand(insertcar, connection);
            sqlinsert.CommandType = CommandType.Text;
            sqlinsert.Parameters.AddWithValue("@poids", idclient);
            sqlinsert.Parameters.AddWithValue("@type", carseat);
            sqlinsert.Parameters.AddWithValue("@longueur", carbike);
            sqlinsert.Parameters.AddWithValue("@idclientref", CarBrand);
            connection.Open();
            sqlinsert.ExecuteNonQuery();
            connection.Close();
        }
        MessageBox.Show("This Car is added");
        return false;
    }
    public List<Vehicule> FindListVehicule(int id)
    {
        List<Vehicule> Vehicules = new List<Vehicule>();
        using (SqlConnection connection = new SqlConnection(this.connectionString))
        {
            try
            {
                SqlCommand cmd = new SqlCommand("select * from dbo.Car WHERE IdCarClient = @id", connection);
                cmd.Parameters.AddWithValue("id", id);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //0(idvoiture) , 1(idclient) , 2(Carseat), 3(CarBike), 4(CarBrand)
                        Vehicule vlo = new Vehicule(reader.GetInt32(0), reader.GetInt32(2), reader.GetInt32(3), reader.GetString(4));
                        Vehicules.Add(vlo);
                    }
                }
            }
            catch (SqlException)
            {
                throw new System.Exception("Une erreur sql s'est produite!");
            }
            connection.Close();
        }
        return Vehicules;
    }
}
