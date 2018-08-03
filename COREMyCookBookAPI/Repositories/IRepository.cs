using COREMyCookBookAPI.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq;
using System.Threading.Tasks;

namespace COREMyCookBookAPI.Repositories
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        IQueryable<TEntity> GetAll();
        Task<TEntity> GetById(int id);
        EntityEntry Create(TEntity entity);
        Task Update(int id, TEntity entity);
        Task Delete(int id);
    }
}
