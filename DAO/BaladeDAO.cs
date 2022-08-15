using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.PortableExecutable;
using System.Windows.Documents;


public class BaladeDAO :  DAO<Balade>
    {
        public BaladeDAO(){ }
        public override bool Create(Balade obj)
        {
            return false;
        }
        public override bool Delete(Balade obj)
        {
            return false;
        }
        public override bool Update(Balade obj)
        {
            return false;
        }
        public override Balade Find(int id)
        {
            Balade Balade = null;
            try
            {
                using(SqlConnection connection = new SqlConnection(this.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Ride WHERE bld_id = @id", connection);
                    cmd.Parameters.AddWithValue("id", id);
                    connection.Open();
                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if(reader.Read())
                        {
                            Balade = new Balade
                            {
                                /*num = reader.GetInt32("bld_id"),
                                lieuDepart = reader.GetString("bld_DeparturePlace"),
                                dateDepart = reader.GetString("bld_DepartureDate")
                                forfait = reader.GetFloat("bld_RidePrice")*/
                                /* Utiliser un createur d'objet a implementer dans Balade*/
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
        
        return Balade;
        }
        public List<Balade> FindAll(Balade Balade)
        {
            List<Balade> Balades = new List<Balade>();
            try
            {
                using(SqlConnection connection = new SqlConnection(this.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Clients WHERE bld_cls_id =  @id", connection);
                    cmd.Parameters.AddWithValue("id", Balade.Num);
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Balade bld = new Balade
                            {
                                /*num = reader.GetInt32("bld_id"),
                                lieuDepart = reader.GetString("bld_DeparturePlace"),
                                dateDepart = reader.GetString("bld_DepartureDate")
                                forfait = reader.GetFloat("bld_RidePrice")*/
                            };
                            Balades.Add(bld);
                        }
                    }
                connection.Close();
            }
            }
            catch (SqlException)
            {
                throw new System.Exception("Une erreur sql s'est produite!");
            }
            return Balades;
        }

    public List<Balade> FindListBalade(int id, List<Balade> Balades)
    {
        using (SqlConnection connection = new SqlConnection(this.connectionString))
        {
            try
            {

                   

                SqlCommand cmd = new SqlCommand("select * from dbo.Ride as r inner join dbo.Category as c on r.IdCatRide = c.IdCat WHERE IdCatRide = @id", connection);
                cmd.Parameters.AddWithValue("id", id);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Balade bld = new Balade(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(5));
                        Balades.Add(bld);
                    }
                }
            }
            catch (SqlException)
            {
                throw new System.Exception("Une erreur sql s'est produite!");
            }
            connection.Close();
        }
        return Balades;
    }
    public string finddepartureplace(int id)
    {
        string depplace2="";
        using (SqlConnection connection = new SqlConnection(this.connectionString))
        {
            try
            {



                SqlCommand cmd = new SqlCommand("select * from dbo.Ride as r inner join dbo.Category as c on r.IdCatRide = c.IdCat WHERE IdCatRide = @id", connection);
                cmd.Parameters.AddWithValue("id", id);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string depplace1 = reader.GetString(1);
                        depplace2 = depplace1;
                    }
                }
            }
            catch (SqlException)
            {
                throw new System.Exception("Une erreur sql s'est produite!");
            }
            connection.Close();
        }
        return depplace2;
    }
}
