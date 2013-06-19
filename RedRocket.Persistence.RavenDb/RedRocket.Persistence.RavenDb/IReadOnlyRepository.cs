using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Raven.Client;
using RedRocket.Utilities.Core.Validation;

namespace RedRocket.Persistence.RavenDb
{
    public interface IReadOnlyRepository<T> where T : class
    {
        IQueryable<T> All();
        IQueryable<T> Query(Func<T, bool> predicate);
        T FindWithKey(Expression<Func<T, bool>> predicate);
        T FindWithKey(string id);
        IEnumerable<T> All(Expression<Func<T, object>> path);
        IDocumentSession Session { get; }
    }

    public interface IRepository<T> : IReadOnlyRepository<T> where T : class
    {
        T Add(T entity);
        T Update(T entity);
        void Delete(T entity);

        IEnumerable<ObjectValidationError> Validate(T entity);
    }
}