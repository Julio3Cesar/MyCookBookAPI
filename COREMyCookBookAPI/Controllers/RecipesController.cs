using System;
using System.Collections.Generic;
using COREMyCookBookAPI.Models;
using COREMyCookBookAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace COREMyCookBookAPI.Controllers
{
    [Route("api/[controller]")]
    public class RecipesController : Controller
    {
        private IRepository<Recipe> _recipeRepository;

        public RecipesController(IRepository<Recipe> recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }

        // GET api/recipes
        [HttpGet]
        public IEnumerable<Recipe> Index()
        {
            return _recipeRepository.GetAll();
        }

        // GET api/recipes/:id
        [HttpGet]
        public Recipe Show(int id)
        {
            return _recipeRepository.GetById(id);
        }
    }
}
