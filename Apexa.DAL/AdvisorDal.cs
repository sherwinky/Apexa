using Apexa.Data.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apexa.IDAL;

namespace Apexa.DAL
{
    public class AdvisorDal: BaseDal,IAdvisorDal
    {
        private readonly AdvisorContext _advisorContext;
        public AdvisorDal(AdvisorContext dbContext)
        {
            _advisorContext = dbContext;
        }

        public Advisor? Get(long id)
        {
            return _advisorContext.Advisors.FirstOrDefault(item => item.Id == id);
        }

        public long Add(Advisor entity)
        {
            var id =  _advisorContext.Advisors.Add(entity).Entity.Id!.Value;
            _advisorContext.SaveChanges();
            return id;
        }

        //public bool Update(BaseDto entity);
        //public bool Delete(long id);
        public IEnumerable<Advisor> GetAdvisors()
        {
            var result = _advisorContext.Advisors.ToList();
            return result;
        }
    }
}
