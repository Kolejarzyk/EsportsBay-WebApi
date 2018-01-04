using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EsportsBay.API.Repository
{
    public interface IRepository<T>  where T : class
    {
        IEnumerable<T> GetAll();
        T Get(long id);

        void  Insert(T entity);

        void Delete(T entity);

        void Update(T entity);
    }
}
