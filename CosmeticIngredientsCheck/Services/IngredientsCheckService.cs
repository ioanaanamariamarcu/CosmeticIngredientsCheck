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
                    _categorizers = new List<AbstractCategorizer> { new FattyAcidCategorizer(), new EsterCategorizer(), new FermentCategorizer() };
                }

                return _categorizers;
            }
        }

        public static List<Verdict> GetVerdict(string ingredientList)
        {
            var ingredientsSplit = SplitIntoIngredients(ingredientList);
            var result = new List<Verdict>();
            for (var i = 0; i < ingredientsSplit.Length; i++)
            {
                var ingredient = ingredientsSplit[i].Trim();
                var verdict = CategorizeIngredient(ingredient, i, ingredientsSplit.Length);
                if (verdict == null) continue;
                result.Add(verdict);
            }

            return result;
        }

        private static Verdict CategorizeIngredient(string ingredient, int index, int totalCount)
        {
            foreach (var categorizer in Categorizers)
            {
                var verdict = categorizer.Categorize(ingredient, index, totalCount);
                if (verdict != null) return verdict;
            }

            return null;
        }

        private static string[] SplitIntoIngredients(string ingredientList)
        {
            return ingredientList.Split(',');
        }
    }
}
