using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public readonly CarPoolContext _context;
        protected DbSet<T> _dbSet;
        public Repository(CarPoolContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public Task Add(T entity)
        {

            _dbSet.Add(entity);
            _context.SaveChanges();
            return Task.CompletedTask;
        }
        public async Task<ActionResult<IEnumerable<T>>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }
        private IQueryable<T> GetQuery(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderExpression = null)
        {
            IQueryable<T> qry = _dbSet;
            if (predicate != null)
                qry = qry.Where(predicate);
            if (orderExpression != null)
                return orderExpression(qry);
            return qry;
        }

        public T GetOne(Expression<Func<T, bool>> predicate = null)
        {
            return GetQuery(predicate).FirstOrDefault();
        }
    }
}
