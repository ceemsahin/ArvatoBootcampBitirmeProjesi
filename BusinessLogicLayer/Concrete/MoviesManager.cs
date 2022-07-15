using BusinessLogicLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Redis;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Concrete
{
    public class MoviesManager : IMoviesService

    {
        //Data access layer'dan gelen Repo ile field oluşturup ctor'da eşliyorum.
        IMoviesRepository _moviesRepository;

        public MoviesManager(IMoviesRepository moviesRepository)
        {
            _moviesRepository = moviesRepository;
        }
        //Movie oluşturacak alan
        public async Task<Mytable> CreateMovies(Mytable mytable)
        {
            return await _moviesRepository.CreateMovies(mytable);
          

        }
        //Movie silecek alan
        public async Task DeleteMovies(int id)
        {
            await _moviesRepository.DeleteMovies(id);
        }
        //Bütün movie'lerin gelmesini sağlayacak alan
        public async Task<List<Mytable>> GetAllMovies()
        {
            return await _moviesRepository.GetAllMovies();
        }
        //Rate göre sıralama işlemi yaptıracak alan
        public async Task<List<Mytable>> GetListRate()
        {
         return await _moviesRepository.GetListRate();
        }
        //Released date'e göre sıralama yapacak alan
        public async Task<List<Mytable>> GetListReleasedDate()
        {
            return await _moviesRepository.GetListReleasedDate();
        }
        //Girilen Id'e göre Movie getirecek alan
        public async Task<Mytable> GetMoviesById(int id)
        {
            return await _moviesRepository.GetMoviesById(id);
        }
        //Girilen isme göre gelecek movie alanı
        public async Task<Mytable> GetMoviesByName(string name)
        {
            return await _moviesRepository.GetMoviesByName(name);
        }
        //Girilen genre'ye göre gelecek alan
        public async Task<List<Mytable>> GetMoviesGenre(string name)
        {
            return await _moviesRepository.GetMoviesGenre(name);
        }
       //Girilen rate'e göre gelecek alan
        public async Task<List<Mytable>> GetMoviesRate(decimal param)
        {
            return await _moviesRepository.GetMoviesRate(param);
        }
        //Girilen yıla göre gelecek alan
        public async Task <List<Mytable>> GetMoviesYear(string name)
        {
            return await _moviesRepository.GetMoviesYear(name);
        }
        //Movie güncelleme alanı
        public async Task<Mytable> UpdateMovies(Mytable mytable)
        {
            return await _moviesRepository.UpdateMovies(mytable);
        }
    }
}
