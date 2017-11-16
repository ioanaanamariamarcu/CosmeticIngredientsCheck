using System.Collections.Generic;

namespace CosmeticIngredientsCheck.DTOs
{
    public class CategorizeResult
    {
        public Verdict DetectedIngredientVerdict { get; set; }
        public Verdict SkippedIngredientVerdict { get; set; }
    }
}
