using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
    public class GenericRepository<T>:IRepositoryDal<T> where T : class
    {
        Context c = new Context();
        DbSet<T> _object;

        public GenericRepository()
        {
            _object = c.Set<T>();
        }

        public void Delete(T entity)
        {
            var deletedEntity = c.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            c.SaveChanges();
        }

        public List<T> GetAll()
        {
            return _object.ToList();
        }
        public T Get(Expression<Func<T, bool>> filter)
        {
            return _object.SingleOrDefault(filter);
        }

        public void Insert(T entity)
        {
            var addedEntity=c.Entry(entity);
            addedEntity.State=EntityState.Added;
            c.SaveChanges();
        }

        public void Update(T entity)
        {
            var updatedEntity = c.Entry(entity);
            updatedEntity.State= EntityState.Modified;
            c.SaveChanges();
        }

        public List<T> List(Expression<Func<T, bool>> Filter)
        {
            return _object.Where(Filter).ToList();
        }
    }
}
