using System.Collections.Generic;
using COREMyCookBookAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace COREMyCookBookAPI.Controllers
{
    [Route("api/[controller]")]
    public class RecipesController : Controller
    {
        private IRepository<Recipe> RecipeRepository;

        public RecipesController(IRepository<Recipe> recipeRepository)
        {
            RecipeRepository = recipeRepository;
        }

        // GET api/recipes
        [HttpGet]
        public IEnumerable<Recipe> Index()
        {
            return RecipeRepository.GetAll();
        }
    }
}
