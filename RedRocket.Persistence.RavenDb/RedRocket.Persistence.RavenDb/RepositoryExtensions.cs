using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Raven.Client;
using RedRocket.Persistence.Common;

namespace RedRocket.Persistence.RavenDb
{
    public static class RepositoryExtensions
    {
        public static T FindWithKey<T>(this IReadOnlyRepository<T> repository, string id) where T : class
        {
            var ravenRepository = repository as RavenRepository<T>;
            if (ravenRepository == null)
                throw new NullReferenceException("Raven Repository was not properly setup.  Please check your wireup settings and try again.");

            return ravenRepository.Session.Load<T>(id);
        }


        public static IEnumerable<T> All<T>(this IReadOnlyRepository<T> repository, Expression<Func<T, object>> path) where T : class
        {
            var ravenRepository = repository as RavenRepository<T>;
            if (ravenRepository == null)
                throw new NullReferenceException("Raven Repository was not properly setup.  Please check your wireup settings and try again.");

            return ravenRepository.Session.Query<T>().Include(path);
        }

        public static IDocumentSession CurrentSession<T>(this IReadOnlyRepository<T> repository) where T : class
        {
            var ravenRepository = repository as RavenRepository<T>;
            if (ravenRepository == null)
                throw new NullReferenceException("Raven Repository was not properly setup.  Please check your wireup settings and try again.");

            return ravenRepository.Session;
        }
    }
}