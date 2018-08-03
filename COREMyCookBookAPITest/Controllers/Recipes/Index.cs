using COREMyCookBookAPI;
using COREMyCookBookAPI.Controllers;
using COREMyCookBookAPI.Models;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace COREMyCookBookAPITest.Controllers.Recipes
{
    public class Index : ControllerTestBase
    {
        [Test]
        public void ShouldReturnSomeRecipeWhenInvokeIndexMethodAndRepositoryReturnSomeRecipe()
        {
            var size = 2;
            _recipeRepositoryMock.Setup(c => c.GetAll())
                .Returns(BuilderRecipes(size).AsQueryable());

            var recipes = _recipesController.Index();

            Assert.AreEqual(size, recipes.Count());
        }

        [Test]
        public void ShouldReturnNoneRecipeWhenInvokeIndexMethodAndRepositoryReturnNoneRecipe()
        {
            var size = 0;
            _recipeRepositoryMock.Setup(c => c.GetAll())
                .Returns(BuilderRecipes(size).AsQueryable());

            var recipes = _recipesController.Index();

            Assert.AreEqual(size, recipes.Count());
        }

        [Test]
        public void ShouldReturnNoneRecipeWhenInvokeIndexMethodAndRepositoryReturnNull()
        {
            _recipeRepositoryMock.Setup(c => c.GetAll())
                .Returns<IQueryable<Recipe>>(null);

            var recipes = _recipesController.Index();

            Assert.AreEqual(null, recipes);
        }

        private IEnumerable<Recipe> BuilderRecipes(int size)
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
