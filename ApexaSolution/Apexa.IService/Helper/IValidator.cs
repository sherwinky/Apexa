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
        /// <summary>
        /// Validate
        /// </summary>
        /// <param name="advisor">the entity to validate</param>
        /// <param name="results">validation result</param>
        /// <param name="checkSin">check sin</param>
        /// <returns></returns>
        bool IsValidate(Advisor advisor,out IList<ValidationResult>? results, bool checkSin = false);
        /// <summary>
        /// Check if the record existed in the database
        /// </summary>
        /// <param name="id"></param>
        /// <param name="results"></param>
        /// <returns></returns>
        bool IsExist(long id, out IList<ValidationResult>? results);
    }
}
