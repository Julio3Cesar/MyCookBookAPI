
using COREMyCookBookAPI.Context;
using COREMyCookBookAPI.Models;
using COREMyCookBookAPI.Repositories;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace COREMyCookBookAPITest.Repositories
{
    [TestFixture]
    public class RepositoryTestBase
    {
        protected IRepository<Entity> _recipeRepository;
        protected SqliteConnection _connection;
        protected MyCookBookContext _context;

        [SetUp]
        public void SetUp()
        {
            _connection = new SqliteConnection("DataSource=:memory:");
            _connection.Open();

            var options = new DbContextOptionsBuilder<MyCookBookContext>()
                .UseSqlite(_connection)
                .Options;
            _context = new MyCookBookContext(options);
            _context.Database.EnsureCreated();

            _recipeRepository = new Repository<Entity>(_context);
        }

        [TearDown]
        public void Cleanup()
        {
            _connection.Close();
        }

        protected void GenerateFakeRecipes(int size)
        {
            for (var i = 0; i < size; i++)
            {
                _context.Add(new Recipe
                {
                    Cuisine = "Cuisine" + i,
                    Difficulty = "Difficulty" + i,
                    Ingredients = "Ingredients" + i,
                    Preparation = "Preparation" + i,
                    PreparationTime = i,
                    Title = "Title" + i,
                    Type = "Type" + i
                });
            }
            var o = _context.Entitys.AsNoTracking();
        }
    }
}
