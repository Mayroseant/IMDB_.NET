using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MovieMayDL;
using MovieMayDL.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieMayAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        //Data Layer
        public UserDL udl = new UserDL();

        //Login
        //POST api/<UserController>/Login
        [Route("[action]")]
        [HttpPost]
        public IActionResult Login([FromBody] User user)
        {
            bool res = udl.UserValidate(user);
            if(res == true)
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var claims = new List<Claim>
                {
                    new Claim("Email", user.Email),
                    new Claim("Role", user.UserRole)
                };

                var tokenOptions = new JwtSecurityToken(
                    issuer: "http://localhost:56671",
                    audience: "http://localhost:56671",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: signingCredentials
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                return Ok(new { Token = tokenString });
            }
            else
            {
                return Unauthorized();
            }
        }

        //Signup
        // POST api/<UserController>/Signup
        [Route("[action]")]
        [HttpPost]
        public bool Signup([FromBody] User user)
        {
            bool res = udl.UserReg(user);
            return res;
        }
    }
}
