using FlitBit.IoC;
using RedRocket.Persistence.Common;

namespace RedRocket.Persistence.RavenDb
{
    public static class RepositoryExtensions
    {
        public static T FindWithKey<T>(this IRepository<T> repository,  string id) where T : class
        {
            var currentSession = Create.New<ICurrentDocumentSession>();
            return currentSession.Session.Load<T>(id);
        }
    }
}