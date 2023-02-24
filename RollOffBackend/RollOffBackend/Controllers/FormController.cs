using AutoMapper;
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
    [Route("api/[controller]")]
    [ApiController]
    public class FormController : ControllerBase
    {
        private readonly IFormRepository formRepository;
        private readonly IMapper mapper;

        public FormController(IFormRepository formRepository,IMapper mapper)
        {
            this.formRepository = formRepository;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddForm(FormTableDTO formTableDTO)
        {
            try
            {
                var formdetails = mapper.Map<RolloffForm>(formTableDTO);
                var form = await formRepository.AddFormAsync(formdetails);
                if(form == null)
                {
                    return NotFound("details not added");
                }
                return Ok("Success");
            }
            catch(Exception e)
            {
                return BadRequest("something went wrong" + e);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDetails()
        {
            try
            {
                var EmployeesDetails = await formRepository.GetDetailsAsync();
                if(EmployeesDetails == null)
                {
                    return NotFound("details not received");
                }
                var EmployeeDetailsDTO = mapper.Map<List<FormTableDTO>>(EmployeesDetails);
                return Ok(EmployeeDetailsDTO);
            }
            catch(Exception e)
            {
                return BadRequest("something went wrong" + e);
            }
        }

        [HttpGet]
        [Route("{ggid:double}")]
        public async Task<IActionResult> GetByGGid(double ggid)
        {
            try
            {
                var formdetails = await formRepository.GetDetailsGGID(ggid);
                if (formdetails == null)
                {
                    return NotFound("details not found");
                }
                var formdetailsDTO = mapper.Map<FormTableDTO>(formdetails);
                return Ok(formdetailsDTO);
            }
            catch(Exception e)
            {
                return BadRequest("something went wrong" + e);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDetails(double ggid,UpdateFormDTO updateFormDTO)
        {
            try
            {
                var empdetails = mapper.Map<RolloffForm>(updateFormDTO);
                var employee = await formRepository.UpdateForm(ggid, empdetails);
                if (employee == null)
                {
                    return NotFound("Details not found");
                }
                var EmpUpdated = mapper.Map<FormTableDTO>(employee);
                return Ok(EmpUpdated);
            }
            catch(Exception e)
            {
                return BadRequest("something went wrong" + e);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteDetails(double ggid)
        {
            try
            {
                var empdetails = await formRepository.DeleteForm(ggid);
                var empdetailsDTO = mapper.Map<FormTableDTO>(empdetails);
                return Ok(empdetailsDTO);
            }
            catch(Exception e)
            {
                return BadRequest("something went wrong" + e);
            }
        }
    }
}
