using System.Linq;

namespace COREMyCookBookAPI
{
    public interface IRepository<T>
    {
        IQueryable<T> GetAll();
        void InsertOnSubmit(T entity);
        void DeleteOnSubmit(T entity);
        void SubmitChanges();
    }
}
