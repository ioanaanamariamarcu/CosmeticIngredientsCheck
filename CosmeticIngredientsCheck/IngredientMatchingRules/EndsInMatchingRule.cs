using System.Collections.Generic;

namespace CosmeticIngredientsCheck.IngredientMatchingRules
{
    public class EndsInMatchingRule : IIngredientMatchingRule
    {
        private readonly List<string> _strings;

        public EndsInMatchingRule(List<string> strings)
        {
            _strings = strings;
        }
        public bool Matches(string ingredient)
        {
            foreach (var s in _strings)
            {
                if(ingredient.ToLower().EndsWith(s.ToLower())) return true;
            }

            return false;
        }
    }
}
