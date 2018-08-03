using COREMyCookBookAPI.Controllers;
using COREMyCookBookAPI.Models;
using COREMyCookBookAPI.Repositories;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace COREMyCookBookAPITest.Controllers.Recipes
{
    [TestFixture]
    public class ControllerTestBase
    {
        protected Mock<IRepository<Recipe>> _recipeRepositoryMock { get; set; }
        protected RecipesController _recipesController { get; set; }

        [SetUp]
        public void SetUp()
        {
            _recipeRepositoryMock = new Mock<IRepository<Recipe>>();
            _recipesController = new RecipesController(_recipeRepositoryMock.Object);
        }

        protected IEnumerable<Recipe> BuilderRecipes(int size)
        {
            var recipes = new List<Recipe>();
            for (var i = 0; i < size; i++)
            {
                recipes.Add(new Recipe());
            }

            return recipes;
        }
    }
}