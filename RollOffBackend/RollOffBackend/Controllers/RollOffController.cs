using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RollOffBackend.DTO;
using RollOffBackend.Models;
using RollOffBackend.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RollOffBackend.Controllers
{
    [ApiController]
    [Route("RollOff")]
    [Authorize(Roles = "Admin")]
    public class RollOffController : ControllerBase
    {
        private readonly IRollOffRepository rollOffRepository;
        private readonly IMapper mapper;

        public RollOffController(IRollOffRepository rollOffRepository, IMapper mapper)
        {
            this.rollOffRepository = rollOffRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserDetails()
        {
            try
            {
                var rolloffdetails = await rollOffRepository.GetallDetailsAsync();
                if (rolloffdetails == null)
                {
                    return NotFound();
                }
                var rolloffdetailsdto = mapper.Map<List<MasterTableDTO>>(rolloffdetails);
                return Ok(rolloffdetailsdto);
            }
            catch (Exception e)
            {
                return BadRequest("something went wrong " + e);
            }
        }

        [HttpGet]
        [Route("{ggid:double}")]
        public async Task<IActionResult> GetByGGID(double ggid)
        {
            try
            {
                var employeedetails = await rollOffRepository.GetbyGGIDAsync(ggid);
                if (employeedetails == null)
                {
                    return NotFound();
                }
                var employeedetailsdto = mapper.Map<MasterTableDTO>(employeedetails);
                return Ok(employeedetailsdto);
            }
            catch (Exception e)
            {
                return BadRequest("something went wrong " + e);
            }
        }

        [HttpGet]
        [Route("{email}")]
        public async Task<IActionResult> GetByEmail(string email)
        {
            try
            {
                var employeedetails = await rollOffRepository.GetbyEmailAsync(email);
                if (employeedetails == null)
                {
                    return NotFound();
                }
                var employeedetailsdto = mapper.Map<MasterTableDTO>(employeedetails);
                return Ok(employeedetailsdto);
            }
            catch (Exception e)
            {
                return BadRequest("something went wrong " + e);
            }
        }

        /*[HttpGet]
        [Route("{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            try
            {
                var employeedetails = await rollOffRepository.GetbyNameAsync(name);
                if (employeedetails == null)
                {
                    return NotFound();
                }
                var employeedetailsdto = mapper.Map<RollOffTableDTO>(employeedetails);
                return Ok(employeedetailsdto);
            }
            catch(Exception e)
            {
                return BadRequest("Something went wrong" + e);
            }
        }*/
    }
}
