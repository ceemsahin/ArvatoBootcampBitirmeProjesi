using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Abstract
{
    public interface IMoviesService
    {

        Task<List<Mytable>> GetAllMovies();//Bütün Movie'ler gelsin
        Task<List<Mytable>> GetListRate();//Rate'e göre movie büyükten küçüğe doğru sıralansın
        Task<List<Mytable>> GetListReleasedDate();//Released Date'e göre movie büyükten küçüğe doğru sıralansın
        Task<Mytable> GetMoviesById(int id);//Id'e göre Movie gelsin
        Task<Mytable> GetMoviesByName(string name);//isme göre Movie gelsin
        Task<List<Mytable>> GetMoviesYear(string name);//Girilen Yıla  göre movie'ler gelsin
        Task<List<Mytable>> GetMoviesRate(decimal param);//Girilen Rate'e göre movie'ler gelsin
        Task<List<Mytable>> GetMoviesGenre(string name);//Girilen Genre'ye göre movie'ler gelsin
        Task<Mytable> CreateMovies(Mytable mytable);//Movie eklesin
        Task<Mytable> UpdateMovies(Mytable mytable);//Movie güncelle
        Task DeleteMovies(int id);//Id'e göre Movie sil




    }
}
