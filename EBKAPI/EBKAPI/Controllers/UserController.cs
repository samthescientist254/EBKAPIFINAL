using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthService.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly Domain.AuthService authService;
        public UserController(Domain.AuthService authService)
        {
            this.authService = authService;
        }
        // GET: api/User
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(authService.UserFromLogin(HttpContext.User.Identity.Name));
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/User
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Post([FromBody] AuthRequest user)
        {
            var token = authService.Authenticate(user.Login, user.Password);
            if (token == null) return BadRequest(new { message = "username or password is incorrect" });
            return Ok(new { Token = token });
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
