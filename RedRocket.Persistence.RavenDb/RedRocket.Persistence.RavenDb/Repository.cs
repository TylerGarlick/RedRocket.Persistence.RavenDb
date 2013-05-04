using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using Raven.Client;

namespace RedRocket.Persistence.RavenDb
{
    public interface IReadOnlyRepository<T>
    {
        IQueryable<T> All();
        IQueryable<T> Query(Func<T, bool> predicate);
        T FindWithKey(Expression<Func<T, bool>> predicate);
        T FindWithKey(string id);
    }

    public interface IRepository<T> : IReadOnlyRepository<T>
    {
        T Add(T entity);
        T Update(T entity);
        void Delete(T entity);
        IDocumentSession Session { get; }
    }

    public class RavenRepository<T> : IRepository<T>
    {
        public RavenRepository(ICurrentDocumentSession currentDocumentSession)
        {
            Session = currentDocumentSession.Session;
        }

        public IQueryable<T> All()
        {
            return Session.Query<T>();
        }

        public IQueryable<T> Query(Func<T, bool> predicate)
        {
            return All().Where(predicate).AsQueryable();
        }

        public T FindWithKey(Expression<Func<T, bool>> predicate)
        {
            return All().SingleOrDefault(predicate);
        }

        public T FindWithKey(string id)
        {
            return Session.Load<T>(id);
        }

        public T Add(T entity)
        {
            if (entity.IsObjectValid())
            {
                Session.Store(entity);
                Session.SaveChanges();
                return entity;
            }
            throw new Utilities.Core.Validation.ValidationException(entity.GetValidationErrors());
        }

        public T Update(T entity)
        {
            if (entity.IsObjectValid())
            {
                Session.SaveChanges();
                return entity;
            }
            throw new Utilities.Core.Validation.ValidationException(entity.GetValidationErrors());
        }

        public void Delete(T entity)
        {
            Session.Delete(entity);
            Session.SaveChanges();
        }

        public IDocumentSession Session { get; private set; }
    }
}
