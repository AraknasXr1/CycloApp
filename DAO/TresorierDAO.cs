using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


public class TresorierDAO : DAO<Tresorier>
{
    public TresorierDAO() { }
    public override bool Create(Tresorier obj)
    {
        /*Tresorier tr = new Tresorier();
        tr.reclamerForfait();*/
        return false;
    }
    public override bool Delete(Tresorier obj)
    {
        return false;
    }
    public override bool Update(Tresorier obj)
    {
        return false;
    }

    
    
    public override Tresorier Find(int id)
    {
        Tresorier Tresorier = new Tresorier();
        int count = 0;
        using (SqlConnection connection = new SqlConnection(this.connectionString))
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                SqlCommand queryretrieveinfo = new SqlCommand("SELECT * FROM dbo.Tresorier WHERE IdCliTreso = @id", connection);
                queryretrieveinfo.Parameters.AddWithValue("id", id);

                using (SqlDataReader reader = queryretrieveinfo.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        count++;
                    }
                }
            }
            catch (SqlException)
            {
                throw new System.Exception("Une erreur sql s'est produite!");
            }
            connection.Close();
        }
        Tresorier.id = count;
        return Tresorier;
    }
    /*Un seul trésorier*/
}

