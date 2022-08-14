Public abstract Class DAO<T>
    {
        Protected String connectionString = null;
        Public DAO()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["cyclingDB"].ConnectionString;
        }
        Public abstract bool Create(T obj);
        Public abstract bool Delete(T obj);
        Public abstract bool Update(T obj);
        Public abstract T Find(int id);
    }
