using COREMyCookBookAPI;
using COREMyCookBookAPI.Controllers;
using COREMyCookBookAPI.Models;
using Moq;
using NUnit.Framework;

namespace COREMyCookBookAPITest.Controllers.Recipes
{
    [TestFixture]
    public class ControllerTestBase
    {
        public Mock<IRepository<Recipe>> _recipeRepositoryMock { get; set; }
        public RecipesController _recipesController { get; set; }

        [SetUp]
        public void SetUp()
        {
            _recipeRepositoryMock = new Mock<IRepository<Recipe>>();
            _recipesController = new RecipesController(_recipeRepositoryMock.Object);
        }
    }
}