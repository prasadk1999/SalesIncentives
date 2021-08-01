using SalesIncentives.Models.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace SalesIncentives.Models.Repository
{
    public class Repository<T>: IRepository<T> where T:class 
    {
        public readonly ApplicationDbContext _db;
        internal DbSet<T> _dbSet;
        public Repository(ApplicationDbContext db)
        {
            _db = db;
            this._dbSet = _db.Set<T>();
        }

        public IEnumerable<T> GetSalesRepData(Expression<Func<T, bool>> filter = null)
        {
            IQueryable<T> query = _dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return query.ToList();
        }
        //for autosuggestion
        public IEnumerable<T> GetNamesOfSalesRep(Expression<Func<T,bool>> condition=null)
        {
            IQueryable<T> query = _dbSet;
            if (condition != null)
            {
                query = query.Where(condition);
            }
            return query.ToList();
        }

    }
}
