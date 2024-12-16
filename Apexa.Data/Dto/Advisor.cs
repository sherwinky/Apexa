using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apexa.Data.Dto
{
    public class Advisor : BaseDto
    {
        public string FullName { get; set; }
        public string Sin { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        public HealthStatus Status { get; set; }
    }
}
