namespace CosmeticIngredientsCheck.DTOs
{
    public class Verdict
    {
        public string Ingredient { get; set; }
        public IngredientClassEnum Class { get; set; }
        public int Index { get; set; }
        public int TotalNrOfIngredients { get; set; }
        public string OriginalIngredient { get; set; }
        public Risk Risk { get; set; }
        public string Advice { get; set; }
    }
}
