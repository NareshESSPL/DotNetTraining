using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestEFCore.Entity;

namespace TestEFCore.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private TestEFCoreDbContext _testEFCoreDbContext { get; set; }

        public Repository(TestEFCoreDbContext testEFCoreDbContext)
        {
            _testEFCoreDbContext = testEFCoreDbContext;
        }

        /// <summary>
        /// Return the rows from table based on the linq query/gets all the rows if predicate is null 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public IQueryable<T> GetAll(System.Linq.Expressions.Expression<Func<T, bool>> predicate = null)
        {
            if (predicate != null)
            {
                return _testEFCoreDbContext.Set<T>().Where(predicate).AsNoTracking();
            }

            return _testEFCoreDbContext.Set<T>().AsNoTracking();
        }

        /// <summary>
        /// Returns the first row from table based on linq query/Get the first row of table if predicate is null
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public T Get(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return _testEFCoreDbContext.Set<T>().FirstOrDefault(predicate);
        }

        public void Insert<T>(T entity)
        {
            _testEFCoreDbContext.Add(entity);

            _testEFCoreDbContext.SaveChanges();
        }


        public void Update(T updatedEntity)
        {
            _testEFCoreDbContext.Attach(updatedEntity);

            //This will run update for all property in DB table
            _testEFCoreDbContext.Entry(updatedEntity).State = EntityState.Modified;

            _testEFCoreDbContext.SaveChanges();
        }

        public void Delete(T deletedEntity)
        {
            //option 2 Untracked
            _testEFCoreDbContext.Attach(deletedEntity);
            _testEFCoreDbContext.Entry(deletedEntity).State = EntityState.Deleted;
            _testEFCoreDbContext.SaveChanges();
        }

    }
}
