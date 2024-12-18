using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apexa.Data;

namespace Apexa.IService.Helper
{
    /// <summary>
    /// Helper class
    /// </summary>
    public interface IUtil
    {
        /// <summary>
        /// get next available health status 
        /// </summary>
        /// <returns></returns>
        public HealthStatus NexHealthStatus();
    }
}
