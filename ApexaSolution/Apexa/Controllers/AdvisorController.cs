using Apexa.Data;
using Apexa.Data.Dto;
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
            return _advisorService.GetAdvisorList();
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

        private Advisor CreateDefaultAdvisor()
        {
            Advisor advisor = new Advisor();
            advisor.Address = "123";
            advisor.FullName = "test 123";
            advisor.PhoneNumber = "1122334455";
            advisor.Status = HealthStatus.Green;
            advisor.Sin = "123456789";
            return advisor;
        }
    }
}
