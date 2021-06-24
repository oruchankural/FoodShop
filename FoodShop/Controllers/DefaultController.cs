using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FoodShop.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}