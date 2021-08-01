using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SalesIncentives.Models
{
    public class Sales
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name ="Sales Representative Name")]
        public string SalesRepName { get; set; }
        [Required]
        [Display(Name ="Sales Date")]
        public DateTime SalesDate { get; set; }
        [Required]
        [Display(Name ="Product Name")]
        public string ProductName { get; set; }
        [Required]
        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }
        [Required]
        [Display(Name = "Sales Value")]
        public double SalesValue { get; set; }

    }
}
