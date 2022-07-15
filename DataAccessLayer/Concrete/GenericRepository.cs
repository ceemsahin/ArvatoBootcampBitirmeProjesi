using DataAccessLayer.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        ApiDbContext c = new ApiDbContext();
        DbSet<T> _object;

        public GenericRepository()
        {
            _object = c.Set<T>();
        }

        public async Task Delete(int id)
        {
            var deleteUser = await GetById(id);
            c.Remove(deleteUser);
            await c.SaveChangesAsync();
        }

        public async Task<T> Get(Expression<Func<T, bool>> filter)
        {
            return await _object.SingleOrDefaultAsync(filter);
        }

        public async Task<List<T>> GetAll()
        {
            return  await _object.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _object.FindAsync(id);
        }

        public async Task Insert(T p)
        {
            var addedEntity = c.Entry(p);
            addedEntity.State = EntityState.Added;
            //_object.Add(p);
            await c.SaveChangesAsync();
        }

        public async Task<List<T>> List(Expression<Func<T, bool>> filter)
        {
            return await _object.Where(filter).ToListAsync();
        }

        public async Task Update(T p)
        {
            var  updatedEntity =  c.Entry(p);
            updatedEntity.State = EntityState.Modified;
            await c.SaveChangesAsync();
        }

   
    }
}
