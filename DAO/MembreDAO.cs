Public Class MembreDAO :  DAO<Membre>
    {
        Public MembreDAO(){ }
        Public override bool Create(Membre obj)
        {
            Return False;
        }
        Public override bool Delete(Membre obj)
        {
            Return False;
        }
        Public override bool Update(Membre obj)
        {
            Return False;
        }
        Public override Membre Find(int id)
        {
            Membre membre = null;
            Try
            {
                Using (SqlConnection connection = New SqlConnection(this.connectionString))
                {
                    SqlCommand cmd = New SqlCommand("SELECT * FROM dbo.Clients WHERE mbr_id = @id", connection);
                    cmd.Parameters.AddWithValue("id", id);
                    connection.Open();
                    Using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        If (reader.Read())
                        {
                            membre = New Membre
                            {
                                id = reader.GetInt32("mbr_id"),
                                nom = reader.GetString("mbr_firstname"),
                                prenom = reader.GetString("mbr_lastname")
                                tel = reader.GetString("mbr_tel")
                                motDePasse = reader.GetString("mbr_password")
                                solde = reader.GetFloat("mbr_wallet")
                            };
                        }
                    }
                }
            }
            Catch (SqlException)
            {
                Throw New Exception("Une erreur sql s'est produite!");
            }
            Return membre;
        }
        Public List<Membre> FindAll(Classe classe)
        {
            List<Membre> membres = New List<Membre>();
            Try
            {
                Using (SqlConnection connection = New SqlConnection(this.connectionString))
                {
                    SqlCommand cmd = New SqlCommand("SELECT * FROM dbo.Client WHERE mbr_cls_id =  @id", connection);
                    cmd.Parameters.AddWithValue("id", classe.ID);
                    connection.Open();
                    Using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        While (reader.Read())
                        {
                            Membre mbr = New Membre
                            {
                                id = reader.GetInt32("mbr_id"),
                                nom = reader.GetString("mbr_firstname"),
                                prenom = reader.GetString("mbr_lastname")
                                tel = reader.GetString("mbr_tel")
                                motDePasse = reader.GetString("mbr_password")
                                solde = reader.GetFloat("mbr_wallet")
                            };
                            membres.Add(mbr);
                        }
                    }
                }
            }
            Catch (SqlException)
            {
                Throw New Exception("Une erreur sql s'est produite!");
            }
            Return membres;
        }
    }
