using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apexa.Data.Parameters
{
    public class QueryParameter
    {
        public long? Id { get; set; }
        public string? Name { get; set; }
        public string? Sin { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public HealthStatus? HealthStatus { get; set; }
    }
}
