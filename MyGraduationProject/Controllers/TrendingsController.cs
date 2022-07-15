using BusinessLogicLayer.Abstract;
using DataAccessLayer.Redis;
using EntityLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyGraduationProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TrendingsController : ControllerBase
    {
        Mytable movies = new Mytable();
        IListService _listService;
      
        public TrendingsController(IListService listService)
        {
            _listService = listService;
          
        }

        //En yüksek oy alan 20 tane movie gelecek.

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> ListTopRatedMovies() //Rate'e göre movie getirme action'ı
        {
            try
            {
                var movies = await _listService.GetListRate();
                return Ok(movies);
            }
            catch (Exception)
            {                
                return NotFound();
            }
         
           


        }

        





    }
}
