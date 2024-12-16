using Apexa.Data;
using Apexa.Data.Dto;
using Apexa.IDAL;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Apexa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvisorController : ControllerBase
    {
        public AdvisorController(IAdvisorDal dal)
        {
            _dal = dal;
        }
        private readonly IAdvisorDal _dal;
        // GET: api/<AdvisorController>
        [HttpGet]
        public IEnumerable<Advisor> Get()
        {
            return _dal.GetAdvisors();
        }

        // GET api/<AdvisorController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AdvisorController>
        [HttpPost]
        public long Post()
        {
            Advisor advisor = new Advisor();
            advisor.Address = "123";
            advisor.FullName = "test 123";
            advisor.PhoneNumber = "1123";
            advisor.Status = HealthStatus.Green;
            advisor.Sin = "111";
            return _dal.Add(advisor);
        }

        // PUT api/<AdvisorController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AdvisorController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
