using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

public abstract class DAO<T>
    {
    protected string connectionString = null;
    public DAO()
        {
        this.connectionString = ConfigurationManager.ConnectionStrings["cyclingDB"].ConnectionString;
    }
    Public abstract bool Create(T obj);
Public abstract bool Delete(T obj);
Public abstract bool Update(T obj);
Public abstract T Find(int id);
    }
