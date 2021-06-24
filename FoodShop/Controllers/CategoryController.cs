using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodShop.Repositories;
using Microsoft.AspNetCore.Mvc;
using FoodShop.Data.Models;
using Microsoft.AspNetCore.Authorization;

namespace FoodShop.Controllers
{
    
    public class CategoryController : Controller
    {
        CategoryRepository categoryRepository = new CategoryRepository();
  
        public IActionResult Index()
        {
         
            return View(categoryRepository.TList());
        }
        [HttpGet]
        public IActionResult CategoryAdd()
        { 
            return View();
        }
        [HttpPost]
        public IActionResult CategoryAdd(Category p)
        {
            if(!ModelState.IsValid)
            {
                return View("CategoryAdd");
            }
            p.Status = true;
            categoryRepository.TAdd(p);
            return RedirectToAction("Index");
        }
        public IActionResult CategoryGet(int id)
        {
            var x = categoryRepository.TGet(id);
            Category ct = new Category()
            {
                CategoryName=x.CategoryName,
                CategoryDesc=x.CategoryDesc,
                CategoryID=x.CategoryID
            };
            return View(ct);
        }
        [HttpPost]
        public IActionResult CategoryUpdate(Category p)
        {
            var x = categoryRepository.TGet(p.CategoryID);
            x.CategoryName = p.CategoryName;
            x.CategoryDesc = p.CategoryDesc;
            x.Status = true;
            categoryRepository.TUpdate(x);
            
            return RedirectToAction("Index");
        }
        public IActionResult CategoryDelete(int id)
        {
            var x = categoryRepository.TGet(id);
            x.Status = false;
            categoryRepository.TUpdate(x);
            return RedirectToAction("Index");
        }
    }
}