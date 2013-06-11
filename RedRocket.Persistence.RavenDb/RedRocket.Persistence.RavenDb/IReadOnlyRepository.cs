using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Raven.Client;
using RedRocket.Persistence.Common;

namespace RedRocket.Persistence.RavenDb
{
    public interface IRavenDbReadOnlyRepository<T> : IReadOnlyRepository<T> where T : class
    {
        T FindWithKey<T>(string id);
        IEnumerable<T> All<T>(Expression<Func<T, object>> path);
        IDocumentSession Session { get; }
    }

    public interface IRavenDbRepository<T> : IRavenDbReadOnlyRepository<T>, IRepository<T> where T : class
    {

    }
}