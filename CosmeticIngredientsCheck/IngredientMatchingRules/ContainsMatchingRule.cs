using System;
using System.Collections.Generic;

namespace CosmeticIngredientsCheck.IngredientMatchingRules
{
    public class ContainsMatchingRule : IIngredientMatchingRule
    {
        private readonly List<string> _strings;

        public ContainsMatchingRule(List<string> strings)
        {
            this._strings = strings;
        }

        public bool Matches(string ingredient)
        {
            foreach (var s in _strings)
            {
                if (ingredient.ToLower().Contains(s.ToLower())) return true;
            }

            return false;
        }
    }
}
