using CosmeticIngredientsCheck.DTOs;
using System.Collections.Generic;

namespace CosmeticIngredientsCheck.Models
{
    public class IngredientsCheckModel
    {
        public string IngredientsList { get; set; }
        public List<Verdict> VerdictList { get; set; }
        public List<Verdict> SkippedIngredientList { get; set; }
    }
}
