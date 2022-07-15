using BusinessLogicLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Concrete
{
    public class GenresManager : IGenresService
    {

        IGenresRepository _genresRepository;

        public GenresManager(IGenresRepository genresRepository)
        {
            _genresRepository = genresRepository;
        }
        //Genre ekleme
        public async Task<Mytable> CreateGenres(Mytable mytable)
        {
            return await _genresRepository.CreateGenres(mytable);
        }
        //Genre silme
        public async Task<Mytable> DeleteGenres(Mytable mytable)
        {
            return await _genresRepository.DeleteGenres(mytable); 
        }
        //Bütün genreleri getirme 
        public async Task<List<Mytable>> GetAllGenres()
        {
            return await _genresRepository.GetAllGenres();
        }
        //Ek olarak Id'e göre movie gelsin
        public async Task<Mytable> GetMoviesById(int id)
        {
            return await _genresRepository.GetMoviesById(id);
        }
        //Genre güncelleme
        public async Task<Mytable> UpdateGenres(Mytable mytable)
        {
           return await _genresRepository.UpdateGenres(mytable);    
        }
    }
}
