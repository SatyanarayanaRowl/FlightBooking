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

namespace Login.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        
        private readonly ILoginRepository _loginRepository;

        public LoginController(ILoginRepository LoginRepository)
        {
            _loginRepository = LoginRepository;
        }

        //Get User 
        [HttpGet]
        [ActionName("GetUser")]
        public async Task<IActionResult> GetUser(string UserName,string Password)
        {
            Logins Login = await _loginRepository.GetUserDetails(UserName, Password);
            if (Login != null)
            {
                var jwt = GetJwt(Login.UserName);
                return Ok(jwt);
            }

            return NotFound("No User Found");
        }      


        //Save Ticket
        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] Logins Login)
        {
            await _loginRepository.InsertUserDetails(Login);

            return Ok("Record Inserted Successfully");
        }

        private static string GetJwt(string UserName)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Clear();
            client.BaseAddress = new Uri("http://localhost:9009");

            var res2 = client.GetAsync("/api/auth?name=" + UserName).Result;
            dynamic jwt = JsonConvert.DeserializeObject(res2.Content.ReadAsStringAsync().Result);

            return jwt.access_token;
        }

    }
}
