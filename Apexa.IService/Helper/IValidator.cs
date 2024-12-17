using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apexa.Data;
using Apexa.Data.Dto;

namespace Apexa.IService.Helper
{
    public interface IValidator
    {
        bool IsValidate(Advisor advisor,out IList<ValidationResult>? results, bool checkSin = false);
        bool IsExist(long id, out IList<ValidationResult>? results);
    }
}
