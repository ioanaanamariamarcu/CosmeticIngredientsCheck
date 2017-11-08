using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CosmeticIngredientsCheck.DTOs;
using CosmeticIngredientsCheck.IngredientMatchingRules;

namespace CosmeticIngredientsCheck.Categorizers
{
    public class FermentCategorizer : AbstractCategorizer
    {
        private Dictionary<Ingredient, List<IIngredientMatchingRule>> _dictionary;
        private Dictionary<Ingredient, List<IIngredientMatchingRule>> Dictionary
        {
            get
            {
                if (_dictionary == null)
                {

                    _dictionary = new Dictionary<Ingredient, List<IIngredientMatchingRule>>
{
    { new Ingredient { Name = "Galactomyces Ferment", Risk = Risk.High, Details = "Highly comedogenic for fungal acne." }, new List<IIngredientMatchingRule> { new ContainsMatchingRule(new List<string> { "galactomyces" }) } }
};
                }

                return _dictionary;
            }
        }
        public override IngredientClassEnum IngredientClass => IngredientClassEnum.Ferment;

        public override Verdict Categorize(string ingredient, int index, int totalCount)
        {
            foreach (var kvp in Dictionary)
            {
                foreach (var rule in kvp.Value)
                {
                    if (rule.Matches(ingredient)) return new Verdict
                    {
                        Class = IngredientClass,
                        Index = index,
                        TotalNrOfIngredients = totalCount,
                        Ingredient = kvp.Key.Name,
                        OriginalIngredient = ingredient,
                        Risk = kvp.Key.Risk,
                        Advice = kvp.Key.Details
                    };
                }
            }
            return null;
        }
    }
}
