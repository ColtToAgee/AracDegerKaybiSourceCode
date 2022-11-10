using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IRepositoryDal<T>
    {
        void Insert(T entity);
        void Update(T entity);  
        void Delete(T entity);
        List<T> GetAll();
        T Get(Expression<Func<T, bool>> filter);
        List<T> List(Expression<Func<T, bool>> Filter);
    }
}
