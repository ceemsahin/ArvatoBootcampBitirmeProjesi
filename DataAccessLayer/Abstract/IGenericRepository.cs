using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IGenericRepository<T> where T : class 
    
     {


        Task<List<T>> GetAll();
        Task<T> GetById(int id);
        Task  Insert(T p);   //(Ekle)
        Task  Delete(int id);   //(Sil)
        Task  Update(T p);   //(Güncelle)
       Task <T> Get(Expression<Func<T, bool>> filter);
       Task <List<T>> List(Expression<Func<T, bool>> filter); //şartlı listeleme

    }
}
    