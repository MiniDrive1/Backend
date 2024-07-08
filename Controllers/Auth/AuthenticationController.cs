using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Backend.Models;
using Backend.Data;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Users.DTO;
using Backend.Utils;

namespace Backend.Controllers{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase{
        private readonly string secretKey;
        private readonly BackendDbContext _context;
        public AuthenticationController(IConfiguration config, BackendDbContext context){
            secretKey = config.GetSection("settings").GetSection("secretKey").ToString();
            _context = context;
        }

        [HttpPost]
        [Route("Validate")]
        public IActionResult ValidateUser([FromBody] createAuthDto userDto){
            var foundUser = _context.Users.FirstOrDefault(u => u.Email == userDto.Email && u.Password == userDto.Password);
            if(foundUser != null){
                var keyBytes = Encoding.ASCII.GetBytes(secretKey);
                var claims = new ClaimsIdentity();

                claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, userDto.Email));

                var tokenDescriptor = new SecurityTokenDescriptor{
                    Subject = claims,
                    Expires = DateTime.UtcNow.AddMinutes(10),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature)
                };

                var tokenHandler =  new JwtSecurityTokenHandler();
                var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);
                string tokenCreated = tokenHandler.WriteToken(tokenConfig);

                /* MAIL */
                // Se instancia un objeto de la clase 'MailersendUtils'
                var sendEmail = new MailController();
                // Se utiliza el método .EnviarCorreo(), se envía como parámetro el email del paciente y la fecha de la cita
                sendEmail.EnviarCorreo(foundUser.Email, foundUser.Name, tokenCreated);

                return StatusCode(StatusCodes.Status200OK, new {token = tokenCreated});
                
            }else{
                return StatusCode(StatusCodes.Status401Unauthorized, new {token = "Ingresa los datos correctos o registrate"});
            }
        }

    }
}