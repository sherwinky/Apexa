using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apexa.Data.Dto;
using Apexa.Data.Parameters;

namespace Apexa.IDAL
{
    /// <summary>
    /// advisor dal interface
    /// </summary>
    public interface IAdvisorDal: IBaseDal<Advisor>
    {
        /// <summary>
        /// Get advisor list
        /// </summary>
        /// <returns>list of advisor</returns>
        public IEnumerable<Advisor> GetAdvisors(QueryParameter? parameter);
        /// <summary>
        /// check sin is unique
        /// </summary>
        /// <param name="sin"></param>
        /// <param name="advisorId"></param>
        /// <returns></returns>
        public bool CheckSinUnique(string sin, long? advisorId);

    }
}
