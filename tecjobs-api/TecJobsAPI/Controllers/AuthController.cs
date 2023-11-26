using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using TecJobsAPI.DTO;
using TecJobsAPI.Models;
using TecJobsAPI.Shared.Utils;

namespace TecJobsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        private readonly IConfiguration _config;

        public AuthController(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            IConfiguration config)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _config = config;
        }



        [HttpGet("Ping")]
        public ActionResult<string> Get()
        {
            return $"Access in : {DateTime.Now.ToLongDateString()}";
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPost("Register")]
        public async Task<ActionResult> RegisterUser(UserRegisterDTO data)
        {
            var user = new IdentityUser
            {
                UserName = data.Name,
                Email = data.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, data.Password);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            await _signInManager.SignInAsync(user, false);
            return Ok();
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login(UserLoginDTO login)
        {
            var result = await _signInManager.PasswordSignInAsync(
                login.Name,
                login.Password,
                isPersistent: false,
                lockoutOnFailure: false
            );

            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(login.Name);
                return Ok(new { user = user.Id, token = GenerateToken(login) });
            }
            else
            {
                return BadRequest();
            }
        }

        private UserToken GenerateToken(UserLoginDTO userLogin)
        {
            var secret = _config["Jwt:Key"];

            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.UniqueName, userLogin.Name),
                new Claim("chave", "Bill Gates"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(secret)
            );

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = _config["TokenConfiguration:ExpireHours"];
            var expiration = DateTime.UtcNow.AddHours(double.Parse(expires));

            JwtSecurityToken token = new(
                issuer: _config["TokenConfiguration:Issuer"],
                audience: _config["TokenConfiguration:Audience"],
                claims: claims,
                expires: expiration,
                signingCredentials: credentials
            );

            return new UserToken
            {
                Authenticated = true,
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration,
                Message = "Token success!"
            };
        }
    }
}