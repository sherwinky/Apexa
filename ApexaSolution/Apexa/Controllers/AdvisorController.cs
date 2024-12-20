﻿using Apexa.Data;
using Apexa.Data.Dto;
using Apexa.Data.Parameters;
using Apexa.IDAL;
using Apexa.IService;
using Apexa.IService.Helper;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Apexa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvisorController : ControllerBase
    {
        private readonly IAdvisorService _advisorService;
        private readonly IValidator _validator;
        public AdvisorController(IAdvisorService advisorService,IValidator validator)
        {
            _advisorService = advisorService;
            _validator = validator;
        }
        
        // GET: api/<AdvisorController>
        [HttpGet]
        public ApexaResult Get(string? name)
        {
            QueryParameter parameter = new QueryParameter();
            if (!String.IsNullOrEmpty(name))
            {
                parameter.Name = name;
            }

            return _advisorService.GetAdvisorList(parameter);
        }

        // GET api/<AdvisorController>/5
        [HttpGet("{id}")]
        public ApexaResult Get(long id)
        {
            return _advisorService.GetAdvisor(id);
        }

        // POST api/<AdvisorController>
        [HttpPost]
        public ApexaResult Post([FromBody] Advisor advisor)
        {
            return _advisorService.AddAdvisor(advisor);
        }

        // PUT api/<AdvisorController>/5
        [HttpPut("{id}")]
        public ApexaResult Put(int id, [FromBody] Advisor advisor)
        {
           return _advisorService.UpdateAdvisor(id,advisor);
        }


        // DELETE api/<AdvisorController>/5
        [HttpDelete("{id}")]
        public ApexaResult Delete(int id)
        {
            return _advisorService.DeleteAdvisor(id);
        }
    }
}
