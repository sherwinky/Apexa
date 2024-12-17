using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apexa.Data
{
    public class ApexaResult
    {
        private readonly bool _success;
        private readonly IList<ValidationResult> _errors;
        public bool Success => !_errors.Any() && _success;
        public IEnumerable<ValidationResult> Errors => _errors;
        public object? Result { get; set; }

        public ApexaResult(object? result):this(true,result,null)
        {
            Result = result;
        }

        public ApexaResult(bool success, Object? result, IList<ValidationResult>? errors)
        {
            _success = success;
            Result = result;
            if (errors != null)
            {
                _errors = errors;
            }
            else
            {
                _errors = new List<ValidationResult>(); 
            }
        }
    }
}
