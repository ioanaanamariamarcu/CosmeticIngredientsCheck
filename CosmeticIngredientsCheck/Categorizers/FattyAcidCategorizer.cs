using System.Collections.Generic;
using CosmeticIngredientsCheck.IngredientMatchingRules;
using CosmeticIngredientsCheck.DTOs;

namespace CosmeticIngredientsCheck.Categorizers
{
    public class FattyAcidCategorizer : AbstractCategorizer
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
    { new Ingredient { Name = "Undecylic Acid (C11)", Risk = Risk.High }, new List<IIngredientMatchingRule> { new ContainsMatchingRule(new List<string> { "undecylic", "undecanoic" }) } },
    { new Ingredient { Name =  "Lauric / Dodecanoic (C12)", Risk = Risk.High }, new List<IIngredientMatchingRule> { new ContainsMatchingRule(new List<string> { "lauric", "dodecanoic" }) } },
    { new Ingredient { Name =  "Tridecylic (C13)", Risk = Risk.High }, new List<IIngredientMatchingRule> { new ContainsMatchingRule(new List<string> { "tridecylic" }) } },
    { new Ingredient { Name =  "Myristic / Tetradecanoic (C14)", Risk = Risk.High }, new List<IIngredientMatchingRule> { new ContainsMatchingRule(new List<string> { "myristic", "tetradecanoic" }) } },
    { new Ingredient { Name =  "Pentadecanoic (C15)", Risk = Risk.High }, new List<IIngredientMatchingRule> { new ContainsMatchingRule(new List<string> { "pentadecanoic" }) } },
    { new Ingredient { Name =  "Palmitic / Hexadecanoic (C16)", Risk = Risk.High }, new List<IIngredientMatchingRule> { new ContainsMatchingRule(new List<string> { "palmitoleic", "hexadecanoic" }) } },
    { new Ingredient { Name =  "Palmitoleic / Hexadecanoic (C16:1)", Risk = Risk.High }, new List<IIngredientMatchingRule> { new ContainsMatchingRule(new List<string> { "palmitoleic" }) } },
    { new Ingredient { Name =  "Margaric / Heptadecanoic (C17)", Risk = Risk.High }, new List<IIngredientMatchingRule> { new ContainsMatchingRule(new List<string> { "margaric", "heptadecanoic" }) } },
    { new Ingredient { Name =  "Stearic / Octadecanoic (C18)", Risk = Risk.High }, new List<IIngredientMatchingRule> { new ContainsMatchingRule(new List<string> { "stearic", "octadecanoic" }) } },
    { new Ingredient { Name =  "Oleic / Octadecanoic (C18:1)", Risk = Risk.High }, new List<IIngredientMatchingRule> { new ContainsMatchingRule(new List<string> { "oleic" }) } },
    { new Ingredient { Name =  "α-Linolenic (C18:3)", Risk = Risk.High }, new List<IIngredientMatchingRule> { new ContainsMatchingRule(new List<string> { "alpha linoleic" }) } },
    { new Ingredient { Name =  "Linoleic (C18:2)", Risk = Risk.High }, new List<IIngredientMatchingRule> { new ContainsMatchingRule(new List<string> { "linoleic" }) } },
    { new Ingredient { Name =  "Nonadecylic (C19)", Risk = Risk.High }, new List<IIngredientMatchingRule> { new ContainsMatchingRule(new List<string> { "nonadecylic", "nonadecanoic" }) } },
    { new Ingredient { Name =  "Arachidic / Eicosanoic (C20)", Risk = Risk.High }, new List<IIngredientMatchingRule> { new ContainsMatchingRule(new List<string> { "arachidic", "eicosanoic" }) } },
    { new Ingredient { Name =  "Heneicosylic (C21)", Risk = Risk.High }, new List<IIngredientMatchingRule> { new ContainsMatchingRule(new List<string> { "heneicosylic", "heneicosanoic" }) } },
    { new Ingredient { Name =  "Behenic / Docosanoic (C22)", Risk = Risk.High }, new List<IIngredientMatchingRule> { new ContainsMatchingRule(new List<string> { "behenic", "docosanoic" }) } },
    { new Ingredient { Name =  "Tricosylic (C23)", Risk = Risk.High }, new List<IIngredientMatchingRule> { new ContainsMatchingRule(new List<string> { "tricosylic", "tricosanoic" }) } },
    { new Ingredient { Name =  "Lignoceric / Tetracosanoic (C24)", Risk = Risk.High }, new List<IIngredientMatchingRule> { new ContainsMatchingRule(new List<string> { "lignoceric", "tetracosanoic" }) } }
};
}

                return _dictionary;
            }
        }
        public override IngredientClassEnum IngredientClass => IngredientClassEnum.FattyAcid;

        public override Verdict Categorize(string ingredient, int index, int totalCount)
        {
            foreach (var kvp in Dictionary)
            {
                foreach (var rule in kvp.Value)
                {
                    if (rule.Matches(ingredient)) return new Verdict {
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
