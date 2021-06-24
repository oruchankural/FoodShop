using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FoodShop.Repositories;
using FoodShop.Data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;

namespace FoodShop.Controllers
{
    public class FoodController : Controller
    {
        FoodRepositories foodRepositories = new FoodRepositories();
        Context c = new Context();
        public IActionResult Index(int page=1)
        {
            
            return View(foodRepositories.TList("Category").ToPagedList(page,3));
        }
        [HttpGet]
        public IActionResult FoodAdd()
        {
            List<SelectListItem> values = (from x in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()
                                           }).ToList();

            ViewBag.v1 = values;
       
            return View();
        }
        [HttpPost]
        public IActionResult FoodAdd(Food p)
        {
            foodRepositories.TAdd(p);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteFood(int id)
        {
            foodRepositories.TDelete(new Food { FoodID=id});
            return RedirectToAction("Index");
        }

        public IActionResult FoodGet(int id )
        {
            var x = foodRepositories.TGet(id);
            List<SelectListItem> values = (from y in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = y.CategoryName,
                                               Value = y.CategoryID.ToString()
                                           }).ToList();

            ViewBag.v1 = values;
            Food f = new Food()
            {
                FoodID = x.FoodID,
                CategoryID = x.CategoryID,
                Name = x.Name,
                Price = x.Price,
                Stock = x.Stock,
                Desc = x.Desc,
                ImageURL = x.ImageURL

            };
            return View(f);
        }
        [HttpPost]
        public IActionResult FoodUpadte(Food p)
        {
            var x = foodRepositories.TGet(p.FoodID);
            x.Name = p.Name;
            x.Stock = p.Stock;
            x.Price = p.Price;
            x.ImageURL = p.ImageURL;
            x.Desc = p.Desc;
            x.CategoryID = p.CategoryID;
            foodRepositories.TUpdate(x);
            return RedirectToAction("Index");

        }
    }
}