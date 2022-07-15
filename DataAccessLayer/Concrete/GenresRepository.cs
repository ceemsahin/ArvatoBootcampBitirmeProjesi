using DataAccessLayer.Abstract;
using EntityLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class GenresRepository : IGenresRepository

    {
       
        //Genre Ekleme alanı
        public async Task<Mytable> CreateGenres(Mytable mytable)
        {
            using (var genreDbContext = new ApiDbContext())

            {

                genreDbContext.Mytable.Update(mytable);
                await genreDbContext.SaveChangesAsync();
                return mytable;
            }
        }
        //Genre silme alanı
        public async Task<Mytable> DeleteGenres(Mytable mytable)
        {
            using (var genreDbContext = new ApiDbContext())

            {

                genreDbContext.Mytable.Update(mytable);
                await genreDbContext.SaveChangesAsync();
                return mytable;
            }
        }
        //Var olan genreleri sıralamasını istediğimiz alan
        public async Task<List<Mytable>> GetAllGenres()
        {
            using (var genreDbContext = new ApiDbContext())

            {

                return await (genreDbContext.Mytable.OrderBy(x => x.genres).ToListAsync());
               

            }

        }
        //İd'ye göre film getirsin.
        public async Task<Mytable> GetMoviesById(int id)
        {

            using (var apiDbContext = new ApiDbContext())

            {
                return await apiDbContext.Mytable.FindAsync(id);

            }
        }
        //Genre güncelleme kısmı
        public async Task<Mytable> UpdateGenres(Mytable mytable)
        {
            using (var genreDbContext = new ApiDbContext())

            {
                genreDbContext.Mytable.Update(mytable);
                await genreDbContext.SaveChangesAsync();
                return mytable;
            }
        }
    }
}
