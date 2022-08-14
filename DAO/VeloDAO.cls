Public Class VeloDAO :  DAO<Velo>
    {
        Public VeloDAO(){ }
        Public override bool Create(Velo obj)
        {
            Return False;
        }
        Public override bool Delete(Velo obj)
        {
            Return False;
        }
        Public override bool Update(Velo obj)
        {
            Return False;
        }
        Public override Velo Find(int id)
        {
            Velo Velo = null;
            Try
            {
                Using (SqlConnection connection = New SqlConnection(this.connectionString))
                {
                    SqlCommand cmd = New SqlCommand("SELECT * FROM dbo.Bike WHERE bik_id = @id", connection);
                    cmd.Parameters.AddWithValue("id", id);
                    connection.Open();
                    Using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        If (reader.Read())
                        {
                            Velo = New Velo
                            {
                                ID = reader.GetInt32("bik_idbike"),
                                bikSeat = reader.GetInt32("bik_poids"),
                                bikBike = reader.GetInt32("bik_longueur"),
                                Type = reader.GetString("bik_type")
                            };
                        }
                    }
                }
            }
            bikch (SqlException)
            {
                Throw New Exception("Une erreur sql s'est produite!");
            }
            Return Velo;
        }
        Public List<Velo> FindAll(Classe classe)
        {
            List<Velo> Velos = New List<Eleve>();
            Try
            {
                Using (SqlConnection connection = New SqlConnection(this.connectionString))
                {
                    SqlCommand cmd = New SqlCommand("SELECT * FROM dbo.bik WHERE bik_cls_id =  @id", connection);
                    cmd.Parameters.AddWithValue("id", classe.ID);
                    connection.Open();
                    Using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        While (reader.Read())
                        {
                            Velo bik = New Velo
                            {
                                ID = reader.GetInt32("bik_idbike"),
                                bikSeat = reader.GetInt32("bik_poids"),
                                bikBike = reader.GetInt32("bik_longueur"),
                                Type = reader.GetString("bik_type")
                            };
                            Velos.Add(bik);
                        }
                    }
                }
            }
            bikch (SqlException)
            {
                Throw New Exception("Une erreur sql s'est produite!");
            }
            Return Velos;
        }
    }
