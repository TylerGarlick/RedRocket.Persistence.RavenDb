namespace RedRocket.Persistence.RavenDb
{
    public partial interface IRepository<T> where T : class
    {
        T FindWithKey(string id);
    }
}