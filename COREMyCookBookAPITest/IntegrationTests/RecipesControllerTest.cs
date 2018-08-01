using COREMyCookBookAPI.Context;
using COREMyCookBookAPI.Controllers;
using COREMyCookBookAPI.Models;
using COREMyCookBookAPI.Repositories;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Linq;

namespace COREMyCookBookAPITest.IntegrationTests
{

    [TestFixture]
    public class RecipesControllerTest
    {
        private IRepository<Recipe> _recipeRepository;
        private RecipesController _recipesController;
        private SqliteConnection _connection;

        [SetUp]
        public void SetUp()
        {
            _connection = new SqliteConnection("DataSource=:memory:");
            _connection.Open();

            var options = new DbContextOptionsBuilder<MyCookBookContext>()
                .UseSqlite(_connection)
                .Options;
            var context = new MyCookBookContext(options);
            context.Database.EnsureCreated();

            _recipeRepository = new RecipeRepository(context);
            _recipesController = new RecipesController(_recipeRepository);
        }

        [TearDown]
        public void Cleanup()
        {
            _connection.Close();
        }

        [Test]
        public void ShouldReturnSomeRecipeWhenInvokeIndexMethodAndRepositoryReturnSomeRecipe()
        {
            var size = 2;
            GenerateFakeRecipes(size);
            var recipes = _recipesController.Index();
            Assert.AreEqual(size, recipes.Count());
        }

        private void GenerateFakeRecipes(int size)
        {
            for (var i = 0; i < size; i++)
            {
                _recipeRepository.Create(new Recipe
                {
                    Cuisine = "Cuisine" + i,
                    Difficulty = "Difficulty" + 1,
                    PreparationTime = i,
                    Title = "Title" + i,
                    Type = "Type" + i
                    });

                 
            }
        }
    }
}
