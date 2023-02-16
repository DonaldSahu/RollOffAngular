using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RollOffBackend.DTO;
using RollOffBackend.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RollOffBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        private readonly ITokenHandler handler;

        public AuthController(IUserRepository userRepository, ITokenHandler handler)
        {
            this.userRepository = userRepository;
            this.handler = handler;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> LoginAsync(LoginRequestDTO loginRequestDTO)
        {
            if(loginRequestDTO.Email==null && loginRequestDTO.Password == null)
            {
                return NotFound("email or password is null");
            }
            //we check if user is authenticated which is check the username and password is present 
            // in our database.
            var user = await userRepository.AuthenticateUserAsync(loginRequestDTO.Email, loginRequestDTO.Password);
            if (user != null)
            {
                //generate jwt token
                var token = handler.CreateTokenAsync(user);
                return Ok(token.Result);
            }
            return BadRequest("Username or password is incorrect");
        }
    }
}
