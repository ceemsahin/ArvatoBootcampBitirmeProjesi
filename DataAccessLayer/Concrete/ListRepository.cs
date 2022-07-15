using DataAccessLayer.Abstract;
using DataAccessLayer.Redis;
using EntityLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class ListRepository : IListRepository
    {
        IRedisHelper _redisHelper;
        public ListRepository(IRedisHelper redisHelper)
        {
            _redisHelper = redisHelper;     
        }

        public async Task<List<Mytable>> GetListRate()
        {
            using (var apiDbContext = new ApiDbContext())

            {
                var k=  await apiDbContext.Mytable.OrderByDescending(x => x.vote_average).ToListAsync();//Rate'i büyükten küçüpe doğru sıralatıyoruz ve ilk 20 değeri alıyoruz.
                return  k.Take(20).ToList();
               
              

            }



        }

    }
}
