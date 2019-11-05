using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PetshopCompulsory.Core.ApplicationService;
using PetshopCompulsory.Core.DomainService;
using PetshopCompulsory.Core.Entity;
using PetshopCompulsory.Core.Helper;

namespace PetshopCompulsory.RestAPI.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class TokensController : Controller
    {
        private readonly IUserService _userService;
        private IAuthenticationHelper authenticationHelper;

        public TokensController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public ActionResult Login([FromBody] LoginInputModel model)
        {
            var user = _userService.ReadAllUsers(null).List
                .FirstOrDefault(u => u.Username == model.Username);

            //check if username exists
            if (user == null)
            {
                return Unauthorized();
            }

            if (!VerifyPasswordHash(model.Password, user.PasswordHash, user.PasswordSalt))
            {
                return Unauthorized();
            }

            return Ok(new
            {
                username = user.Username,
                token = GenerateToken(user)
            });
        }

        private bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }
            return true;
        }

        private string GenerateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username)
            };

            if (user.IsAdmin)
            {
                claims.Add(new Claim(ClaimTypes.Role, "Administrator"));

            }

            var token = new JwtSecurityToken(new JwtHeader
                (new SigningCredentials(
                JWTSecurityKey.Key, SecurityAlgorithms.HmacSha256)),
                new JwtPayload(null,
                                null,
                                claims.ToArray(),
                                DateTime.Now,
                                DateTime.Now.AddMinutes(5)));

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}