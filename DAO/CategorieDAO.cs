public Class CategorieDAO :      DAO<Categorie>
    {
        Public CategorieDAO(){ }
        Public override bool Create(Categorie obj)
        {
            Return False;
        }
        Public override bool Delete(Categorie obj)
        {
            Return False;
        }
        Public override bool Update(Categorie obj)
        {
            Return False;
        }
        Public override Categorie Find(int id)
        {
            Categorie Categorie = null;
            Try
            {
                Using (SqlConnection connection = New SqlConnection(this.connectionString))
                {
                    SqlCommand cmd = New SqlCommand("SELECT * FROM dbo.Category WHERE cat_id = @id", connection);
                    cmd.Parameters.AddWithValue("id", id);
                    connection.Open();
                    Using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        If (reader.Read())
                        {
                            Categorie = New Categorie
                            {
                                ID = reader.GetInt32("cat_id"),
                                CatName = reader.GetString("cat_name"),
                                IdCatResp = reader.GetInt32("cat_idcatresp")
                            };
                        }
                    }
                }
            }
            Catch (SqlException)
            {
                Throw New Exception("Une erreur sql s'est produite!");
            }
            Return Categorie;
        }
        Public List<Categorie> FindAll(Classe classe)
        {
            List<Categorie> Categories = New List<Eleve>();
            Try
            {
                Using (SqlConnection connection = New SqlConnection(this.connectionString))
                {
                    SqlCommand cmd = New SqlCommand("SELECT * FROM dbo.Category WHERE cat_cls_id =  @id", connection);
                    cmd.Parameters.AddWithValue("id", classe.ID);
                    connection.Open();
                    Using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        While (reader.Read())
                        {
                            Categorie cat = New Categorie
                            {
                                ID = reader.GetInt32("cat_id"),
                                CatName = reader.GetString("cat_name"),
                                IdCatResp = reader.GetInt32("cat_idcatresp")
                            };
                            Categories.Add(cat);
                        }
                    }
                }
            }
            Catch (SqlException)
            {
                Throw New Exception("Une erreur sql s'est produite!");
            }
            Return Categories;
        }
    }
