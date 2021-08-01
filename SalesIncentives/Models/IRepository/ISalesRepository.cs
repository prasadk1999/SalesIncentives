using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SalesIncentives.Models.IRepository
{
    public interface ISalesRepository:IRepository<Sales>
    {
        public void Update(Sales entity);
        public void Save();

        
    }
}
