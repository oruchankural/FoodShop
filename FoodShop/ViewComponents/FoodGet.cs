using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using FoodShop.Repositories;

namespace FoodShop.ViewComponents
{
    public class FoodGet : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            FoodRepositories foodRepositories = new FoodRepositories();
            var foodlist = foodRepositories.TList();
            return View(foodlist);
        }
    }
}
