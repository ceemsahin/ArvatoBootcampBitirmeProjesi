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
    public class MoviesRepository : IMoviesRepository
    {

        //Movie oluşturacak alan

        public async Task<Mytable> CreateMovies(Mytable mytable)
        {
            using (var movieDbContext = new ApiDbContext())

            {
                movieDbContext.Mytable.Add(mytable);
                var mytableid =  await movieDbContext.SaveChangesAsync();
                return mytable;
            }
        }
        //Id'e Movie silecek alan

        public async Task DeleteMovies(int id)
        {
            using (var movieDbContext = new ApiDbContext())

            {
                var deleteMovie = await GetMoviesById(id);
                movieDbContext.Mytable.Remove(deleteMovie);
                await movieDbContext.SaveChangesAsync();
            }
        }
        //Bütün movie'lerin gelmesini sağlayacak alan

        public async Task<List<Mytable>> GetAllMovies()
        {
             using (var apiDbContext = new ApiDbContext())

            {
                return await apiDbContext.Mytable.ToListAsync();
            }
        }
        //Rate göre sıralama işlemi yaptıracak alan

        public async Task<List<Mytable>> GetListRate()
        {
            using (var apiDbContext = new ApiDbContext())

            {
                return await apiDbContext.Mytable.OrderByDescending(x=>x.vote_average).ToListAsync(); //Rate'i büyükten küçüpe doğru sıralatıyoruz.
            }
        }
        //Released date'e göre sıralama yapacak alan

        public async Task<List<Mytable>> GetListReleasedDate()
        {
            using (var apiDbContext = new ApiDbContext())

            {
                return await apiDbContext.Mytable.OrderByDescending(x => x.release_date).ToListAsync(); //Yıla göre büyükten küçüğe göre sıralama yapacak.
            }
        }
        //Girilen Id'e göre Movie getirecek alan

        public async Task<Mytable> GetMoviesById(int id)
        {

            using (var apiDbContext = new ApiDbContext())

            {
                return await apiDbContext.Mytable.FindAsync(id);

            }

        }
        //Girilen isme göre gelecek movie alanı

        public async Task<Mytable> GetMoviesByName(string name)
        {

            using (var apiDbContext = new ApiDbContext())

            {
                return await apiDbContext.Mytable.FirstOrDefaultAsync(x => x.original_title.ToLower() == name.ToLower());
            }
        }
        //Girilen genre'ye göre gelecek alan

        public async Task<List<Mytable>> GetMoviesGenre(string name)
        {
            using (var apiDbContext = new ApiDbContext())

            {
                
                return await apiDbContext.Mytable.Where(x => x.genres.ToLower() == name.ToLower()&& x.genres.Contains(name)).ToListAsync(); // Kullanıcı genre yi girecek o genre hangi movie'lerde varsa listelenecektir.

            }
        }
        //Girilen rate'e göre gelecek alan

        public async Task<List<Mytable>> GetMoviesRate(decimal param)
        {
            using (var apiDbContext = new ApiDbContext())
                //Önce rate'leri büyükten küçüğe sıralatıp daha sonra girilen rate hangi movie'lerde varsa büyükten küçüğe göre sıralanacaktır.
            {
                return await apiDbContext.Mytable.OrderByDescending(x => x.vote_average).ToListAsync();
                 await apiDbContext.Mytable.Where(x => x.vote_average.ToString().Substring(0,1).Contains(param.ToString().Substring(0, 1)) == param.ToString().Contains(param.ToString().Substring(0, 1))).ToListAsync();

            }
        }

        //Girilen yıla göre gelecek alan

        public async Task<List<Mytable>> GetMoviesYear(string name)
        {
            using (var apiDbContext = new ApiDbContext())

            {
                return await apiDbContext.Mytable.Where(x=>x.release_date.Contains(name)==name.Contains(name)).ToListAsync();
            }
        }

        //Movie güncelleme alanı

        public async Task<Mytable> UpdateMovies(Mytable mytable)
        {
            using (var apiDbContext = new ApiDbContext())

            {
                apiDbContext.Mytable.Update(mytable);
               await apiDbContext.SaveChangesAsync();
                return mytable;
            }
        }
    }
}
