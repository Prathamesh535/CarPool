using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IRepository<T> where T : class
    {
        public Task Add(T entity);
        public Task<ActionResult<IEnumerable<T>>> GetAll();
        public T GetOne(Expression<Func<T, bool>> predicate);
    }

}
