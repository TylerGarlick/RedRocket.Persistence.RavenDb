using RedRocket.Persistence.Common;

namespace RedRocket.Persistence.RavenDb
{
    public interface IRavenRepository<T> : IRepository<T> where T : class
    {
        T FindWithKey(string id);
    }
}