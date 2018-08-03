using NUnit.Framework;
using System.Linq;

namespace COREMyCookBookAPITest.Repositories
{
    
    public class Repository : RepositoryTestBase
    {
        [Test]
        public void ShouldReturnSomeRecipeWhenInvokeGetAllMethod()
        {
            var size = 2;
            GenerateFakeRecipes(size);
            var recipes = _recipeRepository.GetAll();
            Assert.AreEqual(size, recipes.Count());
        }
    }
}
