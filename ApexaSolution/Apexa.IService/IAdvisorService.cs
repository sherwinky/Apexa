using Apexa.Data.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apexa.Data;

namespace Apexa.IService
{
    /// <summary>
    /// Advisor interface
    /// </summary>
    public interface IAdvisorService: IBaseService
    {
        /// <summary>
        /// get advisor by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ApexaResult GetAdvisor(long id);
        /// <summary>
        /// get advisor list
        /// </summary>
        /// <returns></returns>
        public ApexaResult GetAdvisorList();
        /// <summary>
        /// add new advisor
        /// </summary>
        /// <param name="advisor"></param>
        /// <returns></returns>
        public ApexaResult AddAdvisor(Advisor advisor);
        /// <summary>
        /// update advisor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="advisor"></param>
        /// <returns></returns>
        public ApexaResult UpdateAdvisor(long id, Advisor advisor);
        /// <summary>
        /// delete advisor
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ApexaResult DeleteAdvisor(long id);
    }
}
