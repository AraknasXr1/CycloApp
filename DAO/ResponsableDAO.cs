using ProjectCyclistsWPF;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public class ResponsableDAO : DAO<Responsable>
{

    public ResponsableDAO() { }
    public override bool Create(Responsable obj)
    {
        return false;
    }
    public override bool Delete(Responsable obj)
    {
        return false;
    }
    public override bool Update(Responsable obj)
    {
        return false;
    }
    
    public Responsable Findnamecat(int id)
    {
        Responsable Responsable = new Responsable();
        Responsable Responsable2 = new Responsable();
        int count = 0;
        using (SqlConnection connection = new SqlConnection(this.connectionString))
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                SqlCommand queryretrieveinfo = new SqlCommand("SELECT * FROM dbo.Category WHERE IdCatResp = @id", connection);
                queryretrieveinfo.Parameters.AddWithValue("id", id);

                using (SqlDataReader reader = queryretrieveinfo.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Responsable2.id = reader.GetInt32(2);
                        Responsable2.nom = reader.GetString(1);
                        count++;
                    }
                }
                connection.Close();
            }
            catch (SqlException)
            {
                throw new System.Exception("Une erreur sql s'est produite!");
            }
        }
        Responsable.id = Responsable2.id;
        return Responsable2;
    }
    public override Responsable Find(int id)
    {
        Responsable Responsable = new Responsable();
        Responsable Responsable2 = new Responsable();
        int count = 0;
        using (SqlConnection connection = new SqlConnection(this.connectionString))
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                SqlCommand queryretrieveinfo = new SqlCommand("SELECT * FROM dbo.Category WHERE IdCatResp = @id", connection);
                queryretrieveinfo.Parameters.AddWithValue("id", id);

                using (SqlDataReader reader = queryretrieveinfo.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Responsable2.id=reader.GetInt32(2);
                        
                        count++;
                    }
                }
                connection.Close();
            }
            catch (SqlException)
            {
                throw new System.Exception("Une erreur sql s'est produite!");
            }
        }
        Responsable.id = Responsable2.id;
        return Responsable;
    }

    public List<Responsable> FindAll(Responsable Responsable)
    {
        List<Responsable> Responsables = new List<Responsable>();
        try
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Clients WHERE bld_cls_id =  @id", connection);
                cmd.Parameters.AddWithValue("id", Responsable.nom);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Responsable resp = new Responsable
                        {
                            /*num = reader.GetInt32("bld_id"),
                            lieuDepart = reader.GetString("bld_DeparturePlace"),
                            dateDepart = reader.GetString("bld_DepartureDate")
                            forfait = reader.GetFloat("bld_RidePrice")*/
                        };
                        Responsables.Add(resp);
                    }
                }
                connection.Close();
            }

        }
        catch (SqlException)
        {
            throw new System.Exception("Une erreur sql s'est produite!");
        }
        return Responsables;
    }
}

