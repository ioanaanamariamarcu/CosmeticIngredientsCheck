using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CosmeticIngredientsCheck.Models;
using CosmeticIngredientsCheck.Services;

namespace CosmeticIngredientsCheck.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

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
                var model = new IngredientsCheckModel { IngredientsList = ingredientsList, VerdictList = IngredientsCheckService.GetVerdict(ingredientsList) };

                return View(model);
            }
            catch
            {
                return View();
            }
        }
    }
}
