using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apexa.Data
{
    /// <summary>
    /// Error class
    /// </summary>
    public class Error
    {
        public Error() { }
        public ErrorType ErrorType { get; set; } = ErrorType.ValidationError;
        public string? Message { get; set; }
    }
}
