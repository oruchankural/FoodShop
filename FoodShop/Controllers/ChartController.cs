using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodShop.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace FoodShop.Controllers
{
    public class ChartController : Controller
    {
        Context c = new Context();
        public IActionResult Index()
        {
            return View();
        }
      
        public IActionResult Index2()
        {
            return View();
        }

        public IActionResult VisualizeProductResult()
        {
            return Json(ProList());
        }
        public List<Chart> ProList()
        {
            List<Chart> cs = new List<Chart>();
            cs.Add(new Chart()
            {
                Proname = "Computer",
                Stock = 150
            });
            cs.Add(new Chart()
            {
                Proname = "LCD",
                Stock = 200
            });
            cs.Add(new Chart()
            {
                Proname = "Tablet",
                Stock = 100
            });
            return cs;
        }

        public IActionResult Index3()
        {
            var total = c.Foods.Select(x => x.Stock).Sum();
            ViewBag.total = total;
            return View();
        }
        public IActionResult VisualizeProductResult2()
        {
            return Json(FoodList()); 
        }
        public List<Chart2> FoodList()
        {
            List<Chart2> cs2 = new List<Chart2>();
            using(var c = new Context())
            {
                cs2 = c.Foods.Select(x => new Chart2
                {

                    Foodname = x.Name,
                    Stock = x.Stock
                }).ToList();
                return cs2;
            }
        }
        public IActionResult Statistics ()
        {
            var deger1 = c.Foods.Count();
            ViewBag.d1 = deger1;
            var deger2 = c.Categories.Count();
            ViewBag.d2 = deger2;
            var foid = c.Categories.Where(x => x.CategoryName == "Fruit").Select(y => y.CategoryID).FirstOrDefault();
            ViewBag.d = foid;

            var deger3 = c.Foods.Where(x => x.CategoryID == foid).Count();
            ViewBag.d3 = deger3;
            var deger4 = c.Foods.Where(x => x.CategoryID == c.Categories.Where(z => z.CategoryName == "Vegetables").Select(y => y.CategoryID).FirstOrDefault()).Count();
            ViewBag.d4 = deger4;
            var deger5 = c.Foods.Sum(x=>x.Stock);
            ViewBag.d5 = deger5;

            var deger6 = c.Foods.Where(x => x.CategoryID == c.Categories.Where(y => y.CategoryName == "Legumes").Select(z => z.CategoryID).FirstOrDefault()).Count();
            ViewBag.d6 = deger6;

            var deger7 = c.Foods.OrderByDescending(x => x.Stock).Select(y => y.Name).FirstOrDefault();
            ViewBag.d7 = deger7;

            var deger8 = c.Foods.Average(x => x.Price).ToString("0.00");
            ViewBag.d8 = deger8;
            return View();
        }
    }
}