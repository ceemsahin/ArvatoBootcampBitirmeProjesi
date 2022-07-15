using BusinessLogicLayer.Abstract;
using EntityLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyGraduationProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class GenresController : ControllerBase
    {

        private IGenresService _genresService;

        public GenresController(IGenresService genresService)
        {
            _genresService = genresService;
               


        }


        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetListGenre() // Bütün genre'leri getirecek action.
        {
            
            var genres = await _genresService.GetAllGenres();
            return Ok(genres);
        }

        //Genre alanlarında rahat işlem yapabilmek için böyle bir action ekledim.

        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> GetMovieDetailsById(int id) //Id'göre gelecek movie'lerin action kısmı
        {
           
            try
            {
                var movies = await _genresService.GetMoviesById(id);
                if (movies == null)
                {
                    return NotFound();//404 NOT FOUND(sayfa bulunamadı)

                }
                return Ok(movies);//200+DATA(başarılı)

            }
            catch (Exception)
            {
                

                return BadRequest(); 
            }


        }


        //Ekleme işlemlerinde [{'id': 18, 'name': 'Drama'}] veya [{'id': 35, 'name': 'Comedy'}] gibi yazıp denersek sonuç verecektir.

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddGenre([FromBody] Mytable mytable) //Genre ekleme yapacak action
        {
            try
            {
                var addGenre = await _genresService.CreateGenres(mytable);
                return Ok(mytable);//başarılı
            }
            catch (Exception)
            {
                throw;
            }
            



        }

        [HttpDelete]
        [Route("[action]")]
        public async Task<IActionResult> DeleteGenre([FromBody] Mytable mytable) //Genre silecek action
        {
            var deleteGenre = await _genresService.DeleteGenres(mytable);
            return Ok(mytable);//başarılı

        }



        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateGenre([FromBody] Mytable mytable)//Genre güncelleme action'ı
        {

            var updateGenre = await _genresService.UpdateGenres(mytable);
            return Ok(mytable);//başarılı
        }
        




    }
}
