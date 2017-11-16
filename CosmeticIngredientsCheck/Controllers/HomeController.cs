using Microsoft.AspNetCore.Mvc;
using CosmeticIngredientsCheck.Models;
using CosmeticIngredientsCheck.Services;

namespace CosmeticIngredientsCheck.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult IngredientsCheck()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult IngredientsCheck(string ingredientsList)
        {
            try
            {
                var serviceVerdict = IngredientsCheckService.GetVerdict(ingredientsList);
                var model = new IngredientsCheckModel
                {
                    IngredientsList = ingredientsList,
                    VerdictList = serviceVerdict.DetectedIngredients,
                    SkippedIngredientList = serviceVerdict.SkippedIngredients
                };

                return View(model);
            }
            catch
            {
                return View();
            }
        }
    }
}
