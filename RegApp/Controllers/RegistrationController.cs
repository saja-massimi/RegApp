using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RegApp.Data;
using RegApp.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;
namespace RegApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        private readonly Data.AppDBContext appDBContext;

        public RegistrationController(IConfiguration configuration, AppDBContext _appDBContext)
        {
            _configuration = configuration;
            appDBContext = _appDBContext;

        }


        [HttpPost]
        public IActionResult Register([FromBody] UserModel user)

        {
            UserModel obj = new()
            {
                id = user.id,
                name = user.name,
                email = user.email,
                password = user.password
            };

            appDBContext.Add(obj);
            appDBContext.SaveChanges();

            return Ok("User registered successfully");

        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult login(loginModel user)

        {
            IActionResult response;
            var u = appDBContext.Users.FirstOrDefault(u => u.email == user.email && u.password == user.password);
            if (u == null)
                return BadRequest();
            else
            {

                UserModel obj = new()

                {
                    email = user.email,
                    id = u.id,
                    name = u.name,
                    password = user.password
                };
                var token = generateToken(obj);
                response = Ok(new { token });
                return response;
            }

        }

        [Authorize]
        [HttpGet]
        public IActionResult getUserName()
        {
            var username = HttpContext.User.Identity.Name;

            return Ok(new { username });


        }

        private string generateToken(UserModel user)
        {

            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.Name, user.name),



    };

            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);


            var jwtSecurityToken = new JwtSecurityTokenHandler().CreateJwtSecurityToken(
                null,
                null,
                new ClaimsIdentity(claims),
                null,
                expires: DateTime.UtcNow.AddMinutes(60),
                null,
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }

      
    
        }

}
