using EsportsBay.API.Data;
using EsportsBay.API.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EsportsBay.API.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly DataContext _context;

        public Repository(DataContext _context)
        {
            this._context = _context;   
        }
        public void Delete(T entity)
        {
            _context.Remove<T>(entity);
            _context.SaveChanges();
        }

        public T Get(long id)
        {
            return _context.Set<T>().FirstOrDefault(s => s.Id == id);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public void Insert(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _context.Set<T>().Attach(entity);
            _context.Entry<T>(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
