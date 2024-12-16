using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apexa.Data.Dto;
using Apexa.Data.Parameters;

namespace Apexa.IDAL
{
    public interface IAdvisorDal: IBaseDal
    {
        public Advisor? Get(long id);

        public long Add(Advisor entity);

        //public bool Update(BaseDto entity);
        //public bool Delete(long id);
        public IEnumerable<Advisor> GetAdvisors();

    }
}
