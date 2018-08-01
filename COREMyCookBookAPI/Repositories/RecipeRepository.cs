using COREMyCookBookAPI.Context;
using COREMyCookBookAPI.Models;

namespace COREMyCookBookAPI.Repositories
{
    public class RecipeRepository : Repository<Recipe>
    {
        private readonly MyCookBookContext MyCookBookContext;

        public RecipeRepository(MyCookBookContext myCookBookContext) : base(myCookBookContext)
        {
            MyCookBookContext = myCookBookContext;
        }
    }
}
