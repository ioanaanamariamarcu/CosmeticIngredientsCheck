using CosmeticIngredientsCheck.DTOs;

namespace CosmeticIngredientsCheck.Categorizers
{
    public abstract class AbstractCategorizer
    {
        public abstract IngredientClassEnum IngredientClass { get; }
        public abstract CategorizeResult Categorize(string ingredient, int index, int totalCount);
    }
}
