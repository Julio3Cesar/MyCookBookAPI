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

            var recipeReturnedByTheController = _recipesController.Index();

            Assert.AreEqual(recipeReturnedByTheRepository, recipeReturnedByTheController);
        }
    }
}
