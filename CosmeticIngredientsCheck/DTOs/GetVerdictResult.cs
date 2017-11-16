using System.Collections.Generic;

namespace CosmeticIngredientsCheck.DTOs
{
    public class GetVerdictResult
    {
        public List<Verdict> DetectedIngredients { get; set; }
        public List<Verdict> SkippedIngredients { get; set; }
    }
}
