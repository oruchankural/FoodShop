using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodShop.Data.Models
{
    public class Food
    {
        public int FoodID { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }     
        public double Price { get; set; }
        public string ImageURL { get; set; }
        public int Stock { get; set; }
        //PK
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
    }
}
