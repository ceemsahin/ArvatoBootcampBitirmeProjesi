using BusinessLogicLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataAccessLayer;
using DataAccessLayer.Redis;
using Microsoft.AspNetCore.Authorization;

namespace MyGraduationProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MoviesController : ControllerBase
    {


        Mytable r = new Mytable();
        //İşlemlerimde kullanmak için DataAccess'den 2 adet field oluşturdum ve bunları constructor'da  eşledim.
        private IMoviesService _moviesService;
        private IRedisHelper _redisHelper;



        public MoviesController(IMoviesService moviesService, IRedisHelper redisHelper)
        {
            _moviesService = moviesService;
            _redisHelper = redisHelper;


        }
        /// <summary>
        /// Url ile getirme işlemi yaparsanız çalışıyor veya postman kullanınız ancak direkt swagger üzerinden getirme işleminde bir çok uzun sürüyor sonucunu göremedim.
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAll()
        {

            var movies = await _moviesService.GetAllMovies();
            return Ok(movies);

        }

        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> GetMovieDetailsById(int id) //Id'göre gelecek movie'lerin action kısmı
        {

            var movies = await _moviesService.GetMoviesById(id);

            if (movies != null)
            {

                //Redis kullanımı burada gerçekleştirdim.Çağırılan id'yi redis de id numarasına göre tutuyor.Get "İd numarası" ile kaç defa çağırıldığını görebiliriz.

                var redis = await _redisHelper.GetKeyAsync(movies.id.ToString());
                if (redis == null)
                {

                    await _redisHelper.SetKeyAsync(movies.id.ToString(), 1);

                }
                else
                {

                    await _redisHelper.SetKeyAsync(movies.id.ToString(), redis + 1);
                }


                var redis2 = await _redisHelper.GetKeyAsync(movies.id.ToString());
                return Ok(movies);//200+DATA(başarılı)



            }



            return NotFound(); //404 NOT FOUND(sayfa bulunamadı)


        }


        //Girilen isme göre movie getirir.
        [HttpGet]
        [Route("[action]/{name}")]
        public async Task<IActionResult> SearchGetMovieByName(string name) //isme göre gelecek movie'lerin action kısmı 
        {
            try
            {
                var movies = await _moviesService.GetMoviesByName(name);
                return Ok(movies);//200+DATA(başarılı)
            }
            catch (Exception)
            {

                throw;
            }

        }

        //Önce boş olan bir ID değeri bulup(GetMovieById kısmını kullanabilirsiniz) daha sonra ekleme işlemi gerçekleştiriniz.ID alanı tablo'da identity olarak ayarlanmadığı için bazı noktalarda hata veriyor.

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddMovie([FromBody] Mytable mytable) //Eklenecek olan movie'nin action kısmı 
        {
            var lastmovieid = await _moviesService.CreateMovies(mytable);
            return Ok(mytable);//başarılı
        }

        [HttpDelete]
        [Route("[action]/{id}")]
        public async Task<IActionResult> DeleteMovie(int id) //Silinecek olan movie'nin action kısmı.Silme işlemi ıd bazlıdır ve tablodan direkt siler.
        {

            if (await _moviesService.GetMoviesById(id) != null)
            {
                await _moviesService.DeleteMovies(id);
                return Ok();//Başarılı
            }
            return NotFound();//Sayfa bulunamadı
        }


        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateMovie([FromBody] Mytable mytable) //Movie güncelleme action'ı
        {


            if (await _moviesService.GetMoviesById(mytable.id) != null)
            {

                return Ok(await _moviesService.UpdateMovies(mytable));

            }
            return NotFound();
        }



        // Genreye göre movie aramalarını [{'id': 18, 'name': 'Drama'}] veya [{'id': 35, 'name': 'Comedy'}] gibi şekillerde yazıp çektiğinizde sonuç verecektir.
        [HttpGet]
        [Route("[action]/{name}")]
        public async Task<IActionResult> GetMovieListGenre(string name) //Genre'ye göre movie getirme action'ı
        {


            var movies = await _moviesService.GetMoviesGenre(name);

            if (movies != null)
            {
                return Ok(movies);//200+DATA(başarılı)
            }
            return NotFound(); //404 NOT FOUND(sayfa bulunamadı)

        }


        //Rate'leri büyükten küçüğe göre sıralar.
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetMovieListRate() //Rate'e göre movie getirme action'ı
        {

            var movies = await _moviesService.GetListRate();
            return Ok(movies);


        }

        //ReleasedDate'i büyükten küçüğe göre sıralar. Null alanlar ile başlayabilir.
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetMovieListReleasedDate() //Released Date'e göre movie getirme action'ı
        {

            var movies = await _moviesService.GetListReleasedDate();
            return Ok(movies);


        }

        //Girilen tarihteki Movieleri getirir.
        [HttpGet]
        [Route("[action]/{name}")]
        public async Task<IActionResult> SearchGetMovieYear(string name) //Yıla göre movie getirme action'ı
        {

            var movies = await _moviesService.GetMoviesYear(name);

            if (movies != null)
            {
                return Ok(movies);//200+DATA(başarılı)
            }
            return NotFound(); //404 NOT FOUND(sayfa bulunamadı)




        }

        //Girilen Rakam'a göre movie'leri getirir.
        [HttpGet]
        [Route("[action]/{param}")]
        public async Task<IActionResult> SearchGetMovieRate(decimal param) //Girilen puana göre  movie getirme action'ı.
        {

            var movies = await _moviesService.GetMoviesRate(param);

            if (movies != null)
            {
                return Ok(movies);//200+DATA(başarılı)
            }
            return NotFound(); //404 NOT FOUND(sayfa bulunamadı)


        }

        





    }
}
