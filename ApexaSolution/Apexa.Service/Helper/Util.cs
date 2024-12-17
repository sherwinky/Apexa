using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apexa.Data;
using Apexa.IService.Helper;

namespace Apexa.Service.Helper
{
    public class Util : IUtil
    {
        private static readonly HealthStatus[] StatusPool;

        static Util()
        {
            List<HealthStatus> statusSource = new List<HealthStatus>();
            //Green 60%
            //Yellow 20%
            //Red 20%
            statusSource.Add(HealthStatus.Green);
            statusSource.Add(HealthStatus.Green);
            statusSource.Add(HealthStatus.Green);
            statusSource.Add(HealthStatus.Green);
            statusSource.Add(HealthStatus.Green);
            statusSource.Add(HealthStatus.Green);
            statusSource.Add(HealthStatus.Yellow);
            statusSource.Add(HealthStatus.Yellow);
            statusSource.Add(HealthStatus.Red);
            statusSource.Add(HealthStatus.Red);

            StatusPool = statusSource.OrderBy(item => Random.Shared.Next()).ToArray();
        }

        /// <summary>
        /// Pick an health status randomly
        /// </summary>
        /// <returns></returns>
        public HealthStatus NexHealthStatus()
        {

            return Util.StatusPool[Random.Shared.Next(0,Util.StatusPool.Length)];
        }
    }
}
