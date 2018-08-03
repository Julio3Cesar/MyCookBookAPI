using COREMyCookBookAPI.Models;
using NUnit.Framework;
using System.Linq;

namespace COREMyCookBookAPITest.Controllers.Recipes
{
    public class Show : ControllerTestBase
    {
        [Test]
        public void ShouldReturnARecipeWhenInvokeShowMethodWithId()
        {
            var size = 10;
            var id = 4;
            var recipeReturnedByTheRepository = BuilderRecipes(size).ElementAt(id);
            _recipeRepositoryMock.Setup(c => c.GetById(id))
                .Returns(recipeReturnedByTheRepository);

            var recipeReturnedByTheController = _recipesController.Show(id);

            Assert.AreEqual(recipeReturnedByTheRepository, recipeReturnedByTheController);
        }

        [Test]
        public void ShouldReturnADifferentRecipeWhenInvokeShowMethodWithId()
        {
            var size = 10;
            var id = 4;
            var anotherId = 5;
            var recipeReturnedByTheRepository = BuilderRecipes(size).ElementAt(id);
            var anotherRecipe = BuilderRecipes(size).ElementAt(anotherId);
            _recipeRepositoryMock.Setup(c => c.GetById(id))
                .Returns(recipeReturnedByTheRepository);

            var recipeReturnedByTheController = _recipesController.Show(id);

            Assert.AreNotEqual(recipeReturnedByTheController, anotherRecipe);
        }

        [Test]
        public void ShouldNotReturnARecipeWhenInvokeShowMethodWithIdThatNotExist()
        {
            var idThatNotExistInReposiitory = 11;
            _recipeRepositoryMock.Setup(c => c.GetById(idThatNotExistInReposiitory))
                .Returns<Recipe>(null);

            var recipeReturnedByTheController = _recipesController.Show(idThatNotExistInReposiitory);

            Assert.AreEqual(null, recipeReturnedByTheController);
        }
    }
}
