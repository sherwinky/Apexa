using Apexa.Data.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apexa.IDAL;
using Apexa.Data.Parameters;

namespace Apexa.DAL
{
    public class AdvisorDal : BaseDal<Advisor>, IAdvisorDal
    {
        public AdvisorDal(AdvisorContext dbContext):base(dbContext) 
        {
        }

        public bool CheckSinUnique(string sin, long? advisorId)
        {
            if (advisorId.HasValue)
            {
                return Entities.Any(item => item.Sin == sin && item.Id != advisorId);
            }
            else
            {
                return Entities.Any(item => item.Sin == sin);
            }
        }

        public IEnumerable<Advisor> GetAdvisors(QueryParameter? parameter)
        {
            if (parameter != null && !String.IsNullOrEmpty(parameter.Name))
            {
                var result = Entities.Where(advisor => advisor.FullName.Contains(parameter.Name)).ToList();
                return result;
            }
            else
            {
                var result = Entities.ToList();
                return result;
            }

            
        }

        protected override void UpdateEntity(Advisor source, Advisor target)
        {
            target.PhoneNumber = source.PhoneNumber;
            target.Sin = source.Sin;
            target.Status = source.Status;
            target.Address = source.Address;
            target.FullName = source.FullName;
        }
    }
}
