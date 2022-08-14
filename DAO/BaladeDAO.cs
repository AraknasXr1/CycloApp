Public Class BaladeDAO :  DAO<Balade>
    {
        Public BaladeDAO(){ }
        Public override bool Create(Balade obj)
        {
            Return False;
        }
        Public override bool Delete(Balade obj)
        {
            Return False;
        }
        Public override bool Update(Balade obj)
        {
            Return False;
        }
        Public override Balade Find(int id)
        {
            Balade Balade = null;
            Try
            {
                Using (SqlConnection connection = New SqlConnection(this.connectionString))
                {
                    SqlCommand cmd = New SqlCommand("SELECT * FROM dbo.Ride WHERE bld_id = @id", connection);
                    cmd.Parameters.AddWithValue("id", id);
                    connection.Open();
                    Using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        If (reader.Read())
                        {
                            Balade = New Balade
                            {
                                num = reader.GetInt32("bld_id"),
                                lieuDepart = reader.GetString("bld_DeparturePlace"),
                                dateDepart = reader.GetString("bld_DepartureDate")
                                forfait = reader.GetFloat("bld_RidePrice")
                            };
                        }
                    }
                }
            }
            Catch (SqlException)
            {
                Throw New Exception("Une erreur sql s'est produite!");
            }
            Return Balade;
        }
        Public List<Balade> FindAll(Classe classe)
        {
            List<Balade> Balades = New List<Balade>();
            Try
            {
                Using (SqlConnection connection = New SqlConnection(this.connectionString))
                {
                    SqlCommand cmd = New SqlCommand("SELECT * FROM dbo.Clients WHERE bld_cls_id =  @id", connection);
                    cmd.Parameters.AddWithValue("id", classe.ID);
                    connection.Open();
                    Using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        While (reader.Read())
                        {
                            Balade bld = New Balade
                            {
                                num = reader.GetInt32("bld_id"),
                                lieuDepart = reader.GetString("bld_DeparturePlace"),
                                dateDepart = reader.GetString("bld_DepartureDate")
                                forfait = reader.GetFloat("bld_RidePrice")
                            };
                            Balades.Add(bld);
                        }
                    }
                }
            }
            Catch (SqlException)
            {
                Throw New Exception("Une erreur sql s'est produite!");
            }
            Return Balades;
        }
    }
