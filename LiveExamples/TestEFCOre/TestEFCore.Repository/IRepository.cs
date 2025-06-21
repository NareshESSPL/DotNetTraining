using System.Linq.Expressions;
using TestEFCore.Entity;

namespace TestEFCore.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Get(Expression<Func<T, bool>> predicate);

        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate = null);

        void Insert<T>(T entity);

        void Update(T updatedEntity);

        void Delete(T deletedEntity);
    }
}