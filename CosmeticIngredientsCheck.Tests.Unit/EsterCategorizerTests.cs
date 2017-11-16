using CosmeticIngredientsCheck.Categorizers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CosmeticIngredientsCheck.Tests.Unit
{
    [TestClass]
    public class EsterCategorizerTests
    {
        private EsterCategorizer _sut;

        private void Initialize()
        {
            _sut = new EsterCategorizer();
        }
        [TestMethod]
        public void EsterCategorizerTests_WhenCategorizingRegexEster_ShouldMatch()
        {
            Initialize();
            var ingredient = @"Polyethylene Glycol 50 hydroxystearate";
            var result = _sut.Categorize(ingredient, 2, 50).DetectedIngredientVerdict;

            Assert.AreEqual(result.Ingredient, "Polyethylene Glycol Stearates");
            Assert.AreEqual(result.Risk, DTOs.Risk.High);
            Assert.AreEqual(result.TotalNrOfIngredients, 50);
            Assert.AreEqual(result.Index, 2);
        }
        [TestMethod]
        public void EsterCategorizerTests_WhenCategorizinPegRegexEster_ShouldMatch()
        {
            Initialize();
            var ingredient = @"PEG-30 stearate";
            var result = _sut.Categorize(ingredient, 2, 50).DetectedIngredientVerdict;

            Assert.AreEqual(result.Ingredient, "Polyethylene Glycol Stearates");
            Assert.AreEqual(result.Risk, DTOs.Risk.High);
            Assert.AreEqual(result.TotalNrOfIngredients, 50);
            Assert.AreEqual(result.Index, 2);
        }
    }
}
