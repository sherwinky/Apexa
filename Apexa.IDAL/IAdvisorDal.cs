using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apexa.Data.Dto;
using Apexa.Data.Parameters;

namespace Apexa.IDAL
{
    public interface IAdvisorDal: IBaseDal<Advisor>
    {
        public IEnumerable<Advisor> GetAdvisors();
        public bool CheckSinUnique(string sin, long? advisorId);

    }
}
