using SalesIncentives.Models.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SalesIncentives.Models.Repository
{
    public class SalesRepository : Repository<Sales>, ISalesRepository
    {
        private new readonly ApplicationDbContext _db;
        public SalesRepository(ApplicationDbContext db):base(db)
        {
            _db = db;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Sales entity)
        {
            _db.Update(entity);
        }
    }
}
