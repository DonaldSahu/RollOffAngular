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
    public class EmailController : ControllerBase
    {
        private readonly IEmailRepository emailRepository;

        public EmailController(IEmailRepository emailRepository)
        {
            this.emailRepository = emailRepository;
        }

        [HttpPost]
        public IActionResult SendEmail(EmailDTO email)
        {
            
            emailRepository.SendEmail(email);
            return Ok();
        }
    }
}
