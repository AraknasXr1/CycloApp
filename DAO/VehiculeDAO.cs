Public Class VehiculeDAO :  DAO<Vehicule>
    {
        Public VehiculeDAO(){ }
        Public override bool Create(Vehicule obj)
        {
            Return False;
        }
        Public override bool Delete(Vehicule obj)
        {
            Return False;
        }
        Public override bool Update(Vehicule obj)
        {
            Return False;
        }
        Public override Vehicule Find(int id)
        {
            Vehicule Vehicule = null;
            Try
            {
                Using (SqlConnection connection = New SqlConnection(this.connectionString))
                {
                    SqlCommand cmd = New SqlCommand("SELECT * FROM dbo.Car WHERE car_id = @id", connection);
                    cmd.Parameters.AddWithValue("id", id);
                    connection.Open();
                    Using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        If (reader.Read())
                        {
                            Vehicule = New Vehicule
                            {
                                nbrePlacesMembre = reader.GetInt32("car_idcarclient"),
                                brePlacesVelo = reader.GetInt32("car_seat")
                            };
                        }
                    }
                }
            }
            carch (SqlException)
            {
                Throw New Exception("Une erreur sql s'est produite!");
            }
            Return Vehicule;
        }
        Public List<Vehicule> FindAll(Classe classe)
        {
            List<Vehicule> Vehicules = New List<Eleve>();
            Try
            {
                Using (SqlConnection connection = New SqlConnection(this.connectionString))
                {
                    SqlCommand cmd = New SqlCommand("SELECT * FROM dbo.Car WHERE car_cls_id =  @id", connection);
                    cmd.Parameters.AddWithValue("id", classe.ID);
                    connection.Open();
                    Using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        While (reader.Read())
                        {
                            Vehicule car = New Vehicule
                            {
                                ID = reader.GetInt32("car_idcarclient"),
                                CarSeat = reader.GetInt32("car_seat"),
                                CarBike = reader.GetInt32("car_bike"),
                                CarBrand = reader.GetString("car_brand")
                            };
                            Vehicules.Add(car);
                        }
                    }
                }
            }
            carch (SqlException)
            {
                Throw New Exception("Une erreur sql s'est produite!");
            }
            Return Vehicules;
        }
    }
