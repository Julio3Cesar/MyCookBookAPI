using COREMyCookBookAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace COREMyCookBookAPI.Context
{
    public class MyCookBookContext : DbContext
    {
        public MyCookBookContext(DbContextOptions<MyCookBookContext> options) : base(options)
        { }

        public DbSet<Recipe> Recipes { get; set; }
    }
}
