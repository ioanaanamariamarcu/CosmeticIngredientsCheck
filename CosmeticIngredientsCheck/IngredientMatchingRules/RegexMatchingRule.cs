using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CosmeticIngredientsCheck.IngredientMatchingRules
{
    public class RegexMatchingRule : IIngredientMatchingRule
    {
        private readonly List<string> _strings;

        public RegexMatchingRule(List<string> strings)
        {
            _strings = strings;
        }
        public bool Matches(string ingredient)
        {
            foreach (var s in _strings)
            {
                var regex = new Regex(s);
                if (regex.IsMatch(ingredient.ToLower())) return true;
            }

            return false;
        }
    }
}
