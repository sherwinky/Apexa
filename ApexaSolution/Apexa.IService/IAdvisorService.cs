using Apexa.Data.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apexa.Data;

namespace Apexa.IService
{
    public interface IAdvisorService: IBaseService
    {
        public ApexaResult GetAdvisor(long id);
        public ApexaResult GetAdvisorList();
        public ApexaResult AddAdvisor(Advisor advisor);
        public ApexaResult UpdateAdvisor(long id, Advisor advisor);
        public ApexaResult DeleteAdvisor(long id);
    }
}
