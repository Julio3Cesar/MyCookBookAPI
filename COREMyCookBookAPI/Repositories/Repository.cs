using COREMyCookBookAPI.Context;
using COREMyCookBookAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq;
using System.Threading.Tasks;

namespace COREMyCookBookAPI.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : Entity
    {
        private readonly MyCookBookContext MyCookBookContext;

        public Repository(MyCookBookContext myCookBookContext)
        {
            MyCookBookContext = myCookBookContext;
        }

        public EntityEntry Create(TEntity entity)
        {
            var result = MyCookBookContext.Set<TEntity>().Add(entity);
            MyCookBookContext.SaveChanges();
            return result;
        }

        public async Task Delete(int id)
        {
            var entity = GetById(id);
            MyCookBookContext.Set<TEntity>().Remove(entity);
            await MyCookBookContext.SaveChangesAsync();
        }

        public IQueryable<TEntity> GetAll()
        {
            return MyCookBookContext.Set<TEntity>().AsNoTracking();
        }

        public TEntity GetById(int id)
        {
            return MyCookBookContext.Set<TEntity>()
                .AsNoTracking()
                .FirstOrDefault(e => e.Id == id);
        }

        public async Task Update(int id, TEntity entity)
        {
            MyCookBookContext.Set<TEntity>().Update(entity);
            await MyCookBookContext.SaveChangesAsync();
        }
    }
}
