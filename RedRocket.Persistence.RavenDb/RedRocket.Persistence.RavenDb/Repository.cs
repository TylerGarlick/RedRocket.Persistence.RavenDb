﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Raven.Client;
using RedRocket.Persistence.Common;
using RedRocket.Utilities.Core.Validation;

namespace RedRocket.Persistence.RavenDb
{
    public class RavenRepository<T> : IRepository<T> where T : class
    {
        public RavenRepository(ICurrentSession currentSession)
        {
            Session = currentSession.Session;
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

        public T Add(T entity)
        {
            if (entity.IsObjectValid())
            {
                Session.Store(entity);
                Session.SaveChanges();
                return entity;
            }
            throw new ObjectValidationException(entity.GetValidationErrors());
        }

        public T Update(T entity)
        {
            if (entity.IsObjectValid())
            {
                Session.SaveChanges();
                return entity;
            }
            throw new ObjectValidationException(entity.GetValidationErrors());
        }

        public void Delete(T entity)
        {
            Session.Delete(entity);
            Session.SaveChanges();
        }

        public IEnumerable<ObjectValidationError> Validate(T entity)
        {
            return entity.GetValidationErrors();
        }

        public IDocumentSession Session { get; private set; }
    }
}
