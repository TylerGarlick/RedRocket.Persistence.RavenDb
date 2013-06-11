using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Raven.Client;

namespace RedRocket.Persistence.Common
{
    public partial interface IReadOnlyRepository<T>
    {
        T FindWithKey<T>(string id);
        IEnumerable<T> All<T>(Expression<Func<T, object>> path);
        IDocumentSession Session { get; }
    }
}