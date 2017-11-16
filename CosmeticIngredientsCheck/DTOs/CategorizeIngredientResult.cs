using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CosmeticIngredientsCheck.DTOs
{
    public class CategorizeIngredientResult
    {
        public Verdict DetectedIngredientVerdict { get; set; }
        public List<Verdict> SkippedIngredientsVerdict { get; set; }
    }
}
