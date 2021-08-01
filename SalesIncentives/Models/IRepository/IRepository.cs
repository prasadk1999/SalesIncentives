using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SalesIncentives.Models.IRepository
{
    public interface IRepository<T>
    {
        public IEnumerable<T> GetSalesRepData(Expression<Func<T, bool>> filter=null);
        public IEnumerable<T> GetNamesOfSalesRep(Expression<Func<T, bool>> filter=null);

    }
}
