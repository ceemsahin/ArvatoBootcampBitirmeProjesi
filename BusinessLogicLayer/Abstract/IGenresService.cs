using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Abstract
{
    public interface IGenresService
    {
        Task<List<Mytable>> GetAllGenres();//Bütün Genre'leri getir
        Task<Mytable> GetMoviesById(int id);//Id'e göre Movie gelsin
        Task<Mytable> CreateGenres(Mytable mytable);//Genre ekle
        Task<Mytable> UpdateGenres(Mytable mytable);//Genre güncelle
        Task<Mytable> DeleteGenres(Mytable mytable);//ID'e göre genre sil



    }
}
