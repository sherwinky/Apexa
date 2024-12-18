using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Apexa.Data;
using Apexa.Data.Dto;
using Apexa.IDAL;
using Apexa.IService.Helper;

namespace Apexa.Service.Helper
{
    public class AdvisorValidator : IValidator
    {
        private readonly IAdvisorDal _advisorDal;
        public AdvisorValidator(IAdvisorDal advisorDal)
        {
            _advisorDal = advisorDal;
        }

        public bool IsValidate(Advisor? advisor, out IList<ValidationResult>? results, bool checkSin = false)
        {
            results = new List<ValidationResult>();
            if (advisor == null)
            {
                AddValidationError(results, MessageDefination.AdvisorIsNull);
            }
            else
            {
                var context = new ValidationContext(advisor, null, null);
                ICollection<ValidationResult> result = new List<ValidationResult>();
                if (Validator.TryValidateObject(advisor, context, results, true))
                {
                    if (checkSin)
                    {
                        if (_advisorDal.CheckSinUnique(advisor.Sin!, advisor.Id))
                        {
                            AddValidationError(results,MessageDefination.SinShouldBeUnique);
                        }

                    }
                }
            }

            return results.Count == 0;
        }

        public bool IsExist(long id, out IList<ValidationResult>? results)
        {
            results = new List<ValidationResult>();
            Advisor advisor = _advisorDal.Get(id);
            if (advisor == null)
            {
                AddValidationError(results, MessageDefination.CanNotFindAdvisor);
            }

            return advisor != null;
        }

        private void AddValidationError(IList<ValidationResult> results, string message)
        {
            results.Add(new ValidationResult(message));
        }
    }
}
