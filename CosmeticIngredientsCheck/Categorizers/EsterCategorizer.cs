using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CosmeticIngredientsCheck.DTOs;

namespace CosmeticIngredientsCheck.Categorizers
{
    public class EsterCategorizer : AbstractCategorizer
    {
        public override IngredientClassEnum IngredientClass => IngredientClassEnum.Ester;

        public override Verdict Categorize(string ingredient, int index, int totalCount)
        {
            if (EndsIn(ingredient.ToLower(), "ate"))
            {
                return new Verdict { Class = IngredientClass, Index = index, TotalNrOfIngredients = totalCount, Ingredient = ingredient, OriginalIngredient = ingredient };
            }
            return null;
        }

        private bool EndsIn(string ingredient, string suffix)
        {
            return ingredient.TrimEnd().EndsWith(suffix);
        }
    }
}
