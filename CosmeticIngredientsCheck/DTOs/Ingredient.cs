using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CosmeticIngredientsCheck.DTOs
{
    public class Ingredient
    {
        public string Name { get; set; }
        public string Details { get; set; }
        public Risk Risk { get; set; }
    }
}
