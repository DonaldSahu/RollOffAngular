using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RollOffBackend.DTO;
using RollOffBackend.Models;
using RollOffBackend.Repository;
using System;
using System.Threading.Tasks;

namespace RollOffBackend.Controllers
{
    [Route("Login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginRepository loginRepository;
        private readonly IMapper mapper;
        public LoginController(ILoginRepository loginRepository, IMapper mapper)
        {
            this.loginRepository = loginRepository;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddLoginDetails(UserDTO loginTableDTO)
        {
            try
            {
                var employeeDTO = mapper.Map<User>(loginTableDTO);
                var employee = await loginRepository.AddLoginDetailsAsync(employeeDTO);
                return Ok(employeeDTO);
            }
            catch(Exception e)
            {
                return BadRequest("something went wrong" + e);
            }
        }
    }
}
