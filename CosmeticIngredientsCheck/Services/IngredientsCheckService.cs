using CosmeticIngredientsCheck.Categorizers;
using CosmeticIngredientsCheck.DTOs;
using CosmeticIngredientsCheck.Models;
using System.Collections.Generic;

namespace CosmeticIngredientsCheck.Services
{
    public static class IngredientsCheckService
    {
        private static List<AbstractCategorizer> _categorizers;
        private static List<AbstractCategorizer> Categorizers
        {
            get
            {
                if (_categorizers == null)
                {
                    _categorizers = new List<AbstractCategorizer> { new FattyAcidCategorizer(), new EsterCategorizer(), new OtherCategorizer() };
                }

                return _categorizers;
            }
        }

        public static GetVerdictResult GetVerdict(string ingredientList)
        {
            var ingredientsSplit = SplitIntoIngredients(ingredientList);
            var detectedIngredients = new List<Verdict>();
            var exceptions = new List<Verdict>();
            for (var i = 0; i < ingredientsSplit.Length; i++)
            {
                var ingredient = ingredientsSplit[i].Trim();
                var verdict = CategorizeIngredient(ingredient, i, ingredientsSplit.Length);
                if (verdict.DetectedIngredientVerdict != null) detectedIngredients.Add(verdict.DetectedIngredientVerdict);
                if (verdict.SkippedIngredientsVerdict != null) exceptions.AddRange(verdict.SkippedIngredientsVerdict);
            }

            return new GetVerdictResult { DetectedIngredients = detectedIngredients, SkippedIngredients = exceptions };
        }

        private static CategorizeIngredientResult CategorizeIngredient(string ingredient, int index, int totalCount)
        {
            var exceptions = new List<Verdict>();
            foreach (var categorizer in Categorizers)
            {
                var verdict = categorizer.Categorize(ingredient, index, totalCount);
                if (verdict?.SkippedIngredientVerdict != null) exceptions.Add(verdict.SkippedIngredientVerdict);
                if (verdict?.DetectedIngredientVerdict != null) return new CategorizeIngredientResult { DetectedIngredientVerdict = verdict.DetectedIngredientVerdict, SkippedIngredientsVerdict = exceptions };
            }

            return new CategorizeIngredientResult { SkippedIngredientsVerdict = exceptions };
        }

        private static string[] SplitIntoIngredients(string ingredientList)
        {
            return ingredientList.Split(',');
        }
    }
}
