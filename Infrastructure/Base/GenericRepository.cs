﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Domain.Base;
using Domain.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Base
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected readonly DbSet<T> _dbset;
        protected IDbContext _db;

        protected GenericRepository(IDbContext context)
        {
            _db = context;
            _dbset = context.Set<T>();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _dbset.AsEnumerable();
        }

        public virtual T Find(object id)
        {
            return _dbset.Find(id);
        }

        public virtual IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            var query = _dbset.Where(predicate).AsEnumerable();
            return query;
        }

        public virtual IEnumerable<T> FindBy(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<T> query = _dbset;

            if (filter != null) query = query.Where(filter);

            foreach (var includeProperty in includeProperties.Split
                (new[] {','}, StringSplitOptions.RemoveEmptyEntries))
                query = query.Include(includeProperty);

            if (orderBy != null)
                return orderBy(query).ToList();
            return query.ToList();
        }

        public T FindFirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            var query = _dbset.FirstOrDefault(predicate);
            return query;
        }

        public virtual void Add(T entity)
        {
            _dbset.Add(entity);
        }

        public virtual void Delete(T entity)
        {
            _dbset.Remove(entity);
        }

        public virtual void Edit(T entity)
        {
            _db.SetModified(entity);
        }

        public virtual void DeleteRange(List<T> entities)
        {
            _dbset.RemoveRange(entities);
        }

        public virtual void AddRange(List<T> entities)
        {
            _dbset.AddRange(entities);
        }

        protected IQueryable<T> FindByAsQueryable(Expression<Func<T, bool>> predicate)
        {
            return _dbset.Where(predicate);
        }

        protected IQueryable<T> AsQueryable()
        {
            return _dbset.AsQueryable();
        }
    }
}