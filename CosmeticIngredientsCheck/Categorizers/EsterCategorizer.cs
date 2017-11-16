using CosmeticIngredientsCheck.DTOs;
using CosmeticIngredientsCheck.IngredientMatchingRules;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CosmeticIngredientsCheck.Categorizers
{
    public class EsterCategorizer : AbstractCategorizer
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
    { new Ingredient { Name = "Glyceryl Cocoate", Risk = Risk.High }, new List<IIngredientMatchingRule> { new ContainsMatchingRule(new List<string> { "glyceryl cocoate" }) } },
    { new Ingredient { Name = "Glyceryl Stearate", Risk = Risk.High }, new List<IIngredientMatchingRule> { new ContainsMatchingRule(new List<string> { "glyceryl stearate" }) } },
    { new Ingredient { Name = "Polyethylene Glycol Stearates", Risk = Risk.High, Details="Metabolized by all strains" }, new List<IIngredientMatchingRule> { new ContainsMatchingRule(new List<string> { "macrogol stearate", "polyoxylstearate", "polyoxyethylene stearate", "ethoxylated stearates" }), new RegexMatchingRule(new List<string>{ @"macrogol[- ]\d{2} stearate", @"polyethylene glycol[- ]\d{2} (hydroxy)?stearate", @"peg[- ]\d{2} (hydroxy)?stearate" }) } },
    { new Ingredient { Name = "Generic Stearate", Risk = Risk.High }, new List<IIngredientMatchingRule> { new EndsInMatchingRule(new List<string> { "stearate" })} },
    { new Ingredient { Name = "Generic Palmitate", Risk = Risk.High }, new List<IIngredientMatchingRule> { new EndsInMatchingRule(new List<string> { "palmitate" })} },
    { new Ingredient { Name = "Generic Myristate", Risk = Risk.High }, new List<IIngredientMatchingRule> { new EndsInMatchingRule(new List<string> { "myristate" })} },
    { new Ingredient { Name = "Generic Linoleate", Risk = Risk.High }, new List<IIngredientMatchingRule> { new EndsInMatchingRule(new List<string> { "linoleate" })} },
    { new Ingredient { Name = "Generic oleate", Risk = Risk.High }, new List<IIngredientMatchingRule> { new ContainsMatchingRule(new List<string> { "oleate" })} },
    { new Ingredient { Name = "Cetearyl Olivate", Risk = Risk.High, Details="The ester of cetearyl alcohol and the fatty acids derived from olive oil." }, new List<IIngredientMatchingRule> { new ContainsMatchingRule(new List<string> { "cetearyl olivate" })  } },
    { new Ingredient { Name = "Polysorbate 20", Risk = Risk.High, Details="Feeds malassezia" }, new List<IIngredientMatchingRule> { new ContainsMatchingRule(new List<string> { "polysorbate" })  } },
};
                }

                return _dictionary;
            }
        }
        private Dictionary<Ingredient, List<IIngredientMatchingRule>> _exceptions;
        private Dictionary<Ingredient, List<IIngredientMatchingRule>> Exceptions
        {
            get
            {
                if (_exceptions == null)
                {
                    _exceptions = new Dictionary<Ingredient, List<IIngredientMatchingRule>>
                    {
{ new Ingredient { Name = "Betaine Salicylate", Details = "BHA" }, new List<IIngredientMatchingRule> { new ContainsMatchingRule(new List<string> { "betaine salicylate"})} },
{ new Ingredient { Name = "Sodium cetearyl sulfate"}, new List<IIngredientMatchingRule> { new ContainsMatchingRule(new List<string> { "sodium cetearyl sulfate" })} },
{ new Ingredient { Name = "Sodium lauryl sulfate"}, new List<IIngredientMatchingRule> { new ContainsMatchingRule(new List<string> { "sodium lauryl sulfate" })} },
{ new Ingredient { Name = "Cetearyl alcohol"}, new List<IIngredientMatchingRule> { new ContainsMatchingRule(new List<string> { "cetearyl alcohol" })} },
{ new Ingredient { Name = "Steareth-21"}, new List<IIngredientMatchingRule> { new ContainsMatchingRule(new List<string> { "steareth", "brij" })} },
{ new Ingredient { Name = "Ceteareth"}, new List<IIngredientMatchingRule> { new ContainsMatchingRule(new List<string> { "ceteareth" })} },
{ new Ingredient { Name = "Tocopheryl acetate"}, new List<IIngredientMatchingRule> { new ContainsMatchingRule(new List<string> { "tocopheryl acetate" })} },
{ new Ingredient { Name = "sodium cocoyl glycinate"}, new List<IIngredientMatchingRule> { new ContainsMatchingRule(new List<string> { "sodium cocoyl glycinate" })} },
{ new Ingredient { Name = "Trimethylsiloxysilicate"}, new List<IIngredientMatchingRule> { new ContainsMatchingRule(new List<string> { "trimethylsiloxysilicate" })} },
{ new Ingredient { Name = "Magnesium Sulfate"}, new List<IIngredientMatchingRule> { new ContainsMatchingRule(new List<string> { "magnesium sulfate" })} },
{ new Ingredient { Name = "Sodium polyacrylate"}, new List<IIngredientMatchingRule> { new ContainsMatchingRule(new List<string> { "sodium polyacrylate" })} },
{ new Ingredient { Name = "Glyceryl caprylate"}, new List<IIngredientMatchingRule> { new ContainsMatchingRule(new List<string> { "glyceryl caprylate" })} },
{ new Ingredient { Name = "Ammonium glycyrrhizate"}, new List<IIngredientMatchingRule> { new ContainsMatchingRule(new List<string> { "ammonium glycyrrhizate" })} },
{ new Ingredient { Name = "Dipotassium Glycyrrhizate"}, new List<IIngredientMatchingRule> { new ContainsMatchingRule(new List<string> { "Dipotassium Glycyrrhizate" })} },
{ new Ingredient { Name = "Zinc gluconate"}, new List<IIngredientMatchingRule> { new ContainsMatchingRule(new List<string> { "zinc gluconate" })} },
{ new Ingredient { Name = "Ethylhexyl methoxycinnamate", Details = "Sunscreen" }, new List<IIngredientMatchingRule> { new ContainsMatchingRule(new List<string> { "ethylhexyl methoxycinnamate" })} },
{ new Ingredient { Name = "Octyl salicylate", Details="Sunscreen" }, new List<IIngredientMatchingRule> { new ContainsMatchingRule(new List<string> { "Octyl salicylate" , "ethylhexyl salicylate" }) } },
{ new Ingredient { Name = "Sodium hyaluronate"}, new List<IIngredientMatchingRule> { new RegexMatchingRule(new List<string> { @"^sodium \w*hyaluronate$" }) } },
{ new Ingredient { Name = "Generic hyaluronate"}, new List<IIngredientMatchingRule> { new EndsInMatchingRule(new List<string> { "hyaluronate" }) } },
{ new Ingredient { Name = "Generic citrate", Details = "Ester of citric acid" }, new List<IIngredientMatchingRule> { new EndsInMatchingRule(new List<string> { "citrate" }) } },
{ new Ingredient { Name = "Generic succinate", Details = "Ester of succinic acid"}, new List<IIngredientMatchingRule> { new EndsInMatchingRule(new List<string> { "succinate" }) } },
{ new Ingredient { Name = "Hydrogenated starch hydrolysate"}, new List<IIngredientMatchingRule> { new ContainsMatchingRule(new List<string> { "hydrogenated starch hydrolysate" }) } },
{ new Ingredient { Name = "Sodium Ascorbyl Phosphate", Details="Vitamin C" }, new List<IIngredientMatchingRule> { new ContainsMatchingRule(new List<string> { "Sodium Ascorbyl Phosphate" }) } },
{ new Ingredient { Name = "Snail secretion filtrate"}, new List<IIngredientMatchingRule> { new ContainsMatchingRule(new List<string> { "snail secretion filtrate" }) } },
{ new Ingredient { Name = "Isononyl Isononanoate"}, new List<IIngredientMatchingRule> { new ContainsMatchingRule(new List<string> { "isononyl isononanoate" }) } },
{ new Ingredient { Name = "TRIDECYL TRIMELLITATE"}, new List<IIngredientMatchingRule> { new ContainsMatchingRule(new List<string> { "TRIDECYL TRIMELLITATE" }) } },
{ new Ingredient { Name = "Alkyl Benzoate"}, new List<IIngredientMatchingRule> { new ContainsMatchingRule(new List<string> { "alkyl benzoate" }) } }
                   };
                }

                return _exceptions;
            }
        }
        public override IngredientClassEnum IngredientClass => IngredientClassEnum.Ester;

        public override CategorizeResult Categorize(string ingredient, int index, int totalCount)
        {
            // Exceptions should not appear
            foreach (var kvp in Exceptions)
            {
                foreach (var rule in kvp.Value)
                {
                    if (rule.Matches(ingredient))
                    {
                        return new CategorizeResult { SkippedIngredientVerdict = BuildVerdict(ingredient, index, totalCount, kvp.Key) };
                    }
                }
            }

            foreach (var kvp in Dictionary)
            {
                foreach (var rule in kvp.Value)
                {
                    if (rule.Matches(ingredient))
                    {
                        return new CategorizeResult { DetectedIngredientVerdict = BuildVerdict(ingredient, index, totalCount, kvp.Key) };
                    }
                }
            }

                // remove ending numbers, like in Polysorbate 20
                var regex = new Regex(@"[^a-zA-Z]+$");
                var withoutNumbers = regex.Replace(ingredient, string.Empty);

                if (EndsIn(withoutNumbers.ToLower(), "ate"))
                {
                    return new CategorizeResult { DetectedIngredientVerdict = new Verdict { Class = IngredientClass, Index = index, TotalNrOfIngredients = totalCount, Ingredient = ingredient, OriginalIngredient = ingredient } };
                }

            return new CategorizeResult();
        }

        private Verdict BuildVerdict(string ingredient, int index, int totalCount, Ingredient detectedIngredient)
        {
            return new Verdict
            {
                Class = IngredientClass,
                Index = index,
                TotalNrOfIngredients = totalCount,
                Ingredient = detectedIngredient.Name,
                OriginalIngredient = ingredient,
                Risk = detectedIngredient.Risk,
                Advice = detectedIngredient.Details
            };
        }

        private bool EndsIn(string ingredient, string suffix)
        {
            return ingredient.TrimEnd().EndsWith(suffix);
        }
    }
}
