using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SalesIncentives.Models.ViewModel
{
    public class SalesRepVM
    {
        public int Id { get; set; }
        [Display(Name = "Sales Representative Name")]
        public string SalesRepName { get; set; }
        public List<string> Products  { get; set; }
        public List<double> SalesPerProduct { get; set; }
        public double TotalSales { get; set; }
        public double Incentive { get; set; }
    }
}
