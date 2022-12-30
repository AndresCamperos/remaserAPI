using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using remaserAPI.Models.InputModels;
using System.Text;
using System;
using System.Threading.Tasks;

namespace remaserAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginsController : ControllerBase
    {
        private readonly string _secretkey;
        public LoginsController(IConfiguration configuration)
        {
            _secretkey = configuration.GetValue<string>("SecretKey");
        }
        // GET: api/Login>
        [HttpPost]
        public async Task<ActionResult> Login([FromBody] LoginInput loginInput )
        {
            if(loginInput == null)
            {
                return BadRequest();
            }
            if(loginInput.Login == "andrescamperos@gmail.com" && loginInput.Password == "a")
            {
                var keyBytes = Encoding.ASCII.GetBytes(_secretkey);
                var claims = new ClaimsIdentity();

                claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, loginInput.Login));

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = claims,
                    Expires = DateTime.UtcNow.AddMinutes(240),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature),
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);

                string token = tokenHandler.WriteToken(tokenConfig);

                return Ok(new {Token = token});
            }
            return Unauthorized();
        }

        
    }
}
