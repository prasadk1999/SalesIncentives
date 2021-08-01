using Microsoft.EntityFrameworkCore;
using SalesIncentives.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesIncentives
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
     
        }
        DbSet<Sales> Sales { get; set; }
    }
    
}
