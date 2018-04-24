using AplikacjaWebowa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using AplikacjaWebowa.ViewModels;

namespace AplikacjaWebowa.Controllers
{
    public class RecipesController : Controller
    {
        Random rnd = new Random();
        private ApplicationDbContext _context;

        public RecipesController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Random()
        {
            //var recipe1 = new Recipe() {RecipeId=1, Title = "Burger", Description = "Podgrzej go napatelni a pozniej pomieszaj"};
            //var User = new User();
            //var randomRecipeViewModel = new RandomRecipeViewModel(){ recipe=recipe1, users=new List<User>() };

            var recipe = _context.Recipes.ToList();
            var random = rnd.Next(0, _context.Recipes.Count());


            return View(recipe.ElementAt(random));
        }

       

        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
            {
                pageIndex = 1;
            }

            if (String.IsNullOrWhiteSpace(sortBy))
            {
                sortBy = "Name";
            }

            return Content($"Page Index : {pageIndex} & SortBy: {sortBy}");
        }


        [Route("recipes/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {

            return Content(year + "/" + month);
        }

        public ActionResult List()
        {

            var recipes = _context.Recipes.ToList();
            var types = _context.RecipesTypes.ToList();

            if (recipes == null)
                return HttpNotFound();


            var recipeWithTypeModel = new RecipeWithTypeViewModel() { recipes = recipes, types = types };

            return View(recipeWithTypeModel);
        }


        public ActionResult Details(int id)
        {
            var recipe = _context.Recipes.SingleOrDefault(c => c.ID == id);

            if (recipe == null)
                return HttpNotFound();
            
            
            return View(recipe);
        }

        public ActionResult New()
        {
            var types = _context.RecipesTypes.ToList();
            var recipeWithType = new NewRecipeViewModel(){types=types};
            return View(recipeWithType);
        }

        [HttpPost]
        public ActionResult Save(Recipe recipe)
        {
            if (recipe.ID == 0)
            {
                _context.Recipes.Add(recipe);
            }
            else
            {
                var tempRecipe = _context.Recipes.SingleOrDefault(r => r.ID == recipe.ID);
                tempRecipe.Title = recipe.Title;
                tempRecipe.Description = recipe.Description;
                tempRecipe.RecipeTypeId = recipe.RecipeTypeId;
            }
            
            _context.SaveChanges();
            return RedirectToAction("List");
        }

        public ActionResult Edit(int id)
        {
            var recipe = _context.Recipes.SingleOrDefault(r=>r.ID==id);
            if (recipe == null)
                return HttpNotFound();

            var model = new NewRecipeViewModel {recipe = recipe, types = _context.RecipesTypes.ToList()};


            _context.SaveChanges();
            return View("New", model);
        }

        public ActionResult Delete(int id)
        {
            _context.Recipes.Where(r => r.ID == id).First();
            _context.Recipes.Remove(_context.Recipes.Find(id));
            _context.SaveChanges();
            var model = new RecipeWithTypeViewModel {  recipes = _context.Recipes.ToList(), types = _context.RecipesTypes.ToList() };

            return View("List", model);
        }

        public ActionResult Search(RecipeWithTypeViewModel recipeViewModel)
        {
        //    _context.Recipes.Where(r => r.ID == id).First();
        //    _context.Recipes.Remove(_context.Recipes.Find(id));
        //    _context.SaveChanges();
            
            List<Recipe> searchedRecipes = _context.Recipes.Where(r => r.Title.Contains(recipeViewModel.searchPhrase)).ToList();
            var model = new RecipeWithTypeViewModel { recipes = searchedRecipes, types = _context.RecipesTypes.ToList() };

            return View("List", model);
        }

    }


}