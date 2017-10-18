namespace CosmeticIngredientsCheck.IngredientMatchingRules
{
    public interface IIngredientMatchingRule
    {
        bool Matches(string ingredient);
    }
}
