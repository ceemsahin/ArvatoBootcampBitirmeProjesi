using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IGenresRepository
    {
        Task<List<Mytable>> GetAllGenres();
        Task<Mytable> GetMoviesById(int id);//Id'e göre Movie gelsin
        Task<Mytable> CreateGenres(Mytable mytable);//Bootcamp eklesin
        Task<Mytable> DeleteGenres(Mytable mytable);//Bootcamp silsin(id'e göre)
        Task<Mytable> UpdateGenres(Mytable mytable);//Bootcamp güncellesin


    }
}
