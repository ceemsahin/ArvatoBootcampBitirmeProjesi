using DataAccessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MyGraduationProject.Controllers
{
    //User girişi ve tokan üretimi yapılacak alanlar burada mevcuttur.

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private ApiDbContext _context;
        private readonly IConfiguration _configuration;
        public UserController(ApiDbContext apiDbContext, IConfiguration configuration)
        {
            _context = apiDbContext;
           this._configuration = configuration;
        }

        //Login işlemi

        [HttpGet]
        [Route("[action]")]
        public string Login(string Username,string Password)
        {
           var user = _context.Users.FirstOrDefault(x => x.Username == Username && x.Password == Password);
            if (user != null)
            {
               return  GenerateToken(user.Username);
            }
           
            return "";
            
        }
        //Token üretimi
        private string GenerateToken(string username)
        {
           var tokenHandler=new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Application:JWTSecret"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Audience = "ARVATO",
                Issuer = "ARVATO.Issuer.Development",
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier,Guid.NewGuid().ToString()),
                    new Claim(ClaimTypes.Name,username),
                }),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)

            };

            var token=tokenHandler.CreateToken(tokenDescriptor);    
            return tokenHandler.WriteToken(token); 


        }
    }
}
