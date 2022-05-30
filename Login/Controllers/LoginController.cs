using Login.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Login.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

using System.Text;

namespace Login.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        
        private readonly ILoginRepository _loginRepository;
        private  IOptions<Audience> _settings;

        public LoginController(ILoginRepository LoginRepository, IOptions<Audience> settings)
        {
            _loginRepository = LoginRepository;
            this._settings = settings;
        }

        [HttpGet]
        [Route("loginuserdetail")]
        [ActionName("loginuserdetail")]
        public async Task<IActionResult> Get(string user)
        {
            try
            {
                Logins Login = await _loginRepository.GetUserWithUserName(user);
                if (Login != null)
                {                    
                    return Ok(Login);
                }
            }
            catch (Exception Ex)
            {

            }
            return NotFound("No User Found");
        }
            //Get User 
            [HttpGet]
        [ActionName("GetUser")]
        public async Task<IActionResult> GetUser(string UserName,string PassWord)
        {
            try
            {
                Logins Login = await _loginRepository.GetUserDetails(UserName, PassWord);
                if (Login != null)
                {
                    JwtSecurityToken jwt = GetJwtToken(UserName);
                    return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(jwt) });
                    //return Ok();
                }
            }
            catch (Exception Ex)
            {

            }
            return NotFound("No User Found");
        }       


        //Add User
        [HttpPost]
        [ActionName("AddUser")]
        public async Task<IActionResult> AddUser([FromBody] Logins login)
        {
            try
            {
                // Console.WriteLine("UserName:"+ login.UserName+"PassWord"+login.PassWord+"email"+ login.Email);
                await _loginRepository.InsertUserDetails(login);
                return Ok();
            }
            catch(Exception ex)
            { }
            return Ok("Record Inserted Failed");
        }

        private JwtSecurityToken GetJwtToken(string UserName)
        {
            var now = DateTime.UtcNow;

            var claims = new Claim[]
            {
                    new Claim(JwtRegisteredClaimNames.Sub, UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, now.ToUniversalTime().ToString(), ClaimValueTypes.Integer64)
            };

            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_settings.Value.Secret));
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = signingKey,
                ValidateIssuer = true,
                ValidIssuer = _settings.Value.Iss,
                ValidateAudience = true,
                ValidAudience = _settings.Value.Aud,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero,
                RequireExpirationTime = true,

            };

            var jwt = new JwtSecurityToken(
                issuer: _settings.Value.Iss,
                audience: _settings.Value.Aud,
                claims: claims,
                notBefore: now,
                expires: now.Add(TimeSpan.FromMinutes(30)),
                signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
            );
            return jwt;
        }
        public class Audience
        {
            public string Secret { get; set; }
            public string Iss { get; set; }
            public string Aud { get; set; }
        }


        //private static string GetJwt(string UserName)
        //{
        //    HttpClient client = new HttpClient();
        //    client.DefaultRequestHeaders.Clear();
        //    client.BaseAddress = new Uri("http://localhost:9000");

        //    var res2 = client.GetAsync("/api/auth?name=" + UserName).Result;
        //    dynamic jwt = JsonConvert.DeserializeObject(res2.Content.ReadAsStringAsync().Result);

        //    return jwt.access_token;
        //}
    }
}
