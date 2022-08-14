Public Class InscriptionDAO :  DAO<Inscription>
    {
    Public InscriptionDAO() { }
    Public override bool Create(Inscription obj)
    {
        Return False;
    }
    Public override bool Delete(Inscription obj)
    {
        Return False;
    }
    Public override bool Update(Inscription obj)
    {
        Return False;
    }
    Public override Inscription Find(int id)
    {
        Inscription Inscription = null;
        Try
            {
            Using(SqlConnection connection = New SqlConnection(this.connectionString))
                {
                SqlCommand cmd = New SqlCommand("SELECT * FROM dbo.Inscription WHERE inscrip_id = @id", connection);
                cmd.Parameters.AddWithValue("id", id);
                connection.Open();
                Using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                    If(reader.Read())
                        {
                        Inscription = New Inscription
                            {
                                id = reader.GetInt32("bld_id"),
                                passager = reader.GetBool("bld_passager"),
                                velo = reader.GetBool("bld_velo")
                            };
                    }
                }
            }
        }
        Catch(SqlException)
            {
            Throw New Exception("Une erreur sql s'est produite!");
        }
        Return Balade;
    }
    Public List<Inscription> FindAll(Classe classe)
        {
        List<Inscription> Inscriptions = New List<Inscription>();
        Try
            {
            Using(SqlConnection connection = New SqlConnection(this.connectionString))
                {
                SqlCommand cmd = New SqlCommand("SELECT * FROM dbo.Clients WHERE inscrip_cls_id =  @id", connection);
                cmd.Parameters.AddWithValue("id", classe.ID);
                connection.Open();
                Using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                    While(reader.Read())
                        {
                        Inscription bld = New Inscription
                            {
                                id = reader.GetInt32("bld_id"),
                                passager = reader.GetBool("bld_passager"),
                                velo = reader.GetBool("bld_velo")
                            };
                        Inscriptions.Add(bld);
                    }
                }
            }
        }
        Catch(SqlException)
            {
            Throw New Exception("Une erreur sql s'est produite!");
        }
        Return Inscriptions;
    }
}