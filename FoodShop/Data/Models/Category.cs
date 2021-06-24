using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FoodShop.Data.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        [Required(ErrorMessage ="Category name is required!")]
        [StringLength(20,ErrorMessage ="4-20 lenght character is available", MinimumLength =4)]
        public string CategoryName { get; set; }
        public string CategoryDesc { get; set; }
        public bool Status { get; set; }
        //PK
        public List<Food> Foods { get; set; }
    }
}
