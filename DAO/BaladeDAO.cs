using System.Collections.Generic;
using System.Data.SqlClient;


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
                }
            }
            catch (SqlException)
            {
                throw new System.Exception("Une erreur sql s'est produite!");
            }
            return Balades;
        }
    }
