using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SalesIncentives.Models;
using SalesIncentives.Models.IRepository;
using SalesIncentives.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SalesIncentives.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISalesRepository _sales;
        
        public HomeController(ISalesRepository sales)
        {
            _sales = sales;
            
        }

        public IActionResult Index(SalesRepVM saleRVM)
        {
            return View(saleRVM);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult GetRepData(SalesRepVM gsrVM)
        {
            var u1 = gsrVM.SalesRepName;
            SalesRepVM srVM = new();
            IEnumerable<Sales> u = _sales.GetSalesRepData(c => c.SalesRepName == gsrVM.SalesRepName);
           
            if (u.Count()>0)
            {
                srVM.Id = u.FirstOrDefault().Id;
                srVM.SalesRepName = u.FirstOrDefault().SalesRepName;
                srVM.Products = new List<string>();
                srVM.SalesPerProduct = new List<double>();
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
            //Populate Products and SalesperProduct List such that the product and its salesvalue is at same index
            foreach (var product in u)
            {
                if (srVM.Products.Contains(product.ProductName))
                {
                    srVM.SalesPerProduct[srVM.Products.IndexOf(product.ProductName)] += product.SalesValue;

                }
                else
                {
                    srVM.Products.Add(product.ProductName);
                    srVM.SalesPerProduct.Add(product.SalesValue);
                }
            }
            //Calculate Total Sales
            double total = 0.0;
            foreach (var salesValue in srVM.SalesPerProduct)
            {
                total += salesValue;
            }
            srVM.TotalSales = total;
            srVM.Incentive = 0.1 * srVM.TotalSales;
            return RedirectToAction("Index",srVM);
        }
        
        public IActionResult GetName(string str)
        {
            HashSet<string> sr_names = new();
            var u = _sales.GetNamesOfSalesRep(c => c.SalesRepName.StartsWith(str));
            foreach(var pro in u)
            {
                sr_names.Add(pro.SalesRepName);
            }
            return Json(new {s_r= sr_names.ToList() });
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
