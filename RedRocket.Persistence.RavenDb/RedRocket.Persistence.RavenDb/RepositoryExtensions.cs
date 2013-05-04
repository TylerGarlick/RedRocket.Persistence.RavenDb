using System;
using RedRocket.Persistence.Common;

namespace RedRocket.Persistence.RavenDb
{
    public static class RepositoryExtensions
    {
        public static T FindWithKey<T>(this IRepository<T> repository,  string id) where T : class
        {
            var ravenRepository = repository as RavenRepository<T>;
            if(ravenRepository == null)
                throw new NullReferenceException("Raven Repository was not properly setup.  Please check your wireup settings and try again.");
            
            return ravenRepository.Session.Load<T>(id);
        }
    }
}